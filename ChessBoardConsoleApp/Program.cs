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
            // Print a welcome message
            Console.WriteLine("Hello, Chess Players!");

            // Create board
            BoardModel board = new BoardModel(8);

            // Create logic object
            BoardLogic logic = new BoardLogic();

            Console.WriteLine("Enter Chess Piece (Knight, Rook, Bishop, Queen, King): ");
            string piece = Console.ReadLine();

            Console.WriteLine("Enter Row (0-7): ");
            int row = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Column (0-7): ");
            int col = int.Parse(Console.ReadLine());

            CellModel currentCell = board.Grid[row, col];

            board = logic.MarkLegalMoves(board, currentCell, piece);

            // Call Utility class
            Utility.PrintBoard(board);

            Console.ReadLine();
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
        /// <param name="board"></param>
        internal static void PrintBoard(BoardModel board)
        {
            // Loop over rows
            for (int row = 0; row < board.Size; row++)
            {
                // Loop over columns
                for (int col = 0; col < board.Size; col++)
                {
                    // Get current cell
                    CellModel cell = board.Grid[row, col];

                    // If legal move
                    if (cell.IsLegalNextMove)
                    {
                        Console.Write("+ ");
                    }
                    // If piece exists
                    else if (cell.PieceOccupyingCell != "")
                    {
                        Console.Write($"{cell.PieceOccupyingCell} ");
                    }
                    // Otherwise empty
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
