using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class CastlingStatusChecker
    {
        public static readonly int[] WhiteKingStart = new int[] { 5, 1 };
        public static readonly int[] WhiteQueensRookStart = new int[] { 1, 1 };
        public static readonly int[] WhiteKingsRookStart = new int[] { 8, 1 };

        public static readonly int[] WhiteCastleMoveQueensSide = new int[] { 3, 1 };
        public static readonly int[] WhiteCastleMoveKingsSide = new int[] { 7, 1 };

        private readonly Board _board;
        public CastlingStatusChecker(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            _board = board;
        }

        public IEnumerable<int[]> GetCastlingMovesFor(int x, int y)
        {
            if (!IsUnmovedKing(x, y))
                return Enumerable.Empty<int[]>();

            var queenCastleOption = GetCastleMoveIfAvailable(WhiteQueensRookStart[0], WhiteQueensRookStart[1], WhiteCastleMoveQueensSide[0], WhiteCastleMoveQueensSide[1]);
            var kingCastleOption = GetCastleMoveIfAvailable(WhiteKingsRookStart[0], WhiteKingsRookStart[1], WhiteCastleMoveKingsSide[0], WhiteCastleMoveKingsSide[1]);

            return queenCastleOption.Union(kingCastleOption);
        }

        private bool IsUnmovedKing(int x, int y)
        {
            var kingToMove = _board.GetPiece(x, y) as King;
            return kingToMove != null && !kingToMove.HasMoved;
        }

        private IEnumerable<int[]> GetCastleMoveIfAvailable(int rookStartX, int rookStartY, int moveIfSuccessX, int moveIfSuccessY)
        {
            var piece = _board.GetPiece(rookStartX, rookStartY);
            if (piece != null && !piece.HasMoved)
                yield return new int[] { moveIfSuccessX, moveIfSuccessY };
        }
    }
}
