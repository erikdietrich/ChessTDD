using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_ChessboardSetupWithoutPawns_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            var positioner = new PiecePositioner(Target);
            positioner.SetupStandardPieces(1);
            positioner.SetupStandardPieces(8, false);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Should_Return_Rook_Moves_Containing_1_2()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(1, 1));

            Assert.IsTrue(moves.Any(bc => bc.Matches(1, 2)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Should_Return_Rook_Moves_Not_Containing_2_1()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(1, 1));

            Assert.IsFalse(moves.Any(bc => bc.Matches(2, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Should_Return_King_Moves_Containing_5_2()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(5, 1));

            Assert.IsTrue(moves.Any(bc => bc.Matches(5, 2)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_For_Bishop_After_Blocking_Pawns_Are_Added()
        {
            Target.AddPiece(new Pawn(), BoardCoordinate.For(2, 2));
            Target.AddPiece(new Pawn(), BoardCoordinate.For(4, 2));

            var moves = Target.GetMovesFrom(BoardCoordinate.For(3, 1));

            Assert.IsFalse(moves.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Moves_For_Bishop_That_Is_Not_Blocked()
        {
            Target.AddPiece(new Pawn(), BoardCoordinate.For(2, 2));
            var moves = Target.GetMovesFrom(BoardCoordinate.For(3, 1));

            Assert.IsTrue(moves.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_NonEmpty_For_Bishop_At_3_8()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(3, 8));

            Assert.IsTrue(moves.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_For_Bishop_at_3_8_When_Blocked()
        {
            Target.AddPiece(new Pawn(false), BoardCoordinate.For(2, 7));
            Target.AddPiece(new Pawn(false), BoardCoordinate.For(4, 7));

            var moves = Target.GetMovesFrom(BoardCoordinate.For(3, 8));

            Assert.IsFalse(moves.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Allow_Rook_At_11_To_Move_To_Capture_Rook_At_18()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(1, 1));

            Assert.IsTrue(moves.Any(m => m.Matches(1, 8)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Allow_Rook_At_11_To_Capture_Rook_At_18_When_A_Pawn_Is_In_Front_Of_It()
        {
            Target.AddPiece(new Pawn(false), BoardCoordinate.For(1, 7));

            var moves = Target.GetMovesFrom(BoardCoordinate.For(1, 1));

            Assert.IsFalse(moves.Any(m => m.Matches(1, 8)));
        }
    }
}
