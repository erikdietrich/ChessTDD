using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Board
    {
        public const int DefaultBoardSize = 8;

        private readonly Piece[,] _pieces;

        public int Size { get; } = DefaultBoardSize;

        public int PieceCount => _pieces.Cast<Piece>().Count(p => p != null);

        public Board(int boardSize = DefaultBoardSize)
        {
            VerifyBoardSizeOrThrow(boardSize);

            Size = boardSize;
            _pieces = new Piece[boardSize, boardSize];
        }

        public void AddPiece(Piece piece, BoardCoordinate moveTarget)
        {
            if (piece == null)
                throw new ArgumentNullException("piece");
            if (!moveTarget.IsCoordinateValidForBoardSize(Size))
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

            ReconcileEnPassant(origin, destination, pieceToMove);
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
            var checker = new CastlingStatusChecker(this);
            var castlingMoves = checker.GetCastlingMovesFor(originCoordinate).ToList();
            var allPossibleMoves = piece.GetMovesFrom(originCoordinate).Union(castlingMoves);
            return allPossibleMoves.Where(move => IsMoveLegal(originCoordinate, move) && !IsMoveThreatenedKing(piece, move));
        }

        public bool IsMoveLegal(BoardCoordinate origin, BoardCoordinate destination)
        {
            var isCapture = destination.IsCoordinateValidForBoardSize(Size) && GetPiece(destination) != null;

            var isIllegalCapture = isCapture && !GetPiece(origin).IsCaptureAllowed(origin, destination);
            var isIllegalNonCapture = !isCapture && !GetPiece(origin).IsNonCaptureAllowed(origin, destination);

            return !isIllegalCapture && !isIllegalNonCapture && destination.IsCoordinateValidForBoardSize(Size) &&
                !IsBlocked(origin, destination) && !DoesFriendlyPieceExistAt(origin, destination);
        }

        #region EnPassantStuff
        private void ReconcileEnPassant(BoardCoordinate origin, BoardCoordinate destination, Piece pieceToMove)
        {
            if (IsEnPassantApplicable(origin, destination, pieceToMove))
                SetEnPassantIfCandidatePawnsArePresent(destination);
            CleanEnPassantForPlayerThatJustMoved(pieceToMove);
        }
        private static bool IsEnPassantApplicable(BoardCoordinate origin, BoardCoordinate destination, Piece pieceToMove)
        {
            const int enPassantTrigger = 2;
            var movementFactor = pieceToMove.IsFirstPlayerPiece ? -enPassantTrigger : enPassantTrigger;
            return origin.Y == destination.Y + movementFactor;
        }
        private void SetEnPassantIfCandidatePawnsArePresent(BoardCoordinate destination)
        {
            var leftTarget = BoardCoordinate.For(destination.X - 1, destination.Y);
            var rightTarget = BoardCoordinate.For(destination.X + 1, destination.Y);

            SetEnPassantIfPawnExistsAtTarget(destination, leftTarget);
            SetEnPassantIfPawnExistsAtTarget(destination, rightTarget);
        }

        private void SetEnPassantIfPawnExistsAtTarget(BoardCoordinate destination, BoardCoordinate enPassantTarget)
        {
            if (enPassantTarget.IsCoordinateValidForBoardSize(Size))
            {
                var targetPawn = GetPiece(enPassantTarget) as Pawn;
                targetPawn?.SetCanPerformEnPassantOn(destination);
            }
        }
        private void CleanEnPassantForPlayerThatJustMoved(Piece pieceToMove)
        {
            foreach (var piece in _pieces)
            {
                var pawn = piece as Pawn;
                if (pawn != null && pawn.IsFirstPlayerPiece == pieceToMove.IsFirstPlayerPiece)
                    pawn.ClearEnPassant();
            }
        }
        #endregion

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
            if (coordinates.Any(bc => !bc.IsCoordinateValidForBoardSize(Size)))
                throw new ArgumentException("coordinate");
        }

        private bool IsBlocked(BoardCoordinate origin, BoardCoordinate destination)
        {
            var checker = new PathMaker(origin, destination);
            var spacesAlongPath = checker.GetPathToDestination();
            var lastSpace = spacesAlongPath.LastOrDefault();
            return spacesAlongPath.Any(space => DoesFriendlyPieceExistAt(origin, space)) || spacesAlongPath.Any(space => DoesPieceExistAt(space) && !space.Equals(lastSpace));
        }

        private bool IsMoveThreatenedKing(Piece moveCandidate, BoardCoordinate moveDestination)
        {
            var evaluator = new ThreatEvaluator(this);

            return moveCandidate is King && 
                evaluator.IsThreatened(moveDestination, moveCandidate.IsFirstPlayerPiece);
        }
    }
}