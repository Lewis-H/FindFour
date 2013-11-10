/**
 * @file GameWinHandler.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Events {
    /**
     * Handles a game win.
     *
     * @param winner
     *  The player who won the game.
     */
    public delegate void GameWinHandler(int winner);
}
