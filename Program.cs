using System;
using TicTacToe;

internal class Program

{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Player 1 will be X's.");
        Console.WriteLine("Player 2 will be O's.");
        Console.WriteLine();
        
        // Initialize game board w/ positions 1-9
        string[] board = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

        string currentPlayer = "X";
        bool gameOver = false;
        int turnCount = 0;


        // Main game loop
        while (!gameOver)
        {
            // Print current gameboard
            Board.PrintBoard(board);
            
            // Prompt current player for a move
            Console.WriteLine($"Player {currentPlayer}, choose a position (1-9): ");

            int choice;
            bool validMove = false;
            
            //Validate input
            while (!validMove)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) &&
                    choice >= 1 &&
                    choice <= 9 &&
                    board[choice - 1] != "X" &&
                    board[choice - 1] != "O")
                {
                    board[choice - 1] = currentPlayer;
                    turnCount++;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select an open position (1-9): ");
                }

            }

            // Check for a winner
            string result = Board.CheckWinner(board);

            // If X or O won
            if (result == "X" || result == "O")
            {
                Board.PrintBoard(board);
                Console.WriteLine($"Player {result} wins!");
                gameOver = true;
            }
            // If all 9 turns have been played and no winner, it's a tie
            else if (turnCount == 9)
            {
                Board.PrintBoard(board);
                Console.WriteLine("The game ends in a tie!");
                gameOver = true;
            }
            // Otherwise, switch players and continue
            else
            {
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
            }

        }
    }
    
}