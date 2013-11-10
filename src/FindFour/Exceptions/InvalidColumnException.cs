/**
 * @file InvalidColumnException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when access to a column that does not exist is attempted.
     */
    public class InvalidColumnException : FindFourException {
        /**
         * InvalidColumnException constructor.
         */
        public InvalidColumnException() : base() { }

        /**
         * InvalidColumnException constructor.
         *
         * @param message
         *  The exception message.
         */
        public InvalidColumnException(string message) : base(message) { }

        /**
         * InvalidColumnException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public InvalidColumnException(string message, InvalidColumnException innerException) : base(message, innerException) { }
    }
}
