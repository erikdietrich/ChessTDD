using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<int[]> GetMovesFrom(int x, int y, int boardSize = Board.DefaultBoardSize)
        {
            var quadrantsFromASquare = Enumerable.Range(1, 4);
            var allPotentialMoves = quadrantsFromASquare.SelectMany(q => GetQuadrantMoves(x, y, q));

            return allPotentialMoves.Where(bc => IsCoordinateValidForBoardSize(bc[0], bc[1], boardSize));
        }

        private IEnumerable<int[]> GetQuadrantMoves(int x, int y, int quadrant)
        {
            var xMultiplier = quadrant == 1 || quadrant == 4 ? 1 : -1;
            var yMultiplier = quadrant == 1 || quadrant == 2 ? 1 : -1;
            yield return new int[] { x + 2 * xMultiplier, y + yMultiplier * 1 };
            yield return new int[] { x + 1 * xMultiplier, y + yMultiplier * 2 };
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}
