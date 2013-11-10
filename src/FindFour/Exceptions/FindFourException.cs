/**
 * @file FindFourException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Base find four exception.
     */
    public class FindFourException : System.Exception {
        /**
         * FindFourException constructor.
         */
        public FindFourException() : base() { }

        /**
         * FindFourException constructor.
         *
         * @param message
         *  The exception message.
         */
        public FindFourException(string message) : base(message) { }

        /**
         * FindFourException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public FindFourException(string message, FindFourException innerException) : base(message, innerException) { }
    }
}
