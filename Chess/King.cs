using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class King : Piece
    {
        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            var oneSquareAwayMoves = GetAllRadialMovesFrom(startingLocation, boardSize);
            return oneSquareAwayMoves.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));
        }
    }
}
