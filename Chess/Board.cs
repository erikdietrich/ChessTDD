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
            if (IsHorizontalPath(origin, destination))
                return IsHorizontalPathBlocked(origin, destination);
            else if (IsVerticalPath(origin, destination))
                return IsVerticalPathBlocked(origin, destination);
            else
                return IsDiagonalPathBlocked(origin, destination);
        }

        private static bool IsHorizontalPath(BoardCoordinate origin, BoardCoordinate destination)
        {
            return origin.Y == destination.Y;
        }

        private static bool IsVerticalPath(BoardCoordinate origin, BoardCoordinate destination)
        {
            return origin.X == destination.X;
        }

        private bool IsHorizontalPathBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var least = Math.Min(origin.X, destination.X);
            var most = Math.Max(origin.X, destination.X);
            var xCoordinatesToCheck = Enumerable.Range(least + 1, most - least);
            return xCoordinatesToCheck.Any(x => GetPiece(BoardCoordinate.For(x, origin.Y)) != null);
        }

        private bool IsVerticalPathBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var least = Math.Min(origin.Y, destination.Y);
            var most = Math.Max(origin.Y, destination.Y);
            var yCoordinatesToCheck = Enumerable.Range(least + 1, most - least);
            return yCoordinatesToCheck.Any(y => GetPiece(BoardCoordinate.For(origin.X, y)) != null);
        }

        private bool IsDiagonalPathBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var spacesToCheck = destination.X - origin.X;
            for(int index = 1; index <= spacesToCheck; index++)
            {
                if (GetPiece(BoardCoordinate.For(origin.X + index, origin.Y + index)) != null)
                    return true;
            }

            spacesToCheck = origin.X - destination.X;
            for (int index = 1; index <= spacesToCheck; index++ )
            {
                if(GetPiece(BoardCoordinate.For(origin.X - index, origin.Y + index)) != null)
                    return true;
            }
                return false;
        }

    }
}
