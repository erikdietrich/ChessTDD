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

        public void AddPiece(Piece piece, int x, int y)
        {
            if (piece == null)
                throw new ArgumentNullException("piece");
            if (!IsCoordinateValidForBoardSize(x, y, _boardSize))
                throw new ArgumentException("moveTarget");

            SetPiece(piece, x, y);
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

        public IEnumerable<int[]> GetMovesFrom(int x, int y)
        {
            var moves = new List<int[]>();
            var pieceAtOrigin = GetPiece(x, y);
            var allPossiblePieceMoves = pieceAtOrigin.GetMovesFrom(x, y);

            foreach (var destinationCoordinate in allPossiblePieceMoves)
            {
                var isCapture = IsCoordinateValidForBoardSize(destinationCoordinate[0], destinationCoordinate[1], _boardSize) 
                    && GetPiece(destinationCoordinate[0], destinationCoordinate[1]) != null;

                var isIllegalCapture = isCapture && !GetPiece(x, y).
                    IsCaptureAllowed(x, y, destinationCoordinate[0], destinationCoordinate[1]);
                var isIllegalNonCapture = !isCapture && !GetPiece(x, y).
                    IsNonCaptureAllowed(x, y, destinationCoordinate[0], destinationCoordinate[1]);

                var spaces = new List<int[]>();
                if (y == destinationCoordinate[1])
                {
                    if (x < destinationCoordinate[0])
                    {
                        for (int index = x + 1; index <= destinationCoordinate[0]; index++)
                        {
                            var coordinate = new int[] { index, y };
                            spaces.Add(coordinate);
                        }
                    }
                    else
                    {
                        for (int index = x - 1; index >= destinationCoordinate[0]; index--)
                        {
                            var coordinate = new int[] { index, y };
                            spaces.Add(coordinate);
                        }
                    }
                }
                else if (x == destinationCoordinate[0])
                {
                    if (y < destinationCoordinate[1])
                    {
                        for (int index = y + 1; index <= destinationCoordinate[1]; index++)
                        {
                            var coordinate = new int[] { x, index };
                            spaces.Add(coordinate);
                        }
                    }
                    else
                    {
                        for (int index = y - 1; index >= destinationCoordinate[1]; index--)
                        {
                            var coordinate = new int[] { x, index };
                            spaces.Add(coordinate);
                        }
                    }
                }
                else if (Math.Abs(x - destinationCoordinate[0]) == Math.Abs(y - destinationCoordinate[1]))
                {
                    var absoluteDistance = Math.Abs(x - destinationCoordinate[0]);
                    var xDirection = (destinationCoordinate[0] - x) / absoluteDistance;
                    var yDirection = (destinationCoordinate[1] - y) / absoluteDistance;
                    for (int i = 1; i <= absoluteDistance; i++)
                    {
                        int xCoordinate = x + i * xDirection;
                        int yCoordinate = y + i * yDirection;
                        var coordinate = new int[] { xCoordinate, yCoordinate };
                        spaces.Add(coordinate);
                    }
                }

                bool isDestinationValidForBoardSize = IsCoordinateValidForBoardSize(destinationCoordinate[0], destinationCoordinate[1], _boardSize);
                bool isBlocked = spaces.Any(space => DoesFriendlyPieceExistAt(x, y, space[0], space[1])) || 
                    spaces.Any(space => DoesPieceExistAt(space[0], space[1]) && !space.Equals(spaces.LastOrDefault()));

                bool friendlyPieceAtDestination = DoesFriendlyPieceExistAt(x, y, destinationCoordinate[0], destinationCoordinate[1]);

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
        private void SetPiece(Piece piece, int x, int y)
        {
            _pieces[x - 1, y - 1] = piece;
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}