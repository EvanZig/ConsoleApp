using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // Player 1 starts first
        static int choice;     // User choice for the position
        static int flag = 0;   // Flag to determine the game's status

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // Whenever loop restarts we clear the console
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Turn: Player 2");
                }
                else
                {
                    Console.WriteLine("Turn: Player 2");
                    Console.WriteLine("Test Changes");
                    Console.WriteLine("Turn: Player 1");
                }
                Console.WriteLine("\n");
                Board(); // Show the board
                choice = int.Parse(Console.ReadLine()); // Take player input

                // Check if the input is valid and the position is not already marked
                if (board[choice] != 'X' && board[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        board[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        board[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    // If the position is already taken, show message and redo the turn
                    Console.WriteLine($"Position {choice} is already marked with an {board[choice]}.");
                    Console.WriteLine("Please wait 2 seconds and try again...");
                    System.Threading.Thread.Sleep(2000);
                }

                flag = CheckWin(); // Check if someone has won or if there is a draw

            } while (flag != 1 && flag != -1);

            Console.Clear(); // Game ends, clear the board
            Board();

            if (flag == 1)
            {
                Console.WriteLine($"Player {(player % 2) + 1} has won!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.ReadLine();
        }

        // Function to check for a win or a draw
        private static int CheckWin()
        {
            switch (true)
            {
                #region Winning Combinations
                // Horizontal winning combinations
                case bool _ when board[1] == board[2] && board[2] == board[3]:
                case bool _ when board[4] == board[5] && board[5] == board[6]:
                case bool _ when board[7] == board[8] && board[8] == board[9]:
                // Vertical winning combinations
                case bool _ when board[1] == board[4] && board[4] == board[7]:
                case bool _ when board[2] == board[5] && board[5] == board[8]:
                case bool _ when board[3] == board[6] && board[6] == board[9]:
                // Diagonal winning combinations
                case bool _ when board[1] == board[5] && board[5] == board[9]:
                case bool _ when board[3] == board[5] && board[5] == board[7]:
                    return 1;
                #endregion

                // Check for a draw (all positions filled)
                case bool _ when board[1] != '1' && board[2] != '2' && board[3] != '3' &&
                                 board[4] != '4' && board[5] != '5' && board[6] != '6' &&
                                 board[7] != '7' && board[8] != '8' && board[9] != '9':
                    return -1;

                default:
                    return 0;
            }
        }


        // Function to display the board
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[1]}  |  {board[2]}  |  {board[3]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[4]}  |  {board[5]}  |  {board[6]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[7]}  |  {board[8]}  |  {board[9]}");
            Console.WriteLine("     |     |      ");
        }
    }
}
