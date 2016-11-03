/**
 * @file GameNotActiveException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class GameNotActiveException : FindFourException {
        public GameNotActiveException() : base() { }

        public GameNotActiveException(string message) : base(message) { }

        public GameNotActiveException(string message, GameNotActiveException innerException) : base(message, innerException) { }
    }
}
