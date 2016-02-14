using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class CastlingStatusChecker
    {
        private const int QueensRookColumn = 1;
        private const int QueenCastleColumn = 3;
        private const int KingColumn = 5;
        private const int KingCastleColumn = 7;
        private const int KingRookColumn = 8;

        private const int WhiteKingRow = 1;
        private const int BlackKingRow = 8;

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

            return moveStart.Y == WhiteKingRow ? EvaluateRowForCastling(WhiteKingRow) : EvaluateRowForCastling(BlackKingRow);
        }

        private IEnumerable<BoardCoordinate> EvaluateRowForCastling(int row)
        {
            var queenCastleOption = GetCastleMoveIfAvailable(BoardCoordinate.For(QueensRookColumn, row), BoardCoordinate.For(QueenCastleColumn, row));
            var kingCastleOption = GetCastleMoveIfAvailable(BoardCoordinate.For(KingRookColumn, row), BoardCoordinate.For(KingCastleColumn, row));

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
            if (piece != null)
            {
                var kingCoordinate = BoardCoordinate.For(KingColumn, rookStart.Y);
                var pathMaker = new PathMaker(kingCoordinate, rookStart);
                var spacesBetweenKingAndRook = pathMaker.GetPathToDestination().Where(bc => bc.X != rookStart.X && bc.X != KingColumn);

                var threatEvaluator = new ThreatEvaluator(_board);
                var wouldKingBeThreatened = spacesBetweenKingAndRook.Any(bc => threatEvaluator.IsThreatened(bc, piece.IsFirstPlayerPiece));

                var isBlocked = spacesBetweenKingAndRook.Any(bc => _board.GetPiece(bc) != null);

                if (!piece.HasMoved && !isBlocked && !wouldKingBeThreatened)
                    yield return moveIfSuccess;
            }
        }
    }
}
