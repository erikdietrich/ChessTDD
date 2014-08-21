using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Board
    {
        public const int DefaultBoardSize = 8;

        private const int BoardSize = 8;
        private readonly Piece[,] _pieces = new Piece[BoardSize, BoardSize];

        public void AddPiece(Piece piece, BoardCoordinate moveTarget)
        {
            if (!moveTarget.IsCoordinateValidForBoardSize(BoardSize))
                throw new ArgumentException("moveTarget");

            _pieces[moveTarget.X - 1, moveTarget.Y - 1] = piece;
        }

        public Piece GetPiece(BoardCoordinate squareInQuestion)
        {
            return _pieces[squareInQuestion.X - 1, squareInQuestion.Y - 1];
        }

        public IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate originCoordinate)
        {
            var piece = _pieces[originCoordinate.X - 1, originCoordinate.Y - 1];
            var allPossibleMoves = piece.GetMovesFrom(originCoordinate);
            return allPossibleMoves.Where(move => !IsBlocked(originCoordinate, move));
        }

        private bool IsBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            return IsBlockedHorizontalMove(destination, origin) || IsBlockedVerticalMove(destination, origin);
        }

        private bool IsBlockedHorizontalMove(BoardCoordinate origin, BoardCoordinate destination)
        {
            var startX = Math.Min(origin.X, destination.X);
            var endX = Math.Max(origin.X, destination.X);

            return Enumerable.Range(startX + 1, endX - startX).Any(i => GetPiece(BoardCoordinate.For(i, origin.Y)) != null);
        }

        private bool IsBlockedVerticalMove(BoardCoordinate origin, BoardCoordinate destination)
        {
            var startY = Math.Min(origin.Y, destination.Y);
            var endY = Math.Max(origin.Y, destination.Y);

            return Enumerable.Range(startY + 1, endY - startY). Any(i => GetPiece(BoardCoordinate.For(origin.X, i)) != null);
        }

    }
}
