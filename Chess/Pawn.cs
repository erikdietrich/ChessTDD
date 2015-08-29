using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Piece
    {
        private BoardCoordinate? _enPassantTarget; 
        private int DirectionalMultiplier { get { return IsFirstPlayerPiece ? 1 : -1; } }

        public Pawn(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + DirectionalMultiplier);
            if (!HasMoved)
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 2 * DirectionalMultiplier);
            yield return new BoardCoordinate(startingLocation.X + 1, startingLocation.Y + DirectionalMultiplier);
            yield return new BoardCoordinate(startingLocation.X - 1, startingLocation.Y + DirectionalMultiplier);
        }

        public override bool IsCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            var diagonalMovesFromOrigin = GetRadialDiagonalFrom(origin, 1);

            return diagonalMovesFromOrigin.Any(d => d.Matches(destination)) && 
                ((IsFirstPlayerPiece && origin.Y < destination.Y) || (!IsFirstPlayerPiece && origin.Y > destination.Y));
        }

        public override bool IsNonCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return IsVerticalMoveBy(1, origin, destination) || IsSpecialFirstPawnMoveAllowed(origin, destination) ||
                (CanPerformEnPassantOn(BoardCoordinate.For(destination.X, origin.Y)));
        }

        public bool CanPerformEnPassantOn(BoardCoordinate enPassantTarget)
        {
            return _enPassantTarget != null && enPassantTarget.Matches(_enPassantTarget.Value);
        }
        public void SetCanPerformEnPassantOn(BoardCoordinate enPassantTarget)
        {
            _enPassantTarget = enPassantTarget;
        }
        public void ClearEnPassant()
        {
            _enPassantTarget = null;
        }
        private bool IsSpecialFirstPawnMoveAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return !HasMoved && IsVerticalMoveBy(2, origin, destination);
        }

        private bool IsVerticalMoveBy(int verticalSpaces, BoardCoordinate origin, BoardCoordinate destination)
        {
            return origin.Y + verticalSpaces * DirectionalMultiplier == destination.Y && origin.X == destination.X;
        }
        
    }
}
