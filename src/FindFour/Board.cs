/**
 * @file Board.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

using FindFour.TwoDimensionalArray;
namespace FindFour {
    /**
     * Handles the find four board and it's players.
     */
    public class Board {
        private readonly int[,] positions; //< Two dimensional array of all the positions on the board.
        private readonly int[] columnCache; //< Column cache of the different columns for dropping, records the spaces taken in each column.
        private readonly int width; //< Width of the board.
        private readonly int height; //< Height of the board.
        private readonly int area; //< Area of the board.
        private int moves = 0; //< How many moves have been done.
        private int currentTurn = 0; //< Who's turn it is.
        private bool active = false; //< Whether the game is finished (winner or draw).
        private event Events.GameWinHandler onWin; //< Game win event.
        private event Events.GameDrawHandler onDraw; //< Game draw event.
        private event Events.PlaceChipHandler onPlace; //< Chip place event.
        private event Events.NextTurnHandler onNextTurn; //< Next turn event.
        private readonly object positionLocker    = new object(),
                                columnCacheLocker = new object(),
                                activeLocker      = new object(),
                                turnLocker        = new object(),
                                movesLocker       = new object(),
                                winEventLocker    = new object(),
                                drawEventLocker   = new object(),
                                placeEventLocker  = new object(),
                                turnEventLocker   = new object();
        //! Gets the width of the board.
        public int Width {
            get { return width; }
        }

        //! Gets the height of the board.
        public int Height {
            get { return height; }
        }

        //! Gets the area of the board.
        public int Area {
            get { return area; }
        }

        //! Gets the total moves performed on the board.
        public int Moves { 
            private set { lock(movesLocker) moves = value; }
            get { lock(movesLocker) return moves; }
        }

        //! Gets or sets the game win event.
        public Events.GameWinHandler OnWin {
            get { lock(winEventLocker) return onWin; }
            set { lock(winEventLocker) onWin = value; }
        }

        //! Gets or sets the game draw event.
        public Events.GameDrawHandler OnDraw {
            get { lock(drawEventLocker) return onDraw; }
            set { lock(drawEventLocker) onDraw = value; }
        }

        //! Gets or sets the chip place event.
        public Events.PlaceChipHandler OnPlace {
            get { lock(placeEventLocker) return onPlace; }
            set { lock(placeEventLocker) onPlace = value; }
        }

        //! Gets or sets the next turn event.
        public Events.NextTurnHandler OnNextTurn {
            get { lock(turnEventLocker) return onNextTurn; }
            set { lock(turnEventLocker) onNextTurn = value; }
        }

        //! Gets or sets the current turn on the board.
        public int CurrentTurn {
            get { lock(turnLocker) return currentTurn; }
            private set {
                lock(turnEventLocker) if(OnNextTurn != null) OnNextTurn(value);
                lock(turnLocker) currentTurn = value;
            }
        }

        //! Gets or sets whether the game is active.
        public bool Active {
            get { lock(activeLocker) return active; }
            private set { lock(activeLocker) active = value; }
        }

        /**
         * Creates a new board.
         *
         * @param h
         *  The height of the board.
         * @param w
         *  The width of the board.
         */
        public Board(int h, int w) {
            if(w < 4 || h < 4) throw new Exceptions.BoardTooSmallException("The minimum allowed board size is 4x4.");
            width = w;
            height = h;
            positions = new int[height, width];
            columnCache = new int[width];
            area = w * h;
        }

        /**
         * Creates a new board with a default size of 7x6.
         */
        public Board() : this(7, 6) {}

        /**
         * Starts the game.
         */
        public void Start() {
            Active = true;
            lock(positionLocker) System.Array.Clear(positions, 0, positions.Length);
            lock(columnCacheLocker) System.Array.Clear(columnCache, 0, columnCache.Length);
            CurrentTurn = 1;
        }

        /**
         * Gets the value of a chip on the board.
         *
         * @param x
         *  The x co-ordinate of the position.
         * @param y
         *  The y co-ordinate of the position.
         *
         * @return
         *  The value the chip is set to.
         */
        public int GetChip(int x, int y) {
            if(x >= width || x < 0 || y >= height || y < 0) throw new Exceptions.InvalidPositionException("The position (" + x + ", " + y + ") does not exist on the board.");
            lock(positionLocker) return positions[y, x];
        }

        /**
         * Gets whether a position on the board is empty.
         *
         * @param x
         *  The x co-ordinate of the position.
         * @param y
         *  The y co-ordinate of the position.
         *
         * @return
         *  TRUE if the position is empty, FALSE if not.
         */
        public bool IsEmpty(int x, int y) {
            return GetChip(x, y) == 0;
        }

        /**
         * Places a chip in a position on the board.
         *
         * @param x
         *  The x co-ordinate of the position.
         * @param y
         *  The y co-ordinate of the position.
         */
        private void PlaceChip(int x, int y) {
            lock(positionLocker) {
                if(Active == false) throw new Exceptions.GameNotActiveException("No chips can be placed when the game is not active!");
                if(IsEmpty(x, y) == false) throw new Exceptions.PositionTakenException("The position (" + x + ", " + y + ") is already taken by player " + GetChip(x, y) + ".");
                if(x >= width || x < 0 || y >= height || y < 0) throw new Exceptions.InvalidPositionException("The position (" + x + ", " + y + ") does not exist on the board.");
                if(OnPlace != null) OnPlace(x, y, currentTurn);
                positions[y, x] = currentTurn;
                Moves++;
                if(CheckWin() == false) {
                    if(Moves == area) {
                        lock(drawEventLocker) if(OnDraw != null) OnDraw();
                        Active = false;;
                    }else{
                        CurrentTurn = (CurrentTurn != 1) ? 1 : 2;
                    }
                }else{
                    lock(winEventLocker) if(OnWin != null) OnWin(CurrentTurn);
                    Active = false;
                }
            }
        }

        /**
         * Drops a chip into a column.
         *
         * @param column
         *  The column to drop the chip into.
         */
        public void Drop(int column) {
            if(column < 0 || column >= width) throw new Exceptions.InvalidColumnException("Column " + column + " does not exist on the board.");
            lock(columnCacheLocker) {
                if(columnCache[column] == height) throw new Exceptions.ColumnFullException("Column " + column + " is full!");
                PlaceChip(column, columnCache[column]);
                columnCache[column]++;
            }
        }

        /**
         * Checks for four chips in a row, either vertically, horizontally or diagonally.
         *
         * @return
         *  TRUE if a win has happened, FALSE if not.
         */
        private bool CheckWin() {
            if(CheckRows() ||CheckColumns() || CheckDiagonals()) return true;
            return false;
        }

        /**
         * Checks for a horizontal win.
         *
         * @return
         *  TRUE if a horizontal win has happened, FALSE if not.
         */
        private bool CheckRows() {
            for(int y = 0; y < height; y++) if(ProcessLine(Operations.GetRow<int>(positions, y))) return true;
            return false;
        }

        /**
         * Checks for a vertical win.
         *
         * @return
         *  TRUE if a horizontal win has happened, FALSE if not.
         */
        private bool CheckColumns() {
            for(int x = 0; x < width; x++) if(ProcessLine(Operations.GetColumn<int>(positions, x))) return true;
            return false;
        }

        /**
         * Checks for a diagonal win.
         *
         * @return
         *  TRUE if a diagonal win has happened, FALSE if not.
         */
        private bool CheckDiagonals() {
            foreach(DiagonalDirection direction in System.Enum.GetValues(typeof(DiagonalDirection)))
                for(int c = 4 - width; c < height - 4 - 1; c++) if(ProcessLine(Operations.GetDiagonal<int>(positions, direction, c))) { return true; }
            return false;
        }

        /**
         * Processes a line of chips to check for a streak of four of the same player.
         *
         * @param line
         *  The integer array of the line to check.
         *
         * @return
         *  TRUE if there is a streak of four, FALSE if not.
         */
        private bool ProcessLine(int[] line) {
            int streak = 0;
            int previous = 0;
            foreach(int chip in line) {
                if(previous == 0 && previous != chip) {
                    streak = 1;
                }else if(previous != 0 && previous == chip) {
                    streak++;
                }else if(previous != chip) {
                    streak = 0;
                }
                previous = chip;
                if(streak >= 4) return true;
            }
            return false;
        }

        /**
         * Represents the board as an array.
         *
         * @return
         *  The board as an array.
         */
        public int[,] ToArray() {
            int[,] copy = new int[width, height];
            lock(positionLocker) System.Array.Copy(positions, copy, width);
            return copy;
        }
    }
}
