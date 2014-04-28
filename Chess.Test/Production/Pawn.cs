using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.Production
{
    public class Pawn : Piece
    {
        public bool HasMoved { get; set; }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize)
        {
            yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 1);
            if(!HasMoved)
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 2);
        }
    }
}
