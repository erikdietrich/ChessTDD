using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.CastlingStatusCheckerTests
{
    [TestClass]
    public class When_Determining_Castling_Status_On_KingAndRookOnly_Board_CastlingStatusChecker_Should
    {
        private static readonly BoardCoordinate WhiteKingStart = BoardCoordinate.For(5, 1);

        private Board Board { get; set; }

        private CastlingStatusChecker Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Board = new Board();

            Board.AddPiece(new Rook(), BoardCoordinate.For(1, 1));
            Board.AddPiece(new Rook(), BoardCoordinate.For(8, 1));
            Board.AddPiece(new King(), WhiteKingStart);

            Board.AddPiece(new Rook(false), BoardCoordinate.For(1, 8));
            Board.AddPiece(new Rook(false), BoardCoordinate.For(8, 8));
            Board.AddPiece(new Rook(false), BoardCoordinate.For(5, 8));

            Target = new CastlingStatusChecker(Board);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Two_CastlingMoves_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.AreEqual<int>(2, movesForWhiteKing.Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_13_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.Matches(3, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_17_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.Matches(7, 1)));
        }
    }
    public class CastlingStatusChecker
    {
        private readonly Board _board;
        public CastlingStatusChecker(Board board)
        {
            _board = board;
        }
        public IEnumerable<BoardCoordinate> GetCastlingMovesFor(BoardCoordinate moveStart)
        {
            var pieceAtCoordinate = _board.GetPiece(moveStart) as King;
            var allKingMoves = pieceAtCoordinate.GetMovesFrom(moveStart).ToList();

            return allKingMoves.Where(bc => bc.X == moveStart.X + 2 || bc.X == moveStart.X - 2);
        }
    }
}
