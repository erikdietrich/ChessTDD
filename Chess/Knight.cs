using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Piece
    {
        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            var allPotentialMoves = new List<BoardCoordinate>()
            {
                 new BoardCoordinate(startingLocation.X + 2, startingLocation.Y + 1),
                 new BoardCoordinate(startingLocation.X + 2, startingLocation.Y - 1),
                 new BoardCoordinate(startingLocation.X + 1, startingLocation.Y + 2),
                 new BoardCoordinate(startingLocation.X + 1, startingLocation.Y - 2),
                 new BoardCoordinate(startingLocation.X - 2, startingLocation.Y - 1),
                 new BoardCoordinate(startingLocation.X - 2, startingLocation.Y + 1),
                 new BoardCoordinate(startingLocation.X - 1, startingLocation.Y - 2),
                 new BoardCoordinate(startingLocation.X - 1, startingLocation.Y + 2)
            };

            return allPotentialMoves.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));
        }
    }
}
