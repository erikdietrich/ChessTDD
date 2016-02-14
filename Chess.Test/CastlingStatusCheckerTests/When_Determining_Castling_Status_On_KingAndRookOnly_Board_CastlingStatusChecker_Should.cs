using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.CastlingStatusCheckerTests
{
    [TestClass]
    public class When_Determining_Castling_Status_On_KingAndRookOnly_Board_CastlingStatusChecker_Should
    {
        public static readonly BoardCoordinate WhiteKingStart = BoardCoordinate.For(5, 1);
        public static readonly BoardCoordinate WhiteQueensRookStart = BoardCoordinate.For(1, 1);
        public static readonly BoardCoordinate WhiteKingsRookStart = BoardCoordinate.For(8, 1);

        public static readonly BoardCoordinate WhiteCastleMoveQueensSide = BoardCoordinate.For(3, 1);
        public static readonly BoardCoordinate WhiteCastleMoveKingsSide = BoardCoordinate.For(7, 1);

        public static readonly BoardCoordinate BlackKingStart = BoardCoordinate.For(5, 8);
        public static readonly BoardCoordinate BlackQueensRookStart = BoardCoordinate.For(1, 8);
        public static readonly BoardCoordinate BlackKingsRookStart = BoardCoordinate.For(8, 8);

        public static readonly BoardCoordinate BlackCastleMoveQueensSide = BoardCoordinate.For(3, 8);
        public static readonly BoardCoordinate BlackCastleMoveKingsSide = BoardCoordinate.For(7, 8);

        private Board Board { get; set; }

        private CastlingStatusChecker Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Board = new Board();

            Board.AddPiece(new Rook(), WhiteQueensRookStart);
            Board.AddPiece(new Rook(), WhiteKingsRookStart);
            Board.AddPiece(new King(), WhiteKingStart);

            Board.AddPiece(new Rook(false), BlackQueensRookStart);
            Board.AddPiece(new Rook(false), BlackKingsRookStart);
            Board.AddPiece(new King(false), BlackKingStart);

            Target = new CastlingStatusChecker(Board);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Only_WhiteCastleMoveKingSide_When_Black_Queen_Threatens_4_1()
        {
            Board.AddPiece(new Queen(false), BoardCoordinate.For(4, 8));

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(WhiteCastleMoveKingsSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Two_CastlingMoves_For_Black_King_StartSquare_When_Nothing_Has_Moved()
        {
            var movesForBlackKing = Target.GetCastlingMovesFor(BlackKingStart);

            Assert.AreEqual<int>(2, movesForBlackKing.Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_BlackCastleMoveQueensSide_For_Black_King_StartSquare_When_Nothing_Has_Moved()
        {
            var movesForBlackKing = Target.GetCastlingMovesFor(BlackKingStart);

            Assert.IsTrue(movesForBlackKing.Any(bc => bc.Matches(BlackCastleMoveQueensSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_BlackCastleMoveKingsSide_Only_If_Queens_Rook_Has_Moved()
        {
            Board.GetPiece(BlackQueensRookStart).HasMoved = true;

            var movesForBlackKing = Target.GetCastlingMovesFor(BlackKingStart);

            Assert.IsTrue(movesForBlackKing.All(bc => bc.Matches(BlackCastleMoveKingsSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Two_CastlingMoves_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.AreEqual<int>(2, movesForWhiteKing.Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_WhiteCastleMoveQueensSide_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.Matches(WhiteCastleMoveQueensSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_WhiteCastleMoveKingsSide_For_KingStartSquare_When_Nothing_Has_Moved()
        {
            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.Any(bc => bc.Matches(WhiteCastleMoveKingsSide)));
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
            Board.GetPiece(WhiteKingStart).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsFalse(movesForWhiteKing.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_On_Null_ConstructorArgument()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => new CastlingStatusChecker(null));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_WhiteCastleMoveKingsSide_Only_If_QueensRook_Has_Moved()
        {
            Board.GetPiece(WhiteQueensRookStart).HasMoved = true;

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(WhiteCastleMoveKingsSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_WhiteCastleMoveQueensSide_Only_If_KingsRook_Is_Not_There()
        {
            Board.RemovePiece(WhiteKingsRookStart);

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(WhiteCastleMoveQueensSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Only_Return_WhiteCastleMoveKingsSide_If_QueensRook_Is_Not_There()
        {
            Board.RemovePiece(WhiteQueensRookStart);

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(WhiteCastleMoveKingsSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_WhiteCastleMoveQueensSide_Only_When_KingsRook_Is_Blocked()
        {
            Board.AddPiece(new Knight(), WhiteCastleMoveKingsSide);

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(WhiteCastleMoveQueensSide)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_WhiteCastleMoveKingsSide_Only_When_QueensRook_Is_Blocked()
        {
            Board.AddPiece(new Knight(), BoardCoordinate.For(2, 1));

            var movesForWhiteKing = Target.GetCastlingMovesFor(WhiteKingStart);

            Assert.IsTrue(movesForWhiteKing.All(bc => bc.Matches(WhiteCastleMoveKingsSide)));
        }
    }
    
}
