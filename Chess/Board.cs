using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Board
    {
        public const int DefaultBoardSize = 8;

        private const int BoardSize = 8;
        private readonly Piece[,] _pieces = new Piece[BoardSize, BoardSize];

        public void AddPiece(Piece piece, BoardCoordinate moveTarget)
        {
            if (!moveTarget.IsCoordinateValidForBoardSize(BoardSize))
                throw new ArgumentException("moveTarget");

            _pieces[moveTarget.X, moveTarget.Y] = piece;
        }

        public Piece GetPiece(BoardCoordinate squareInQuestion)
        {
            return _pieces[squareInQuestion.X, squareInQuestion.Y];
        }


    }
}
