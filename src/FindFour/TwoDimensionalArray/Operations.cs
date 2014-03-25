/**
 * @file Operations.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.TwoDimensionalArray {
    /**
     * Performs operations on two dimensional arrays.
     */
    static class Operations {
        /**
         * Gets a column from the two dimensional array.
         *
         * @param array
         *  The array to get the column from.
         * @param x
         *  The column to get from the array.
         *
         * @return
         *  The specified column as a 1 dimensional array.
         */
        public static T[] GetColumn<T>(T[,] array, int x) {
            T[] column;
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            // If the column doesn't exist in this array (is out of index range), throw an exception.
            if(x < 0 || x >= width) throw new Exceptions.InvalidColumnException("The column " + x + " does not exist!");
            column = new T[height];
            // Iterate through every value within the column, adding them to the one dimensional array.
            for(int y = 0; y < height; y++) column[y] = array[y, x];
            return column;
        }

        /**
         * Gets a row from the two dimensional array.
         *
         * @param array
         *  The array to get the row from.
         * @param y
         *  The row to get from the array.
         *
         * @return
         *  The specified row as a 1 dimensional array.
         */
        public static T[] GetRow<T>(T[,] array, int y) {
            T[] row;
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            // If the row doesn't exist in this array (is out of index range), throw an exception.
            if(y < 0 || y >= height) throw new Exceptions.InvalidRowException("The row " + y + " does not exist!");
            row = new T[width];
            // Iterate through every value within the row, adding them to the one dimensional array.
            for(int x = 0; x < width; x++) row[x] = array[y, x];
            return row;
        }

        /**
         * Gets a diagonal line from the two dimensional array.
         *
         * @param array
         *  The array to get the column from.
         * @param gradient
         *  The gradient of the diagonal line.
         * @param intercept
         *  The intercept of the diagonal line.
         *
         * @return
         *  The specified diagonal as a 1 dimensional array.
         */
        public static T[] GetDiagonal<T>(T[,] array, DiagonalDirection direction, int intercept) {
            int width = array.GetLength(1) - 1;
            int height = array.GetLength(0) - 1;
            int gradient = direction == DiagonalDirection.TopRight ? 1 : -1;
            int y = intercept;
            int x = 0;
            if(y > height) x = (height - intercept) / gradient;
            if(y < 0) x = (0 - intercept) / gradient;
            y = gradient * x + intercept;
            int length = System.Math.Min(width - x + 1, (gradient == 1) ? height - y + 1 : y + 1);
            T[] line = new T[length];
            if(length > 0)
                for(int i = 0; x >= 0 && x <= width && y >= 0 && y <= height; i++) {
                    line[i] = array[y, x];
                    x++;
                    y = (gradient * x) + intercept;
                }
            return line;
        }

    }
}
