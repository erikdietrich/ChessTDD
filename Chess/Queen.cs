using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Queen : Piece
    {
        public Queen(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(int startingLocationX, int startingLocationY, int boardSize = Board.DefaultBoardSize)
        {
            var movesWithinABoardSize = GetAllRadialMovesFrom(BoardCoordinate.For(startingLocationX, startingLocationY), boardSize);
            return movesWithinABoardSize.Where(bc => IsCoordinateValidForBoardSize(bc.X, bc.Y, boardSize));
        }

        private static bool IsCoordinateValidForBoardSize(int x, int y, int boardSize)
        {
            return x > 0 && x <= boardSize && y > 0 && y <= boardSize;
        }
    }
}
