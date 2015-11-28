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

        public void AddPiece(Piece piece, int moveTargetX, int moveTargetY)
        {
            if (piece == null)
                throw new ArgumentNullException("piece");
            if (!IsCoordinateValidForBoardSize(moveTargetX, moveTargetY, _boardSize))
                throw new ArgumentException("moveTarget");

            SetPiece(piece, moveTargetX, moveTargetY);
        }

        public void MovePiece(int originX, int originY, int destinationX, int destinationY)
        {
            if(!IsCoordinateValidForBoardSize(originX, originY, _boardSize))
                throw new ArgumentException("origin");
            if(!IsCoordinateValidForBoardSize(destinationX, destinationY, _boardSize))
                throw new ArgumentException("destination");

            var pieceToMove = GetPiece(originX, originY);
            AddPiece(pieceToMove, destinationX, destinationY);
            RemovePiece(originX, originY);
            pieceToMove.HasMoved = true;

            #region EnPassant

            const int enPassantTrigger = 2;
            var movementFactor = pieceToMove.IsFirstPlayerPiece ? -enPassantTrigger : enPassantTrigger;
            if (originY == destinationY + movementFactor)
            {
                if (IsCoordinateValidForBoardSize(destinationX - 1, destinationY, _boardSize))
                {
                    var targetPawn = GetPiece(destinationX - 1, destinationY) as Pawn;
                    if (targetPawn != null)
                        targetPawn.SetCanPerformEnPassantOn(destinationX, destinationY);
                }
                if (IsCoordinateValidForBoardSize(destinationX + 1, destinationY, _boardSize))
                {
                    var targetPawn = GetPiece(destinationX + 1, destinationY) as Pawn;
                    if (targetPawn != null)
                        targetPawn.SetCanPerformEnPassantOn(destinationX, destinationY);
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

        public void RemovePiece(int x, int y)
        {
            if (!DoesPieceExistAt(x, y))
                throw new ArgumentException("coordinateForRemoval");

            SetPiece(null, x, y);
        }

        public Piece GetPiece(int x, int y)
        {
            return _pieces[x - 1, y - 1];
        }

        public bool DoesPieceExistAt(int x, int y)
        {
            return IsCoordinateValidForBoardSize(x, y, _boardSize) && GetPiece(x, y) != null;
        }

        public IEnumerable<BoardCoordinate> GetMovesFrom(int originCoordinateX, int originCoordinateY)
        {
            var moves = new List<BoardCoordinate>();
            var pieceAtOrigin = GetPiece(originCoordinateX, originCoordinateY);
            var allPossiblePieceMoves = pieceAtOrigin.GetMovesFrom(originCoordinateX, originCoordinateY);

            foreach (var destinationCoordinate in allPossiblePieceMoves)
            {
                var isCapture = IsCoordinateValidForBoardSize(destinationCoordinate.X, destinationCoordinate.Y, _boardSize) && GetPiece(destinationCoordinate.X, destinationCoordinate.Y) != null;

                var isIllegalCapture = isCapture && !GetPiece(originCoordinateX, originCoordinateY).IsCaptureAllowed(originCoordinateX, originCoordinateY, destinationCoordinate.X, destinationCoordinate.Y);
                var isIllegalNonCapture = !isCapture && !GetPiece(originCoordinateX, originCoordinateY).IsNonCaptureAllowed(originCoordinateX, originCoordinateY, destinationCoordinate.X, destinationCoordinate.Y);

                var spaces = new List<BoardCoordinate>();
                if (originCoordinateY == destinationCoordinate.Y)
                {
                    if (originCoordinateX < destinationCoordinate.X)
                    {
                        for (int x = originCoordinateX + 1; x <= destinationCoordinate.X; x++)
                        {
                            var coordinate = BoardCoordinate.For(x, originCoordinateY);
                            spaces.Add(coordinate);
                        }
                    }
                    else
                    {
                        for (int x = originCoordinateX - 1; x >= destinationCoordinate.X; x--)
                        {
                            var coordinate = BoardCoordinate.For(x, originCoordinateY);
                            spaces.Add(coordinate);
                        }
                    }
                }
                else if (originCoordinateX == destinationCoordinate.X)
                {
                    if (originCoordinateY < destinationCoordinate.Y)
                    {
                        for (int y = originCoordinateY + 1; y <= destinationCoordinate.Y; y++)
                        {
                            var coordinate = BoardCoordinate.For(originCoordinateX, y);
                            spaces.Add(coordinate);
                        }
                    }
                    else
                    {
                        for (int y = originCoordinateY - 1; y >= destinationCoordinate.Y; y--)
                        {
                            var coordinate = BoardCoordinate.For(originCoordinateX, y);
                            spaces.Add(coordinate);
                        }
                    }
                }
                else if (Math.Abs(originCoordinateX - destinationCoordinate.X) == Math.Abs(originCoordinateY - destinationCoordinate.Y))
                {
                    var absoluteDistance = Math.Abs(originCoordinateX - destinationCoordinate.X);
                    var xDirection = (destinationCoordinate.X - originCoordinateX) / absoluteDistance;
                    var yDirection = (destinationCoordinate.Y - originCoordinateY) / absoluteDistance;
                    for (int i = 1; i <= absoluteDistance; i++)
                    {
                        int xCoordinate = originCoordinateX + i * xDirection;
                        int yCoordinate = originCoordinateY + i * yDirection;
                        var coordinate = BoardCoordinate.For(xCoordinate, yCoordinate);
                        spaces.Add(coordinate);
                    }
                }

                bool isDestinationValidForBoardSize = IsCoordinateValidForBoardSize(destinationCoordinate.X, destinationCoordinate.Y, _boardSize);
                bool isBlocked = spaces.Any(space => DoesFriendlyPieceExistAt(originCoordinateX, originCoordinateY, space.X, space.Y)) || spaces.Any(space => DoesPieceExistAt(space.X, space.Y) && !space.Equals(spaces.LastOrDefault()));
                bool friendlyPieceAtDestination = DoesFriendlyPieceExistAt(originCoordinateX, originCoordinateY, destinationCoordinate.X, destinationCoordinate.Y);

                if (!isIllegalCapture && !isIllegalNonCapture && isDestinationValidForBoardSize && !isBlocked && !friendlyPieceAtDestination)
                {
                    moves.Add(destinationCoordinate);
                }
            }
            return moves;
        }
        private bool DoesFriendlyPieceExistAt(int originX, int originY, int destinationX, int destinationY)
        {
            if (!IsCoordinateValidForBoardSize(destinationX, destinationY, _boardSize))
                return false;
            var piece = GetPiece(destinationX, destinationY);
            return piece != null && piece.IsFirstPlayerPiece == GetPiece(originX, originY).IsFirstPlayerPiece;
        }
        private void SetPiece(Piece piece, int locationX, int locationY)
        {
            _pieces[locationX - 1, locationY - 1] = piece;
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}