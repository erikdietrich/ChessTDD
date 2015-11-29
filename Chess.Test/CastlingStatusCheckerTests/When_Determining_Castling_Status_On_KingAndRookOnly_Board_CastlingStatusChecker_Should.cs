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

            Board.AddPiece(new Rook(), CastlingStatusChecker.WhiteQueensRookStart[0], CastlingStatusChecker.WhiteQueensRookStart[1]);
            Board.AddPiece(new Rook(), CastlingStatusChecker.WhiteKingsRookStart[0], CastlingStatusChecker.WhiteKingsRookStart[1]);
            Board.AddPiece(new King(), CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Board.AddPiece(new Rook(false),1, 8);
            Board.AddPiece(new Rook(false), 8, 8);
            Board.AddPiece(new Rook(false), 5, 8);

            Target = new CastlingStatusChecker(Board);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Two_CastlingMoves_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Assert.AreEqual<int>(2, movesForWhiteKing.Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_13_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc[0] == 3 && bc[1] == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_17_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc[0] == 7 && bc[1] == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_EmptyEnumeration_For_Unoccupied_Square()
        {
            var movesForUnoccupied = Target.GetCastlingMovesFor(3, 3);

            Assert.IsFalse(movesForUnoccupied.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_If_King_Has_Moved()
        {
            Board.GetPiece(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

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
            Board.GetPiece(CastlingStatusChecker.WhiteQueensRookStart[0], CastlingStatusChecker.WhiteQueensRookStart[1]).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc[0] == 7 && bc[1] == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_13_Only_If_KingsRook_Is_Not_There()
        {
            Board.RemovePiece(CastlingStatusChecker.WhiteKingsRookStart[0], CastlingStatusChecker.WhiteKingsRookStart[1]);

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc[0] == 3 && bc[1] == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Only_Return_17_If_QueensRook_Is_Not_There()
        {
            Board.RemovePiece(CastlingStatusChecker.WhiteQueensRookStart[0], CastlingStatusChecker.WhiteQueensRookStart[1]);

            var movesForWhiteKing = Target.GetCastlingMovesFor(CastlingStatusChecker.WhiteKingStart[0], CastlingStatusChecker.WhiteKingStart[1]);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc[0] == 7 && bc[1] == 1));
        }
    }
    
}
