using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Rook : Piece
    {
        public Rook(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(int startingLocationX, int startingLocationY, int boardSize = Board.DefaultBoardSize)
        {
            var availableCoordinates = Enumerable.Range(1, boardSize);

            var verticalMoves = availableCoordinates.Where(y => startingLocationY != y).
                Select(y => new BoardCoordinate(startingLocationX, y));

            var horizontalMoves = availableCoordinates.Where(x => startingLocationX != x).
                Select(x => new BoardCoordinate(x, startingLocationY));

            return verticalMoves.Union(horizontalMoves);
        }
    }
}
