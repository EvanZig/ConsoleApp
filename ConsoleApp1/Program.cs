using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; 
        static int choice;  
        static int flag = 0;  

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
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
                Board(); 
                choice = int.Parse(Console.ReadLine()); 

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
                    Console.WriteLine($"Position {choice} is already marked with an {board[choice]}.");
                    Console.WriteLine("Please wait 2 seconds and try again...");
                    System.Threading.Thread.Sleep(2000);
                }

                flag = CheckWin(); 

            } while (flag != 1 && flag != -1);

            Console.Clear(); 
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

        private static int CheckWin()
        {
            switch (true)
            {
                #region Winning Combinations
                case bool _ when board[1] == board[2] && board[2] == board[3]:
                case bool _ when board[4] == board[5] && board[5] == board[6]:
                case bool _ when board[7] == board[8] && board[8] == board[9]:
                case bool _ when board[1] == board[4] && board[4] == board[7]:
                case bool _ when board[2] == board[5] && board[5] == board[8]:
                case bool _ when board[3] == board[6] && board[6] == board[9]:
                case bool _ when board[1] == board[5] && board[5] == board[9]:
                case bool _ when board[3] == board[5] && board[5] == board[7]:
                    return 1;
                #endregion

                case bool _ when board[1] != '1' && board[2] != '2' && board[3] != '3' &&
                                 board[4] != '4' && board[5] != '5' && board[6] != '6' &&
                                 board[7] != '7' && board[8] != '8' && board[9] != '9':
                    return -1;

                default:
                    return 0;
            }
        }


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
