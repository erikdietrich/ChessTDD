using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class King : Piece
    {
        public King(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<int[]> GetMovesFrom(int x, int y, int boardSize = Board.DefaultBoardSize)
        {
            var oneSquareAwayMoves = GetAllRadialMovesFrom(x, y, 1);
            var validOneSquareAway = oneSquareAwayMoves.Where(bc => IsCoordinateValidForBoardSize(bc[0], bc[1], boardSize));

            if (!HasMoved)
                return validOneSquareAway.Union(new List<int[]>() 
                { 
                    new int[] { x + 2, y },
                    new int[] { x - 2, y }
                });

            return validOneSquareAway;
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}
