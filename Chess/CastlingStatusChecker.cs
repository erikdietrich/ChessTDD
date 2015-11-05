using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class CastlingStatusChecker
    {
        public static readonly BoardCoordinate WhiteKingStart = BoardCoordinate.For(5, 1);
        public static readonly BoardCoordinate WhiteQueensRookStart = BoardCoordinate.For(1, 1);
        public static readonly BoardCoordinate WhiteKingsRookStart = BoardCoordinate.For(8, 1);

        public static readonly BoardCoordinate WhiteCastleMoveQueensSide = BoardCoordinate.For(3, 1);
        public static readonly BoardCoordinate WhiteCastleMoveKingsSide = BoardCoordinate.For(7, 1);

        public static readonly BoardCoordinate BlackKingStart = BoardCoordinate.For(5, 8);
        public static readonly BoardCoordinate BlackQueensRookStart = BoardCoordinate.For(1, 8);
        public static readonly BoardCoordinate BlackKingsRookStart = BoardCoordinate.For(8, 8);

        public static readonly BoardCoordinate BlackCastleMoveQueensSide = BoardCoordinate.For(3, 8);
        public static readonly BoardCoordinate BlackCastleMoveKingsSide = BoardCoordinate.For(7, 8);

        private readonly Board _board;
        public CastlingStatusChecker(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            _board = board;
        }

        public IEnumerable<BoardCoordinate> GetCastlingMovesFor(BoardCoordinate moveStart)
        {
            if (!IsUnmovedKing(moveStart))
                return Enumerable.Empty<BoardCoordinate>();

            return moveStart.Y == 1 ? EvaluateRowForCastling(1) : EvaluateRowForCastling(8);
        }

        private IEnumerable<BoardCoordinate> EvaluateRowForCastling(int row)
        {
            var queenCastleOption = GetCastleMoveIfAvailable(BoardCoordinate.For(1, row), BoardCoordinate.For(3, row));
            var kingCastleOption = GetCastleMoveIfAvailable(BoardCoordinate.For(8, row), BoardCoordinate.For(7, row));

            return queenCastleOption.Union(kingCastleOption);
        }

        private bool IsUnmovedKing(BoardCoordinate moveStart)
        {
            var kingToMove = _board.GetPiece(moveStart) as King;
            return kingToMove != null && !kingToMove.HasMoved;
        }

        private IEnumerable<BoardCoordinate> GetCastleMoveIfAvailable(BoardCoordinate rookStart, BoardCoordinate moveIfSuccess)
        {
            var piece = _board.GetPiece(rookStart);
            if (piece != null && !piece.HasMoved)
                yield return moveIfSuccess;
        }
    }
}
