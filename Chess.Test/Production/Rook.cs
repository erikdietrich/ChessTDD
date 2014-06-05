using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.Production
{
    public class Rook : Piece
    {
        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize)
        {
            var availableCoordinates = Enumerable.Range(1, boardSize);

            var verticalMoves = availableCoordinates.Where(y => startingLocation.Y != y).
                Select(y => new BoardCoordinate(startingLocation.X, y));

            var horizontalMoves = availableCoordinates.Where(x => startingLocation.X != x).
                Select(x => new BoardCoordinate(x, startingLocation.Y));

            return verticalMoves.Union(horizontalMoves);
        }
    }
}
