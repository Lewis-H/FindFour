/**
 * @file Example.cs
 * @author Lewis Hazell
 * @license http://www.gnu.org/copyleft/lesser.html
 */
namespace FindFour {
    /*
     * -- EXAMPLE FILE --
     * If this works correctly, it should output the following:
     *  It is now player 1's turn!
     *  1 has placed a chip at (0, 0).
     *  It is now player 2's turn!
     *  2 has placed a chip at (1, 0).
     *  It is now player 1's turn!
     *  1 has placed a chip at (1, 1).
     *  It is now player 2's turn!
     *  2 has placed a chip at (2, 0).
     *  It is now player 1's turn!
     *  1 has placed a chip at (0, 1).
     *  It is now player 2's turn!
     *  2 has placed a chip at (2, 1).
     *  It is now player 1's turn!
     *  1 has placed a chip at (2, 2).
     *  It is now player 2's turn!
     *  2 has placed a chip at (3, 0).
     *  It is now player 1's turn!
     *  1 has placed a chip at (1, 2).
     *  It is now player 2's turn!
     *  2 has placed a chip at (3, 1).
     *  It is now player 1's turn!
     *  1 has placed a chip at (2, 3).
     *  It is now player 2's turn!
     *  2 has placed a chip at (3, 2).
     *  It is now player 1's turn!
     *  1 has placed a chip at (3, 3).
     *  Player 1 won!
     *
     * Enjoy the FindFour library!
     */

    public class Example {
        static void Main() {
            Board game = new Board(); // Creates a new find four board.
            // Register event listeners.
            game.OnWin += Win;
            game.OnPlace += Place;
            game.OnDraw += Draw;
            game.OnNextTurn += NextTurn;
            // Commence the game!
            game.Start();
            // Drop chips into columns
            game.Drop(0); // Player 1
            game.Drop(1); // Player 2
            game.Drop(1); // Player 1
            game.Drop(2); // Player 2
            game.Drop(0); // Player 1
            game.Drop(2); // Player 2
            game.Drop(2); // Player 1
            game.Drop(3); // Player 2
            game.Drop(1); // Player 1
            game.Drop(3); // Player 2
            game.Drop(2); // Player 1
            game.Drop(3); // Player 2
            game.Drop(3); // Player 1
        }

        // Outputs a win!
        public static void Win(int winner) {
            System.Console.WriteLine("Player {0} won!", winner);
            System.Environment.Exit(0);
        }

        // Outputs who dropped a chip and where.
        public static void Place(int x, int y, int player) {
            System.Console.WriteLine("{0} has placed a chip at ({1}, {2}).", player, x, y);
        }

        // This shouldn't happen unless you altered the Example...
        public static void Draw() {
            System.Console.WriteLine("The players drew!");
            System.Environment.Exit(0);
        }

        // Outputs who's turn it is now.
        public static void NextTurn(int player) {
            System.Console.WriteLine("It is now player {0}'s turn!", player);
        }
    }
}
