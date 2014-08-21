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

            _pieces[moveTarget.X - 1, moveTarget.Y - 1] = piece;
        }

        public Piece GetPiece(BoardCoordinate squareInQuestion)
        {
            return _pieces[squareInQuestion.X - 1, squareInQuestion.Y - 1];
        }

        public IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate targetCoordinate)
        {
            var piece = _pieces[targetCoordinate.X - 1, targetCoordinate.Y - 1];
            return piece.GetMovesFrom(targetCoordinate);
        }


    }
}
