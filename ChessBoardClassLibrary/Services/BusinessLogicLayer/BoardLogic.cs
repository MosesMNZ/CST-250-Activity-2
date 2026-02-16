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
        private BoardModel ResetBoard(BoardModel board)
        {
            foreach (CellModel cell in board.Grid)
            {
                cell.IsLegalNextMove = false;
                cell.PieceOccupyingCell = "";
            }

            return board;
        }

        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            int size = board.Size;

            bool IsRowSafe = row >= 0 && row < size;
            bool IsColumnSafe = col >= 0 && col < size;

            return IsRowSafe && IsColumnSafe;
        }

        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string chessPiece)
        {
            board = ResetBoard(board);

            switch (chessPiece.ToLower())
            {
                case "knight":
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
