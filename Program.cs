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
            
        // Main game loop
        while (!gameOver)
        {
            // Print current gameboard
            GameBoard.PrintBoard(board);
            
            // Prompt current player for a move
            Console.WriteLine($"Player {currentPlayer}, choose a position 1-9");

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
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select an open position (1-9): ");
                }
            }
            
            //Check for a winner or tie
            string result = GameBoard.CheckWinner(board);
            
            // IF X or O won
            if (result == "X" || result == "O")
            {
                GameBoard.PrintBoard(board);
                Console.WriteLine($"Player {result} wins!");
                gameOver = true;
            }
            
            // IF the game is a tie
            else if (result == "tie")
            {
                GameBoard.PrintBoard(board);
                Console.WriteLine("The game ends in a tie!");
                gameOver = true;
            }
            
            //Otherwise, switch players and continue
            else
            {
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
            }
        }
    }
    
}