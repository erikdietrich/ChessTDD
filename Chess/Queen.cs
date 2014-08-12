using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Queen : Piece
    {
        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            var movesWithinABoardSize = GetAllRadialMovesFrom(startingLocation, boardSize);
            return movesWithinABoardSize.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));
        }
    }
}
