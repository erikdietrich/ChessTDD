using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Board
    {
        public const int DefaultBoardSize = 8;

        private readonly int _boardSize;
        private readonly Piece[,] _pieces;

        public Board(int boardSize = DefaultBoardSize)
        {
            VerifyBoardSizeOrThrow(boardSize);

            _boardSize = boardSize;
            _pieces = new Piece[boardSize, boardSize];
        }

        public void AddPiece(Piece piece, BoardCoordinate moveTarget)
        {
            if(piece == null)
                throw new ArgumentNullException("piece");
            if (!moveTarget.IsCoordinateValidForBoardSize(_boardSize))
                throw new ArgumentException("moveTarget");

            SetPiece(piece, moveTarget);
        }

        public void MovePiece(BoardCoordinate origin, BoardCoordinate destination)
        {
            VerifyCoordinatesOrThrow(origin, destination);

            var pieceToMove = GetPiece(origin);
            AddPiece(pieceToMove, destination);
            RemovePiece(origin);
        }

        public void RemovePiece(BoardCoordinate coordinateForRemoval)
        {
            if(!DoesPieceExistAt(coordinateForRemoval))
                throw new ArgumentException("coordinateForRemoval");

            SetPiece(null, coordinateForRemoval);
        }

        public Piece GetPiece(BoardCoordinate coordinateToRetrieve)
        {
            return _pieces[coordinateToRetrieve.X - 1, coordinateToRetrieve.Y - 1];
        }

        public bool DoesPieceExistAt(BoardCoordinate coordinateToCheck)
        {
            return GetPiece(coordinateToCheck) != null;
        }

        public IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate originCoordinate)
        {
            var piece = GetPiece(originCoordinate);
            var allPossibleMoves = piece.GetMovesFrom(originCoordinate);
            return allPossibleMoves.Where(move => !IsBlocked(originCoordinate, move));
        }

        private static void VerifyBoardSizeOrThrow(int boardSize)
        {
            if (boardSize <= 0)
                throw new ArgumentException("boardSize");
        }
        private void SetPiece(Piece piece, BoardCoordinate location) 
        {
            _pieces[location.X - 1, location.Y - 1] = piece;
        }

        private void VerifyCoordinatesOrThrow(params BoardCoordinate[] coordinates)
        {
            if(coordinates.Any(bc => !bc.IsCoordinateValidForBoardSize(_boardSize)))
                throw new ArgumentException("coordinate");
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
            return xCoordinatesToCheck.Any(x => DoesPieceExistAt(BoardCoordinate.For(x, origin.Y)));
        }

        private bool IsVerticalPathBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var least = Math.Min(origin.Y, destination.Y);
            var most = Math.Max(origin.Y, destination.Y);
            var yCoordinatesToCheck = Enumerable.Range(least + 1, most - least);
            return yCoordinatesToCheck.Any(y => DoesPieceExistAt(BoardCoordinate.For(origin.X, y)));
        }

        private bool IsDiagonalPathBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var absoluteDistance = Math.Abs(origin.X - destination.X);
            var xDirection = (destination.X - origin.X) / absoluteDistance;
            var yDirection = (destination.Y - origin.Y) / absoluteDistance;

            return IsDirectedDiagonalPathBlocked(origin, absoluteDistance, xDirection, yDirection);
        }

        private bool IsDirectedDiagonalPathBlocked(BoardCoordinate origin, int spacesToCheck, int xDirection, int yDirection)
        {
            var spacesOnTheBoardToCheck = Enumerable.Range(1, spacesToCheck).
                Select(i => BoardCoordinate.For(origin.X + i * xDirection, origin.Y + i * yDirection));

            return spacesOnTheBoardToCheck.Any(bc => DoesPieceExistAt(bc));
        }

    }
}
