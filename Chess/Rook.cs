using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Rook : Piece
    {
        public Rook(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
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
