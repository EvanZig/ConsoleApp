using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; 
        static int choice;
        static int draws = 0;
        static int gameStatus = 0;
        static int playerOneWins = 0;
        static int playerTwoWins = 0;
        static int totalGamesPlayed = 0; 
        const char PLAYER_ONE_SYMBOL = 'X';
        const char PLAYER_TWO_SYMBOL = 'O';
        static Random random = new Random();
        static List<string> moveHistory = new List<string>(); // Move history feature
        
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                ResetBoard();
                player = random.Next(1, 3); // Randomize starting player
                gameStatus = 0;
                moveHistory.Clear(); // Clear move history for new game

                do
                {
                    Console.Clear();
                    Console.WriteLine("Player 1: X and Player 2: O");
                    Console.WriteLine("\n");
                    Console.WriteLine($"Score - Player 1: {playerOneWins} | Player 2: {playerTwoWins} | Draws: {draws}");
                    Console.WriteLine($"Total Games Played: {totalGamesPlayed}");
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

                    char currentSymbol = player % 2 == 0 ? PLAYER_TWO_SYMBOL : PLAYER_ONE_SYMBOL;
                    board[choice] = currentSymbol;
                    moveHistory.Add($"Player {(player % 2) + 1}: {currentSymbol} to position {choice}"); // Track move history
                    player++;
                    gameStatus = CheckWin();

                } while (gameStatus == 0);

                Console.Clear();
                Board();

                if (gameStatus == 1)
                {
                    int winningPlayer = (player % 2) + 1;
                    Console.WriteLine($"Player {winningPlayer} has won!");
                    if (winningPlayer == 1)
                    {
                        playerOneWins++;
                    }
                    else
                    {
                        playerTwoWins++;
                    }
                }
                else if (gameStatus == -1)
                {
                    Console.WriteLine("It's a Draw!");
                    draws++;
                }

                totalGamesPlayed++;

                // Display move history after each game
                Console.WriteLine("\nMove History:");
                foreach (var move in moveHistory)
                {
                    Console.WriteLine(move);
                }

                Console.WriteLine("Would you like to play again? (Y/N): ");
                playAgain = Console.ReadLine().ToUpper() == "Y";
            }

            Console.WriteLine($"Score - Player 1: {playerOneWins} | Player 2: {playerTwoWins} | Draws: {draws}");
            Console.WriteLine($"Total Games Played: {totalGamesPlayed}");
        }

        private static void ResetBoard()
        {
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = char.Parse(i.ToString());
            }
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

            if (Array.TrueForAll(board[1..], cell => cell == PLAYER_ONE_SYMBOL || cell == PLAYER_TWO_SYMBOL))
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
