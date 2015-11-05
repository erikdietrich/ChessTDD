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

            Board.AddPiece(new Rook(), CastlingStatusChecker.WhiteQueensRookStart);
            Board.AddPiece(new Rook(), CastlingStatusChecker.WhiteKingsRookStart);
            Board.AddPiece(new King(), CastlingStatusChecker.WhiteKingStart);

            Board.AddPiece(new Rook(false), BoardCoordinate.For(1, 8));
            Board.AddPiece(new Rook(false), BoardCoordinate.For(8, 8));
            Board.AddPiece(new King(false), CastlingStatusChecker.BlackKingStart);

            Target = new CastlingStatusChecker(Board);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Two_CastlingMoves_For_Black_King_StartSquare_When_Nothing_Has_Moved()
        {
            var movesForBlackKing = Target.GetCastlingMovesFor(CastlingStatusChecker.BlackKingStart);

            Assert.AreEqual<int>(2, movesForBlackKing.Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_83_For_Black_King_StartSquare_When_Nothing_Has_Moved()
        {
            var movesForBlackKing = Target.GetCastlingMovesFor(CastlingStatusChecker.BlackKingStart);

            Assert.IsTrue(movesForBlackKing.Any(bc => bc.Matches(3, 8)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_78_Only_If_Queens_Rook_Has_Moved()
        {
            Board.GetPiece(CastlingStatusChecker.BlackQueensRookStart).HasMoved = true;

            var movesForBlackKing = Target.GetCastlingMovesFor(CastlingStatusChecker.BlackKingStart);

            Assert.IsTrue(movesForBlackKing.All(bc => bc.Matches(7, 8)));
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

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.Matches(3, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_17_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.Matches(7, 1)));
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
            Board.GetPiece(CastlingStatusChecker.WhiteKingStart).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsFalse(movesForWhiteKing.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_On_Null_ConstructorArgument()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => new CastlingStatusChecker(null));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_71_Only_If_QueensRook_Has_Moved()
        {
            Board.GetPiece(CastlingStatusChecker.WhiteQueensRookStart).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(7, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_13_Only_If_KingsRook_Is_Not_There()
        {
            Board.RemovePiece(CastlingStatusChecker.WhiteKingsRookStart);

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(3, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Only_Return_17_If_QueensRook_Is_Not_There()
        {
            Board.RemovePiece(CastlingStatusChecker.WhiteQueensRookStart);

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(7, 1)));
        }

    }
    
}
