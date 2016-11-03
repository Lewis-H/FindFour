/**
 * @file FindFourException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class FindFourException : System.Exception {
        public FindFourException() : base() { }

        public FindFourException(string message) : base(message) { }

        public FindFourException(string message, FindFourException innerException) : base(message, innerException) { }
    }
}
