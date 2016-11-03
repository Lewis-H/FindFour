/**
 * @file BoardTooSmallException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {

    public class BoardTooSmallException : FindFourException {
        public BoardTooSmallException() : base() { }

        public BoardTooSmallException(string message) : base(message) { }

        public BoardTooSmallException(string message, BoardTooSmallException innerException) : base(message, innerException) { }
    }
}
