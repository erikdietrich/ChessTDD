using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.Production
{
    public abstract class Piece
    {
        public abstract IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize);
    }
}
