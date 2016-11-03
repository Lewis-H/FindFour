/**
 * @file ColumnFullException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class ColumnFullException : FindFourException {
        public ColumnFullException() : base() { }

        public ColumnFullException(string message) : base(message) { }

        public ColumnFullException(string message, ColumnFullException innerException) : base(message, innerException) { }
    }
}
