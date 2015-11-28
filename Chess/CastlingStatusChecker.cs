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

            var queenCastleOption = GetCastleMoveIfAvailable(WhiteQueensRookStart, WhiteCastleMoveQueensSide);
            var kingCastleOption = GetCastleMoveIfAvailable(WhiteKingsRookStart, WhiteCastleMoveKingsSide);

            return queenCastleOption.Union(kingCastleOption);
        }

        private bool IsUnmovedKing(BoardCoordinate moveStart)
        {
            var kingToMove = _board.GetPiece(moveStart.X, moveStart.Y) as King;
            return kingToMove != null && !kingToMove.HasMoved;
        }

        private IEnumerable<BoardCoordinate> GetCastleMoveIfAvailable(BoardCoordinate rookStart, BoardCoordinate moveIfSuccess)
        {
            var piece = _board.GetPiece(rookStart.X, rookStart.Y);
            if (piece != null && !piece.HasMoved)
                yield return moveIfSuccess;
        }
    }
}
