﻿using System;
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
        static List<string> moveHistory = new List<string>();
        
        static List<string> motivationalMessages = new List<string>
        {
            "Nice move!",
            "You're on fire!",
            "Keep it up!",
            "Great choice!",
            "You're almost there!",
            "You're on the right track!"
        };
        
        static List<string> funFacts = new List<string>
        {
            "Tic-Tac-Toe is also called Noughts and Crosses.",
            "The game has been played for over 3000 years!",
            "In some parts of the world, it's called 'X's and O's.",
            "The first computer to play Tic-Tac-Toe was built in 1952.",
            "There are 255,168 unique game combinations!",
            "Did you know? The first player can always win or draw if they play optimally!",
            "The longest game of Tic-Tac-Toe on record took 91 moves to complete!"
        };


        
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                ResetBoard();
                player = random.Next(1, 3);
                gameStatus = 0;
                moveHistory.Clear(); 

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
                    moveHistory.Add($"Player {(player % 2) + 1}: {currentSymbol} to position {choice}");

                    Console.WriteLine(motivationalMessages[random.Next(motivationalMessages.Count)]);
                    System.Threading.Thread.Sleep(1000);

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

                Console.WriteLine("\nMove History:");
                foreach (var move in moveHistory)
                {
                    Console.WriteLine(move);
                }

                Console.WriteLine("Would you like to play again? (Y/N): ");
                playAgain = Console.ReadLine().ToUpper() == "Y";
                Console.WriteLine($"Fun Fact: {funFacts[random.Next(funFacts.Count)]}");
                System.Threading.Thread.Sleep(1500);

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
            char currentSymbol = player % 2 == 0 ? PLAYER_TWO_SYMBOL : PLAYER_ONE_SYMBOL;
            Console.WriteLine($"Player {(player % 2) + 1}'s Turn: {currentSymbol}");
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
