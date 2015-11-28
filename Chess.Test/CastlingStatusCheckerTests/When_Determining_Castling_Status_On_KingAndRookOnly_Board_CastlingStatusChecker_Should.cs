using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.CastlingStatusCheckerTests
{
    [TestClass]
    public class When_Determining_Castling_Status_On_KingAndRookOnly_Board_CastlingStatusChecker_Should
    {
        
        private Board Board { get; set; }

        private CastlingStatusChecker Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Board = new Board();

            Board.AddPiece(new Rook(), CastlingStatusChecker.WhiteQueensRookStart.X, CastlingStatusChecker.WhiteQueensRookStart.Y);
            Board.AddPiece(new Rook(), CastlingStatusChecker.WhiteKingsRookStart.X, CastlingStatusChecker.WhiteKingsRookStart.Y);
            Board.AddPiece(new King(), CastlingStatusChecker.WhiteKingStart.X, CastlingStatusChecker.WhiteKingStart.Y);

            Board.AddPiece(new Rook(false),1, 8);
            Board.AddPiece(new Rook(false), 8, 8);
            Board.AddPiece(new Rook(false), 5, 8);

            Target = new CastlingStatusChecker(Board);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Two_CastlingMoves_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.AreEqual<int>(2, movesForWhiteKing.Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_13_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.X == 3 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_17_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.X == 7 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_EmptyEnumeration_For_Unoccupied_Square()
        {
            var movesForUnoccupied = Target.GetCastlingMovesFor(BoardCoordinate.For(3, 3));

            Assert.IsFalse(movesForUnoccupied.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_If_King_Has_Moved()
        {
            Board.GetPiece(CastlingStatusChecker.WhiteKingStart.X, CastlingStatusChecker.WhiteKingStart.Y).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsFalse(movesForWhiteKing.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_On_Null_ConstructorArgument()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => new CastlingStatusChecker(null));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_17_Only_If_QueensRook_Has_Moved()
        {
            Board.GetPiece(CastlingStatusChecker.WhiteQueensRookStart.X, CastlingStatusChecker.WhiteQueensRookStart.Y).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.X == 7 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_13_Only_If_KingsRook_Is_Not_There()
        {
            Board.RemovePiece(CastlingStatusChecker.WhiteKingsRookStart.X, CastlingStatusChecker.WhiteKingsRookStart.Y);

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.X == 3 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Only_Return_17_If_QueensRook_Is_Not_There()
        {
            Board.RemovePiece(CastlingStatusChecker.WhiteQueensRookStart.X, CastlingStatusChecker.WhiteQueensRookStart.Y);

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.X == 7 && bc.Y == 1));
        }
    }
    
}
