using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Piece
    {
        private int[] _enPassantTarget; 
        private int DirectionalMultiplier { get { return IsFirstPlayerPiece ? 1 : -1; } }

        public Pawn(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<int[]> GetMovesFrom(int x, int y, int boardSize = Board.DefaultBoardSize)
        {
            yield return new int[] { x, y + DirectionalMultiplier };
            if (!HasMoved)
                yield return new int[] { x, y + 2 * DirectionalMultiplier };
            yield return new int[] { x + 1, y + DirectionalMultiplier };
            yield return new int[] { x - 1, y + DirectionalMultiplier };
        }

        public override bool IsCaptureAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            var diagonalMovesFromOrigin = GetRadialDiagonalFrom(originX, originY, 1);

            return diagonalMovesFromOrigin.Any(d => d[0] == destinationX && d[1] == destinationY) && 
                ((IsFirstPlayerPiece && originY < destinationY) || (!IsFirstPlayerPiece && originY > destinationY));
        }

        public override bool IsNonCaptureAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            return IsVerticalMoveBy(1, originX, originY, destinationX, destinationY) || 
                IsSpecialFirstPawnMoveAllowed(originX, originY, destinationX, destinationY) ||
                CanPerformEnPassantOn(destinationX, originY);
        }

        public bool CanPerformEnPassantOn(int x, int y)
        {
            return _enPassantTarget != null && x == _enPassantTarget[0] && y == _enPassantTarget[1];
        }
        public void SetCanPerformEnPassantOn(int x, int y)
        {
            _enPassantTarget = new int[] { x, y };
        }
        public void ClearEnPassant()
        {
            _enPassantTarget = null;
        }
        private bool IsSpecialFirstPawnMoveAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            return !HasMoved && IsVerticalMoveBy(2, originX, originY, destinationX, destinationY);
        }

        private bool IsVerticalMoveBy(int verticalSpaces, int originX, int originY, int destinationX, int destinationY)
        {
            return originY + verticalSpaces * DirectionalMultiplier == destinationY && originX == destinationX;
        }
        
    }
}
