/**
 * @file InvalidRowException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when access to a row that does not exist is attempted.
     */
    public class InvalidRowException : FindFourException {
        /**
         * InvalidRowException constructor.
         */
        public InvalidRowException() : base() { }

        /**
         * InvalidRowException constructor.
         *
         * @param message
         *  The exception message.
         */
        public InvalidRowException(string message) : base(message) { }

        /**
         * InvalidRowException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public InvalidRowException(string message, InvalidRowException innerException) : base(message, innerException) { }
    }
}
