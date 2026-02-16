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
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "B";
                    board = MarkValidBishopMoves(board, currentCell);
                    break;

                case "Queen":
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "Q";
                    board = MarkValidQueenMoves(board, currentCell);
                    break;

                case "King":
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "K";
                    board = MarkValidKingMoves(board, currentCell);
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
                int newRow = currentCell.Row + knightRowMoves[i];
                int newCol = currentCell.Column + knightColMoves[i];

                if (IsOnBoard(board, newRow, newCol))
                {
                    board.Grid[newRow, newCol].IsLegalNextMove = true;
                }
            }

            return board;
        }

        private BoardModel MarkValidRookMoves(BoardModel board, CellModel currentCell)
        {
            int size = board.Size;

            for (int row = currentCell.Row - 1; row >= 0; row--)
                board.Grid[row, currentCell.Column].IsLegalNextMove = true;

            for (int row = currentCell.Row + 1; row < size; row++)
                board.Grid[row, currentCell.Column].IsLegalNextMove = true;

            for (int col = currentCell.Column - 1; col >= 0; col--)
                board.Grid[currentCell.Row, col].IsLegalNextMove = true;

            for (int col = currentCell.Column + 1; col < size; col++)
                board.Grid[currentCell.Row, col].IsLegalNextMove = true;

            return board;
        }

        private BoardModel MarkValidBishopMoves(BoardModel board, CellModel currentCell)
        {
            int size = board.Size;

            // Top-right
            for (int i = 1; IsOnBoard(board, currentCell.Row - i, currentCell.Column + i); i++)
                board.Grid[currentCell.Row - i, currentCell.Column + i].IsLegalNextMove = true;

            // Top-left
            for (int i = 1; IsOnBoard(board, currentCell.Row - i, currentCell.Column - i); i++)
                board.Grid[currentCell.Row - i, currentCell.Column - i].IsLegalNextMove = true;

            // Bottom-right
            for (int i = 1; IsOnBoard(board, currentCell.Row + i, currentCell.Column + i); i++)
                board.Grid[currentCell.Row + i, currentCell.Column + i].IsLegalNextMove = true;

            // Bottom-left
            for (int i = 1; IsOnBoard(board, currentCell.Row + i, currentCell.Column - i); i++)
                board.Grid[currentCell.Row + i, currentCell.Column - i].IsLegalNextMove = true;

            return board;
        }

        private BoardModel MarkValidQueenMoves(BoardModel board, CellModel currentCell)
        {
            board = MarkValidRookMoves(board, currentCell);
            board = MarkValidBishopMoves(board, currentCell);
            return board;
        }

        private BoardModel MarkValidKingMoves(BoardModel board, CellModel currentCell)
        {
            for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
            {
                for (int colOffset = -1; colOffset <= 1; colOffset++)
                {
                    if (rowOffset == 0 && colOffset == 0)
                        continue;

                    int newRow = currentCell.Row + rowOffset;
                    int newCol = currentCell.Column + colOffset;

                    if (IsOnBoard(board, newRow, newCol))
                        board.Grid[newRow, newCol].IsLegalNextMove = true;
                }
            }

            return board;
        }
    }
}
