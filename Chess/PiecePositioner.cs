using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class PiecePositioner
    {
        private readonly Board _targetBoard;
        public PiecePositioner(Board target)
        {
            _targetBoard = target;
        }

        public void SetupStandardBoard()
        {
            SetupStandardPieces(1);
            SetupStandardPieces(8, false);
            SetupStandardPawns(2);
            SetupStandardPawns(7, false);

        }
        public void SetupStandardPawns(int row, bool isFirstPlayerPiece = true)
        {
            if(_targetBoard.Size < row)
                throw new ArgumentException("row");

            var xCoordinates = Enumerable.Range(1, 8).ToList();
            xCoordinates.ForEach(xc => _targetBoard.AddPiece(new Pawn(isFirstPlayerPiece), new BoardCoordinate(xc, row)));
        }

        public virtual void SetupStandardPieces(int row, bool isFirstPlayerPiece = true)
        {
            _targetBoard.AddPiece(new Rook(isFirstPlayerPiece), new BoardCoordinate(1, row));
            _targetBoard.AddPiece(new Rook(isFirstPlayerPiece), new BoardCoordinate(8, row));

            _targetBoard.AddPiece(new Knight(isFirstPlayerPiece), new BoardCoordinate(2, row));
            _targetBoard.AddPiece(new Knight(isFirstPlayerPiece), new BoardCoordinate(7, row));

            _targetBoard.AddPiece(new Bishop(isFirstPlayerPiece), new BoardCoordinate(3, row));
            _targetBoard.AddPiece(new Bishop(isFirstPlayerPiece), new BoardCoordinate(6, row));

            _targetBoard.AddPiece(new Queen(isFirstPlayerPiece), new BoardCoordinate(4, row));
            _targetBoard.AddPiece(new King(isFirstPlayerPiece), new BoardCoordinate(5, row));
        }
    }
}
