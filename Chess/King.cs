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
            var oneSquareAwayMoves = GetAllRadialMovesFrom(startingLocation, boardSize);
            return oneSquareAwayMoves.Where(bc => bc.IsCoordinateValidForBoardSize(boardSize));
        }
    }
}
