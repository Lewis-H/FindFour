/**
 * @file NextTurnHandler.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Events {
    /**
     * Handles a turn change event.
     *
     * @param turn
     *  The player who's turn it is now.
     */
    public delegate void NextTurnHandler(int turn);
}
