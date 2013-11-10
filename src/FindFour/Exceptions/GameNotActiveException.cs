/**
 * @file GameNotActiveException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Exceptions {
    /**
     * Thrown when a game is not active but a player attempts to place a chip.
     */
    public class GameNotActiveException : FindFourException {

        /**
         * GameNotActiveException constructor.
         */
        public GameNotActiveException() : base() { }

        /**
         * GameNotActiveException constructor.
         *
         * @param message
         *  The exception message.
         */
        public GameNotActiveException(string message) : base(message) { }

        /**
         * GameNotActiveException constructor.
         *
         * @param message
         *  The exception message.
         * @param innerException
         *  The inner exception of this exception.
         */
        public GameNotActiveException(string message, GameNotActiveException innerException) : base(message, innerException) { }
    }
}
