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

            string piece = "";
            Tuple<int, int>? result;
            BoardLogic boardLogic = new BoardLogic();

            Console.WriteLine("Hello, Chess Players!");

            // Create board
            BoardModel board = new BoardModel(8);

            // Show empty board
            Utility.PrintBoard(board);

            // Validate chess piece input
            while (true)
            {
                Console.Write("Enter the type of piece (Knight, Rook, Bishop, Queen, King): ");
                piece = Console.ReadLine();

                if (piece.Equals("Knight", StringComparison.OrdinalIgnoreCase) ||
                    piece.Equals("Rook", StringComparison.OrdinalIgnoreCase) ||
                    piece.Equals("Bishop", StringComparison.OrdinalIgnoreCase) ||
                    piece.Equals("Queen", StringComparison.OrdinalIgnoreCase) ||
                    piece.Equals("King", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Console.WriteLine("Invalid piece type. Try again.");
            }

            // Get validated row and column
            result = Utility.GetRowAndCol(board.Size);

            // Mark legal moves
            board = boardLogic.MarkLegalMoves(
                        board,
                        board.Grid[result.Item1, result.Item2],
                        piece);

            // Print updated board
            Utility.PrintBoard(board);

            Console.ReadLine();

            // ---------------------------------------------------------
            // End of Main Method
            // ---------------------------------------------------------
        }
    }

    // ---------------------------------------------------------
    // Utility Class
    // ---------------------------------------------------------
    public static class Utility
    {
        /// <summary>
        /// Print the board with outlines and headers
        /// </summary>
        internal static void PrintBoard(BoardModel board)
        {
            int size = board.Size;

            // Print column headers
            Console.Write("   ");
            for (int col = 0; col < size; col++)
                Console.Write($" {col}  ");
            Console.WriteLine();

            for (int row = 0; row < size; row++)
            {
                // Print horizontal divider
                Console.Write("   ");
                for (int col = 0; col < size; col++)
                    Console.Write("----");
                Console.WriteLine("-");

                // Print row number
                Console.Write($" {row} |");

                for (int col = 0; col < size; col++)
                {
                    CellModel cell = board.Grid[row, col];

                    if (cell.IsLegalNextMove)
                        Console.Write(" + |");
                    else if (cell.PieceOccupyingCell != "")
                        Console.Write($" {cell.PieceOccupyingCell} |");
                    else
                        Console.Write(" . |");
                }

                Console.WriteLine();
            }

            // Bottom border
            Console.Write("   ");
            for (int col = 0; col < size; col++)
                Console.Write("----");
            Console.WriteLine("-");
        }

        /// <summary>
        /// Get row and column with validation
        /// </summary>
        internal static Tuple<int, int> GetRowAndCol(int boardSize)
        {
            int row;
            int col;

            while (true)
            {
                Console.Write("Enter the row number of the piece: ");
                if (!int.TryParse(Console.ReadLine(), out row) ||
                    row < 0 || row >= boardSize)
                {
                    Console.WriteLine("Invalid row. Enter a number between 0 and " + (boardSize - 1));
                    continue;
                }

                Console.Write("Enter the column number of the piece: ");
                if (!int.TryParse(Console.ReadLine(), out col) ||
                    col < 0 || col >= boardSize)
                {
                    Console.WriteLine("Invalid column. Enter a number between 0 and " + (boardSize - 1));
                    continue;
                }

                break;
            }

            return Tuple.Create(row, col);
        }
    }
}
