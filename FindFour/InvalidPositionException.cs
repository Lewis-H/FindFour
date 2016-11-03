/**
 * @file InvalidPositionException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class InvalidPositionException : FindFourException {
        public InvalidPositionException() : base() { }

        public InvalidPositionException(string message) : base(message) { }

        public InvalidPositionException(string message, InvalidPositionException innerException) : base(message, innerException) { }
    }
}
