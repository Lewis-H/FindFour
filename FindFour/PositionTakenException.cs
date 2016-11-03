/**
 * @file PositionTakenException.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour {
    public class PositionTakenException : FindFourException {
        public PositionTakenException() : base() { }

        public PositionTakenException(string message) : base(message) { }

        public PositionTakenException(string message, PositionTakenException innerException) : base(message, innerException) { }
    }
}
