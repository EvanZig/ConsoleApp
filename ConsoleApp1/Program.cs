using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; 
        static int choice;
        static int checkerFlag = 0;
        const char PLAYER_ONE_SYMBOL = 'X';
        const char PLAYER_TWO_SYMBOL = 'O';

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                Console.WriteLine($"Turn: Player {(player % 2) + 1}");

                Board();
                
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write("Choose your position (1-9): ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9)
                    {
                        if (board[choice] != PLAYER_ONE_SYMBOL && board[choice] != PLAYER_TWO_SYMBOL)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine($"Position {choice} is already marked with an {board[choice]}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a number between 1 and 9.");
                    }
                }

                board[choice] = player % 2 == 0 ? PLAYER_TWO_SYMBOL : PLAYER_ONE_SYMBOL;
                player++;
                checkerFlag = CheckWin();

            } while (checkerFlag != 1 && checkerFlag != -1);

            Console.Clear();
            Board();

            if (checkerFlag == 1)
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
            int[][] winningCombinations = {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
                new[] { 1, 4, 7 },
                new[] { 2, 5, 8 },
                new[] { 3, 6, 9 },
                new[] { 1, 5, 9 },
                new[] { 3, 5, 7 }
            };

            foreach (var combination in winningCombinations)
            {
                if (board[combination[0]] == board[combination[1]] && board[combination[1]] == board[combination[2]])
                {
                    return 1;
                }
            }
            if (Array.TrueForAll(board, cell => cell == PLAYER_ONE_SYMBOL || cell == PLAYER_TWO_SYMBOL))
            {
                return -1;
            }

            return 0;
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
