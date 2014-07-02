using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.Production
{
    public class King : Piece
    {
        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize)
        {
            var oneSquareAwayMoves = GetAllRadialMovesFrom(startingLocation, boardSize);
            return oneSquareAwayMoves.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));
        }
    }
}
