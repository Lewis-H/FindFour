/**
 * @file BoardTooSmallException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when the given board size is smaller than allowed, smallest is 4x4.
     */
    public class BoardTooSmallException : FindFourException {
        /**
         * BoardTooSmallException constructor.
         */
        public BoardTooSmallException() : base() { }

        /**
         * BoardTooSmallException constructor.
         *
         * @param message
         *  The exception message.
         */
        public BoardTooSmallException(string message) : base(message) { }

        /**
         * BoardTooSmallException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public BoardTooSmallException(string message, BoardTooSmallException innerException) : base(message, innerException) { }
    }
}
