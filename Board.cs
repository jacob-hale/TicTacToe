using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace TicTacToe
{
    internal class Board
    {
        public Board() { }
        public static void PrintBoard(string[] board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("-----------");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("-----------");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        public static string CheckWinner(string[] board)
        {
            // Helper local function to reduce repetition
            bool IsWinner(string a, string b, string c) =>
                a == b && b == c;

            // Horizontal (rows)
            if (IsWinner(board[0], board[1], board[2])) return board[0];
            if (IsWinner(board[3], board[4], board[5])) return board[3];
            if (IsWinner(board[6], board[7], board[8])) return board[6];

            // Vertical (columns)
            if (IsWinner(board[0], board[3], board[6])) return board[0];
            if (IsWinner(board[1], board[4], board[7])) return board[1];
            if (IsWinner(board[2], board[5], board[8])) return board[2];

            // Diagonal
            if (IsWinner(board[0], board[4], board[8])) return board[0];
            if (IsWinner(board[2], board[4], board[6])) return board[2];

            // No winner
            return "";
        }

    }
}