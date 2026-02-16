/*
 * Moses Muamba-Nzambi
 * CST - 250
 * 02/15/2026
 * Chess Board Project
 * Activity 2
 */

using System;
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

namespace ChessBoardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------------------
            // Start of Main Method
            // ---------------------------------------------------------

            // Declare and initialize
            string piece = "";
            Tuple<int, int>? result;
            BoardLogic boardLogic = new BoardLogic();

            // Print a welcome message for the user
            Console.WriteLine("Hello, Chess Players!");

            // Create a new chess board
            BoardModel board = new BoardModel(8);

            // Show the empty board
            Utility.PrintBoard(board);

            // Prompt the user for the type of chess piece
            Console.Write("Enter the type of piece you want to place (Knight, Rook, Bishop, Queen, King): ");
            piece = Console.ReadLine();

            // Prompt the user for the location of the chess piece
            result = Utility.GetRowAndCol();

            // Mark the legal moves based on the input
            board = boardLogic.MarkLegalMoves(
                        board,
                        board.Grid[result.Item1, result.Item2],
                        piece);

            // Print out the new chess board
            Utility.PrintBoard(board);

            Console.ReadLine();

            // ---------------------------------------------------------
            // End of Main Method
            // ---------------------------------------------------------
        }
    }

    // ---------------------------------------------------------
    // Define a utility class
    // ---------------------------------------------------------
    public static class Utility
    {
        /// <summary>
        /// Print the given board to the console
        /// </summary>
        internal static void PrintBoard(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Grid[row, col];

                    if (cell.IsLegalNextMove)
                    {
                        Console.Write("+ ");
                    }
                    else if (cell.PieceOccupyingCell != "")
                    {
                        Console.Write($"{cell.PieceOccupyingCell} ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Get the row and column for the piece
        /// </summary>
        internal static Tuple<int, int> GetRowAndCol()
        {
            Console.Write("Enter the row number of the piece: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter the column number of the piece: ");
            int col = int.Parse(Console.ReadLine());

            return Tuple.Create(row, col);
        }
    }
}
