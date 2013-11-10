/**
 * @file ColumnFullException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when a player tries to drop a chip in a column that is full.
     */
    public class ColumnFullException : FindFourException {
        /**
         * ColumnFullException constructor.
         */
        public ColumnFullException() : base() { }

        /**
         * ColumnFullException constructor.
         *
         * @param message
         *  The exception message.
         */
        public ColumnFullException(string message) : base(message) { }

        /**
         * ColumnFullException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public ColumnFullException(string message, ColumnFullException innerException) : base(message, innerException) { }
    }
}
