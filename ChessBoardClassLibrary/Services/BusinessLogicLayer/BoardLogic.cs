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

            switch (chessPiece)
            {
                case "Knight":

                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
                    board = MarkValidKnightMoves(board, currentCell);
                    break;

                case "Rook":

                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "R";
                    board = MarkValidRookMoves(board, currentCell);
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                case "King":
                    break;

                default:
                    return board;
            }

            return board;
        }

        private BoardModel MarkValidKnightMoves(BoardModel board, CellModel currentCell)
        {
            int[] knightRowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] knightColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < knightRowMoves.Length; i++)
            {
                if (IsOnBoard(board,
                    currentCell.Row + knightRowMoves[i],
                    currentCell.Column + knightColMoves[i]))
                {
                    board.Grid[currentCell.Row + knightRowMoves[i],
                               currentCell.Column + knightColMoves[i]]
                               .IsLegalNextMove = true;
                }
            }

            return board;
        }

        private BoardModel MarkValidRookMoves(BoardModel board, CellModel currentCell)
        {
            int size = board.Size;

            // Move Up
            for (int row = currentCell.Row - 1; row >= 0; row--)
            {
                board.Grid[row, currentCell.Column].IsLegalNextMove = true;
            }

            // Move Down
            for (int row = currentCell.Row + 1; row < size; row++)
            {
                board.Grid[row, currentCell.Column].IsLegalNextMove = true;
            }

            // Move Left
            for (int col = currentCell.Column - 1; col >= 0; col--)
            {
                board.Grid[currentCell.Row, col].IsLegalNextMove = true;
            }

            // Move Right
            for (int col = currentCell.Column + 1; col < size; col++)
            {
                board.Grid[currentCell.Row, col].IsLegalNextMove = true;
            }

            return board;
        }
    }
}
