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
            if (boardSize <= 0)
                throw new ArgumentException("boardSize");

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
            if(!origin.IsCoordinateValidForBoardSize(_boardSize))
                throw new ArgumentException(nameof(origin));
            if(!destination.IsCoordinateValidForBoardSize(_boardSize))
                throw new ArgumentException(nameof(destination));

            var pieceToMove = GetPiece(origin);
            AddPiece(pieceToMove, destination);
            RemovePiece(origin);
            pieceToMove.HasMoved = true;

            #region EnPassant

            const int enPassantTrigger = 2;
            var movementFactor = pieceToMove.IsFirstPlayerPiece ? -enPassantTrigger : enPassantTrigger;
            if (origin.Y == destination.Y + movementFactor)
            {
                var leftTarget = BoardCoordinate.For(destination.X - 1, destination.Y);
                var rightTarget = BoardCoordinate.For(destination.X + 1, destination.Y);
                if (leftTarget.IsCoordinateValidForBoardSize(_boardSize))
                {
                    var targetPawn = GetPiece(leftTarget) as Pawn;
                    if (targetPawn != null)
                        targetPawn.SetCanPerformEnPassantOn(destination);
                }
                if (rightTarget.IsCoordinateValidForBoardSize(_boardSize))
                {
                    var targetPawn = GetPiece(rightTarget) as Pawn;
                    if (targetPawn != null)
                        targetPawn.SetCanPerformEnPassantOn(destination);
                }
            }
            foreach (var piece in _pieces)
            {
                var pawn = piece as Pawn;
                if (pawn != null && pawn.IsFirstPlayerPiece == pieceToMove.IsFirstPlayerPiece)
                    pawn.ClearEnPassant();
            }

            #endregion
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
            return coordinateToCheck.IsCoordinateValidForBoardSize(_boardSize) && GetPiece(coordinateToCheck) != null;
        }

        public IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate originCoordinate)
        {
            var moves = new List<BoardCoordinate>();
            var pieceAtOrigin = GetPiece(originCoordinate);
            var allPossiblePieceMoves = pieceAtOrigin.GetMovesFrom(originCoordinate);

            foreach (var destinationCoordinate in allPossiblePieceMoves)
            {
                var isCapture = destinationCoordinate.IsCoordinateValidForBoardSize(_boardSize) && GetPiece(destinationCoordinate) != null;

                var isIllegalCapture = isCapture && !GetPiece(originCoordinate).IsCaptureAllowed(originCoordinate, destinationCoordinate);
                var isIllegalNonCapture = !isCapture && !GetPiece(originCoordinate).IsNonCaptureAllowed(originCoordinate, destinationCoordinate);

                var spaces = new List<BoardCoordinate>();
                if (originCoordinate.IsOnSameHorizontalPathAs(destinationCoordinate))
                {
                    if (originCoordinate.X < destinationCoordinate.X)
                    {
                        for (int x = originCoordinate.X + 1; x <= destinationCoordinate.X; x++)
                        {
                            var coordinate = BoardCoordinate.For(x, originCoordinate.Y);
                            spaces.Add(coordinate);
                        }
                    }
                    else
                    {
                        for (int x = originCoordinate.X - 1; x >= destinationCoordinate.X; x--)
                        {
                            var coordinate = BoardCoordinate.For(x, originCoordinate.Y);
                            spaces.Add(coordinate);
                        }
                    }
                }
                else
                    if (originCoordinate.IsOnSameVerticalPathAs(destinationCoordinate))
                {
                    if (originCoordinate.Y < destinationCoordinate.Y)
                    {
                        for (int y = originCoordinate.Y + 1; y <= destinationCoordinate.Y; y++)
                        {
                            var coordinate = BoardCoordinate.For(originCoordinate.X, y);
                            spaces.Add(coordinate);
                        }
                    }
                    else
                    {
                        for (int y = originCoordinate.Y - 1; y >= destinationCoordinate.Y; y--)
                        {
                            var coordinate = BoardCoordinate.For(originCoordinate.X, y);
                            spaces.Add(coordinate);
                        }
                    }
                }
                else
                        if (originCoordinate.IsOnSameDiagonalPathAs(destinationCoordinate))
                {
                    var absoluteDistance = Math.Abs(originCoordinate.X - destinationCoordinate.X);
                    var xDirection = (destinationCoordinate.X - originCoordinate.X) / absoluteDistance;
                    var yDirection = (destinationCoordinate.Y - originCoordinate.Y) / absoluteDistance;
                    for (int i = 1; i <= absoluteDistance; i++)
                    {
                        int xCoordinate = originCoordinate.X + i * xDirection;
                        int yCoordinate = originCoordinate.Y + i * yDirection;
                        var coordinate = BoardCoordinate.For(xCoordinate, yCoordinate);
                        spaces.Add(coordinate);
                    }
                }

                bool isDestinationValidForBoardSize = destinationCoordinate.IsCoordinateValidForBoardSize(_boardSize);
                bool isBlocked = spaces.Any(space => DoesFriendlyPieceExistAt(originCoordinate, space)) || spaces.Any(space => DoesPieceExistAt(space) && !space.Equals(spaces.LastOrDefault()));
                bool friendlyPieceAtDestination = DoesFriendlyPieceExistAt(originCoordinate, destinationCoordinate);

                if (!isIllegalCapture && !isIllegalNonCapture && isDestinationValidForBoardSize && !isBlocked && !friendlyPieceAtDestination)
                {
                    moves.Add(destinationCoordinate);
                }
            }
            return moves;
        }
        private bool DoesFriendlyPieceExistAt(BoardCoordinate origin, BoardCoordinate destination)
        {
            if (!destination.IsCoordinateValidForBoardSize(_boardSize))
                return false;
            var piece = GetPiece(destination);
            return piece != null && piece.IsFirstPlayerPiece == GetPiece(origin).IsFirstPlayerPiece;
        }
        private void SetPiece(Piece piece, BoardCoordinate location)
        {
            _pieces[location.X - 1, location.Y - 1] = piece;
        }
    }
}