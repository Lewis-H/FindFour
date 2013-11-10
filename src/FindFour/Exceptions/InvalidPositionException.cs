/**
 * @file InvalidPositionException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when a player tries to place a chip in a position that does not exist.
     */
    public class InvalidPositionException : FindFourException {
        /**
         * InvalidPositionException constructor.
         */
        public InvalidPositionException() : base() { }

        /**
         * InvalidPositionException constructor.
         *
         * @param message
         *  The exception message.
         */
        public InvalidPositionException(string message) : base(message) { }

        /**
         * InvalidPositionException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public InvalidPositionException(string message, InvalidPositionException innerException) : base(message, innerException) { }
    }
}
