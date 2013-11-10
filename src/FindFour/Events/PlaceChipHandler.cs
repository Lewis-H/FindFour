/**
 * @file PlaceChipHandler.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */

namespace FindFour.Events {
    /**
     * Handles a chip place event.
     *
     * @param x
     *  The x co-ordinate of the position the chip has been placed to.
     * @param y
     *  The y co-ordinate of the position the chip has been placed to.
     * @param player
     *  The player who placed the chip.
     */
    public delegate void PlaceChipHandler(int x, int y, int player);
}
