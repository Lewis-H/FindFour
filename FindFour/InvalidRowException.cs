/**
 * @file InvalidRowException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class InvalidRowException : FindFourException {
        public InvalidRowException() : base() { }

        public InvalidRowException(string message) : base(message) { }

        public InvalidRowException(string message, InvalidRowException innerException) : base(message, innerException) { }
    }
}
