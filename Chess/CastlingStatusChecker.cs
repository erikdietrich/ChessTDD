using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class CastlingStatusChecker
    {
        public static readonly BoardCoordinate WhiteKingStart = BoardCoordinate.For(5, 1);
        public static readonly BoardCoordinate WhiteQueensRookStart = BoardCoordinate.For(1, 1);
        public static readonly BoardCoordinate WhiteKingsRookStart = BoardCoordinate.For(8, 1);

        private readonly Board _board;
        public CastlingStatusChecker(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            _board = board;
        }

        public IEnumerable<BoardCoordinate> GetCastlingMovesFor(BoardCoordinate moveStart)
        {
            var castlingmoves = new List<BoardCoordinate>();

            var kingToMove = _board.GetPiece(moveStart) as King;
            if (kingToMove != null && !kingToMove.HasMoved)
            {
                if (_board.GetPiece(WhiteQueensRookStart) != null && !_board.GetPiece(WhiteQueensRookStart).HasMoved)
                    castlingmoves.Add(BoardCoordinate.For(3, 1));

                if (_board.GetPiece(WhiteKingsRookStart) != null && !_board.GetPiece(WhiteKingsRookStart).HasMoved)
                    castlingmoves.Add(BoardCoordinate.For(7, 1));
            }
            return castlingmoves;
        }
    }
}
