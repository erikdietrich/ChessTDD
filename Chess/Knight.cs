using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(int startingLocationX, int startingLocationY, int boardSize = Board.DefaultBoardSize)
        {
            var quadrantsFromASquare = Enumerable.Range(1, 4);
            var allPotentialMoves = quadrantsFromASquare.SelectMany(q => GetQuadrantMoves(BoardCoordinate.For(startingLocationX, startingLocationY), q));

            return allPotentialMoves.Where(bc => IsCoordinateValidForBoardSize(bc.X, bc.Y, boardSize));
        }

        private IEnumerable<BoardCoordinate> GetQuadrantMoves(BoardCoordinate coordinate, int quadrant)
        {
            var xMultiplier = quadrant == 1 || quadrant == 4 ? 1 : -1;
            var yMultiplier = quadrant == 1 || quadrant == 2 ? 1 : -1;
            yield return new BoardCoordinate(coordinate.X + 2 * xMultiplier, coordinate.Y + yMultiplier * 1);
            yield return new BoardCoordinate(coordinate.X + 1 * xMultiplier, coordinate.Y + yMultiplier * 2);
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}
