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

        public int Size { get { return _boardSize; } }

        public int PieceCount 
        { 
            get
            {
                return _pieces.Cast<Piece>().Count(p => p != null);
            }
        }

        public Board(int boardSize = DefaultBoardSize)
        {
            VerifyBoardSizeOrThrow(boardSize);

            _boardSize = boardSize;
            _pieces = new Piece[boardSize, boardSize];
        }

        public void AddPiece(Piece piece, BoardCoordinate moveTarget)
        {
            if (piece == null)
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
            pieceToMove.HasMoved = true;
        }

        public void RemovePiece(BoardCoordinate coordinateForRemoval)
        {
            if (!DoesPieceExistAt(coordinateForRemoval))
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
            return allPossibleMoves.Where(move => IsMoveLegal(originCoordinate, move));
        }

        private bool IsMoveLegal(BoardCoordinate origin, BoardCoordinate destination)
        {
            return destination.IsCoordinateValidForBoardSize(_boardSize) && !IsBlocked(origin, destination) &&
                    !DoesFriendlyPieceExistAt(origin, destination);
        }
        private bool DoesFriendlyPieceExistAt(BoardCoordinate origin, BoardCoordinate destination)
        {
            var piece = GetPiece(destination);
            return piece != null && piece.IsFirstPlayerPiece == GetPiece(origin).IsFirstPlayerPiece;
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
            if (coordinates.Any(bc => !bc.IsCoordinateValidForBoardSize(_boardSize)))
                throw new ArgumentException("coordinate");
        }

        private bool IsBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var checker = new PathMaker(origin, destination);
            var spacesAlongPath = checker.GetPathToDestination();
            var lastSpace = spacesAlongPath.LastOrDefault();
            return spacesAlongPath.Any(space => DoesFriendlyPieceExistAt(origin, space)) || spacesAlongPath.Any(space => DoesPieceExistAt(space) && !space.Equals(lastSpace));
        }

    }
}