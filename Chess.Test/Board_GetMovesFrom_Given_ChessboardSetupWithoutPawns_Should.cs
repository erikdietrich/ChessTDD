using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class Board_GetMovesFrom_Given_ChessboardSetupWithoutPawns_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.SetupStandardPieces(Target, 1);
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
    }
}
