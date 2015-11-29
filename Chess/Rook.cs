using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Rook : Piece
    {
        public Rook(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<int[]> GetMovesFrom(int x, int y, int boardSize = Board.DefaultBoardSize)
        {
            var availableCoordinates = Enumerable.Range(1, boardSize);

            var verticalMoves = availableCoordinates.Where(y1 => y1 != y).
                Select(y1 => new int[] { x, y1 });

            var horizontalMoves = availableCoordinates.Where(x1 => x1 != x).
                Select(x1 => new int[] { x1, y });

            return verticalMoves.Union(horizontalMoves);
        }
    }
}
