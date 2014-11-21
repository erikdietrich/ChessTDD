using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            var quadrantsFromASquare = Enumerable.Range(1, 4);
            var allPotentialMoves = quadrantsFromASquare.SelectMany(q => GetQuadrantMoves(startingLocation, q));

            return allPotentialMoves.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));
        }

        private IEnumerable<BoardCoordinate> GetQuadrantMoves(BoardCoordinate coordinate, int quadrant)
        {
            var xMultiplier = quadrant == 1 || quadrant == 4 ? 1 : -1;
            var yMultiplier = quadrant == 1 || quadrant == 2 ? 1 : -1;
            yield return new BoardCoordinate(coordinate.X + 2 * xMultiplier, coordinate.Y + yMultiplier * 1);
            yield return new BoardCoordinate(coordinate.X + 1 * xMultiplier, coordinate.Y + yMultiplier * 2);
        }
    }
}
