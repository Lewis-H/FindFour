/**
 * @file InvalidColumnException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class InvalidColumnException : FindFourException {
        public InvalidColumnException() : base() { }

        public InvalidColumnException(string message) : base(message) { }

        public InvalidColumnException(string message, InvalidColumnException innerException) : base(message, innerException) { }
    }
}
