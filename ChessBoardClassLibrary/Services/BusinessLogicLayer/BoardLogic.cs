/*
 * Moses Muamba-Nzambi
 * CST - 250
 * 02/15/2026
 * Chess Board Project
 * Activity 2
 */

using ChessBoardClassLibrary.Models;

namespace ChessBoardClassLibrary.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        /// <summary>
        /// Reset the board by setting the
        /// cell properties back to default.
        /// </summary>
        private BoardModel ResetBoard(BoardModel board)
        {
            foreach (CellModel cell in board.Grid)
            {
                cell.IsLegalNextMove = false;
                cell.PieceOccupyingCell = "";
            }

            return board;
        }

        /// <summary>
        /// Check if the row/column location is on the board
        /// </summary>
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            int size = board.Size;

            bool IsRowSafe = row >= 0 && row < size;
            bool IsColumnSafe = col >= 0 && col < size;

            return IsRowSafe && IsColumnSafe;
        }

        /// <summary>
        /// Mark the legal moves for the given piece and location
        /// </summary>
        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string chessPiece)
        {
            // Reset the board
            board = ResetBoard(board);

            // Use a switch statement to determine the behavior of the piece
            switch (chessPiece.ToLower())
            {
                case "knight":

                    // Set the occupying property for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";

                    // Set possible moves for knight
                    int[] knightRowMoves = { 2, 2, 1, 1, -1, -1, -2, -2 };
                    int[] knightColMoves = { 1, -1, 2, -2, 2, -2, 1, -1 };

                    // Loop through the knight moves
                    for (int i = 0; i < knightRowMoves.Length; i++)
                    {
                        int newRow = currentCell.Row + knightRowMoves[i];
                        int newCol = currentCell.Column + knightColMoves[i];

                        // Check if move is on the board
                        if (IsOnBoard(board, newRow, newCol))
                        {
                            board.Grid[newRow, newCol].IsLegalNextMove = true;
                        }
                    }

                    break;

                case "rook":
                    break;

                case "bishop":
                    break;

                case "queen":
                    break;

                case "king":
                    break;

                default:
                    return board;
            }

            return board;
        }
    }
}
