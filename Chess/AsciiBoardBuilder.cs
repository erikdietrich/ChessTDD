using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class AsciiBoardBuilder
    {
        private readonly Board _board = new Board();

        public Board GenerateBoard()
        {
            return _board;
        }

        public void AddPiece(BoardCoordinate square, string pieceString)
        {
            VerifyNonEmptyPieceStringOrThrow(pieceString);

            var pieceCode = pieceString.Substring(1);
            var playerCode = pieceString[0];
            var isFirstPlayer = DetermineIsFirstPlayer(playerCode);

            var pieceToAdd = BuildPiece(pieceCode, isFirstPlayer);

            _board.AddPiece(pieceToAdd, square);
        }

        private static void VerifyNonEmptyPieceStringOrThrow(string piece)
        {
            if (piece == null)
                throw new ArgumentNullException("piece");

            if (string.IsNullOrEmpty(piece))
                throw new ArgumentException("piece");
        }
        private static bool DetermineIsFirstPlayer(char pieceColorCode)
        {
            if (pieceColorCode != 'W' && pieceColorCode != 'B')
                throw new ArgumentException("Invalid Piece Coloring");

            return pieceColorCode == 'W';
        }

        private Piece BuildPiece(string pieceString, bool isFirstPlayerPiece)
        {
            switch (pieceString)
            {
                case "P": return new Pawn(isFirstPlayerPiece);
                case "B": return new Bishop(isFirstPlayerPiece);
                case "Q": return new Queen(isFirstPlayerPiece);
                case "K": return new King(isFirstPlayerPiece);
                case "R": return new Rook(isFirstPlayerPiece);
                case "Kn": return new Knight(isFirstPlayerPiece);
                default: return null;
            }
        }
    }
}
