using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class King : Piece
    {
        public King(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            var oneSquareAwayMoves = GetAllRadialMovesFrom(startingLocation, 1);
            var validOneSquareAway = oneSquareAwayMoves.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));

            if (!HasMoved)
                return validOneSquareAway.Union(new List<BoardCoordinate>() 
                { 
                    BoardCoordinate.For(startingLocation.X + 2, startingLocation.Y),
                    BoardCoordinate.For(startingLocation.X - 3, startingLocation.Y)
                });

            return validOneSquareAway;
        }
    }
}
