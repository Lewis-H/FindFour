/**
 * @file Board.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

using System;

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
            get;
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
            if(x >= Width || x < 0 || y >= Height || y < 0) throw new InvalidPositionException("The position (" + x + ", " + y + ") does not exist on the board.");
            return positions[y, x];
        }

        public bool IsEmpty(int x, int y) {
            return GetChip(x, y) == 0;
        }

        private void PlaceChip(int x, int y) {
            if(IsEmpty(x, y) == false) throw new PositionTakenException("The position (" + x + ", " + y + ") is already taken by player " + GetChip(x, y) + ".");
            if(x >= Width || x < 0 || y >= Height || y < 0) throw new InvalidPositionException("The position (" + x + ", " + y + ") does not exist on the board.");
            if(OnPlace != null) OnPlace(x, y, CurrentTurn);
            positions[y, x] = CurrentTurn;
            Moves++;
            if(!CheckWin(x, y))
                if(Moves == Area) {
                    if(OnDraw != null) OnDraw();
                }else{
                    CurrentTurn = (CurrentTurn != 1) ? 1 : 2;
                    OnNextTurn(CurrentTurn);
                }
            else
                if(OnWin != null) OnWin(CurrentTurn);
        }
            
        public void Drop(int column) {
            if(column < 0 || column >= Width) throw new InvalidColumnException("Column " + column + " does not exist on the board.");
            if(columnPlacements[column] == Height) throw new ColumnFullException("Column " + column + " is full!");
            PlaceChip(column, columnPlacements[column]);
            columnPlacements[column]++;
        }

        private bool CheckWin(int x, int y) {
            if(x < 0 || x >= Width) throw new InvalidPositionException("x out of range.");
            if(y < 0 || y >= Height) throw new InvalidPositionException("y out of range.");
            int[] differences = { 3, 0, -3 };
            int x1, y1;
            foreach(int dx in differences) {
                foreach(int dy in differences) {
                    x1 = x + dx;
                    y1 = y + dy;
                    if(x1 >= 0 && x1 < Width && y1 >= 0 && y1 < Height && (x != x1 || y != y1)) {
                        int[] line = Select(x, y, x1, y1);
                        for(int i = 0; i < line.Length; i++) {
                            if(line[i] != CurrentTurn)
                                break;
                            if(i == line.Length - 1)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private int[] Select(int x0, int y0, int x1, int y1) {
            if(!(x1 - x0 == y1 - y0)) throw new ImpossibleSelectionException("Cannot select specified line.");
            if(x0 < 0 || x0 >= Width) throw new InvalidPositionException("x0 out of range.");
            if(x1 < 0 || x1 >= Width) throw new InvalidPositionException("x1 out of range.");
            if(y0 < 0 || y0 >= Height) throw new InvalidPositionException("y0 out of range.");
            if(y1 < 0 || y1 >= Height) throw new InvalidPositionException("y1 out of range.");
            int x = x0,
                y = y0,
               dx = (x0 == x1 ? 0 : x0 < x1 ? 1 : -1),
               dy = (y0 == y1 ? 0 : y0 < y1 ? 1 : -1);
            int[] line = new int[Math.Max(Math.Abs(x0 - x1), Math.Abs(y0 - y1)) + 1];
            for(int i = 0; i < line.Length; i++) {
                line[i] = positions[x, y];
                x += dx;
                y += dy;
            }
            return line;
        }
            
        public int[,] ToArray() {
            int[,] copy = new int[Width, Height];
            System.Array.Copy(positions, copy, Width);
            return copy;
        }
    }
}
