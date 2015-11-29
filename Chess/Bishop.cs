using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Piece
    {
        public Bishop(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<int[]> GetMovesFrom(int x, int y, int boardSize = Board.DefaultBoardSize)
        {
            var allDistancesFromStart = Enumerable.Range(1, boardSize + 1);
            var allPossibleBoardCoordinates = allDistancesFromStart.SelectMany(sp => GetRadialDiagonalFrom(x, y, sp));
            var legalBoardCoordinates = allPossibleBoardCoordinates.Where(bc => IsCoordinateValidForBoardSize(bc[0], bc[1], boardSize));
            return legalBoardCoordinates;
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}
