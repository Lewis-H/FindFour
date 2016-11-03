/**
 * @file Board.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

using FindFour.TwoDimensionalArray;
namespace FindFour {
    public class Board {
        private readonly int[,] positions;
        private readonly int[] columnPlacements;
        public event GameWinEventHandler OnWin;
        public event GameDrawEventHandler OnDraw;
        public event PlaceChipEventHandler OnPlace;
        public event NextTurnEventHandler OnNextTurn;

        public int Width {
            get;
        }

        public int Height {
            get;
        }

        public int Area {
            get;
        }

        public int Moves { 
            public get;
            private set;
        }

        public int CurrentTurn {
            get;
            private set;
        }

        public Board(int h, int w) {
            if(w < 4 || h < 4) throw new FindFour.BoardTooSmallException("The minimum allowed board size is 4x4.");
            Width = w;
            Height = h;
            positions = new int[Height, Width];
            columnPlacements = new int[Width];
            Area = w * h;
        }

        public Board() : this(7, 6) {}

        public int GetChip(int x, int y) {
            if(x >= Width || x < 0 || y >= Height || y < 0) throw new FindFour.InvalidPositionException("The position (" + x + ", " + y + ") does not exist on the board.");
            return positions[y, x];
        }

        public bool IsEmpty(int x, int y) {
            return GetChip(x, y) == 0;
        }

        private void PlaceChip(int x, int y) {
            if(IsEmpty(x, y) == false) throw new FindFour.PositionTakenException("The position (" + x + ", " + y + ") is already taken by player " + GetChip(x, y) + ".");
            if(x >= Width || x < 0 || y >= Height || y < 0) throw new FindFour.InvalidPositionException("The position (" + x + ", " + y + ") does not exist on the board.");
            if(OnPlace != null) OnPlace(x, y, CurrentTurn);
            positions[y, x] = CurrentTurn;
            Moves++;
            if(!CheckWin())
                if(Moves == Area) 
                    if(OnDraw != null) OnDraw();
                else
                    CurrentTurn = (CurrentTurn != 1) ? 1 : 2;
            else
                if(OnWin != null) OnWin(CurrentTurn);
        }
            
        public void Drop(int column) {
            if(column < 0 || column >= Width) throw new FindFour.InvalidColumnException("Column " + column + " does not exist on the board.");
            if(columnPlacements[column] == Height) throw new FindFour.ColumnFullException("Column " + column + " is full!");
            PlaceChip(column, columnPlacements[column]);
            columnPlacements[column]++;
        }
            
        private bool CheckWin() {
            if(CheckRows() ||CheckColumns() || CheckDiagonals()) return true;
            return false;
        }
            
        private bool CheckRows() {
            for(int y = 0; y < Height; y++) if(ProcessLine(Operations.GetRow<int>(positions, y))) return true;
            return false;
        }
            
        private bool CheckColumns() {
            for(int x = 0; x < Width; x++) if(ProcessLine(Operations.GetColumn<int>(positions, x))) return true;
            return false;
        }
            
        private bool CheckDiagonals() {
            for(int c = 3; c < Height + (Width - 4); c++) if(ProcessLine(Operations.GetDiagonal<int>(positions, DiagonalDirection.BottomRight, c))) return true;
            for(int c = 4 - Width; c < Height - 3; c++) if(ProcessLine(Operations.GetDiagonal<int>(positions, DiagonalDirection.TopRight, c))) return true;
            return false;
        }
            
        private bool ProcessLine(int[] line) {
            int streak = 0;
            int previous = 0;
            foreach(int chip in line) {
                if(previous == 0 && previous != chip) {
                    streak = 1;
                }else if(previous != 0 && previous == chip) {
                    streak++;
                }else if(previous != chip) {
                    streak = 1;
                }
                previous = chip;
                if(streak >= 4) return true;
            }
            return false;
        }
            
        public int[,] ToArray() {
            int[,] copy = new int[Width, Height];
            System.Array.Copy(positions, copy, Width);
            return copy;
        }
    }
}
