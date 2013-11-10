/**
 * @file PositionTakenException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when a player tries to place a chip in a position which is already taken.
     */
    public class PositionTakenException : FindFourException {
        /**
         * PositionTakenException constructor.
         */
        public PositionTakenException() : base() { }

        /**
         * PositionTakenException constructor.
         *
         * @param message
         *  The exception message.
         */
        public PositionTakenException(string message) : base(message) { }

        /**
         * PositionTakenException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public PositionTakenException(string message, PositionTakenException innerException) : base(message, innerException) { }
    }
}
