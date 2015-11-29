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

        public override IEnumerable<int[]> GetMovesFrom(int startingLocationX, int startingLocationY, int boardSize = Board.DefaultBoardSize)
        {
            yield return new int[] { startingLocationX, startingLocationY + DirectionalMultiplier };
            if (!HasMoved)
                yield return new int[] { startingLocationX, startingLocationY + 2 * DirectionalMultiplier };
            yield return new int[] { startingLocationX + 1, startingLocationY + DirectionalMultiplier };
            yield return new int[] { startingLocationX - 1, startingLocationY + DirectionalMultiplier };
        }

        public override bool IsCaptureAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            var diagonalMovesFromOrigin = GetRadialDiagonalFrom(originX, originY, 1);

            return diagonalMovesFromOrigin.Any(d => d[0] == destinationX && d[1] == destinationY) && 
                ((IsFirstPlayerPiece && originY < destinationY) || (!IsFirstPlayerPiece && originY > destinationY));
        }

        public override bool IsNonCaptureAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            return IsVerticalMoveBy(1, BoardCoordinate.For(originX, originY), BoardCoordinate.For(destinationX, destinationY)) || IsSpecialFirstPawnMoveAllowed(BoardCoordinate.For(originX, originY), BoardCoordinate.For(destinationX, destinationY)) ||
                (CanPerformEnPassantOn(BoardCoordinate.For(destinationX, originY)));
        }

        public bool CanPerformEnPassantOn(BoardCoordinate enPassantTarget)
        {
            return _enPassantTarget != null && enPassantTarget.X == _enPassantTarget.Value.X && enPassantTarget.Y == _enPassantTarget.Value.Y;
        }
        public void SetCanPerformEnPassantOn(int enPassantTargetX, int enPassantTargetY)
        {
            _enPassantTarget = BoardCoordinate.For(enPassantTargetX, enPassantTargetY);
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
