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
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.BuildWhiteRowOne(Target);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Rook_Moves_Contains_1_2()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(1, 1));

            Assert.IsTrue(moves.Any(bc => bc.Matches(1, 2)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Rook_Moves_Does_Not_Contain_2_1()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(1, 1));

            Assert.IsFalse(moves.Any(bc => bc.Matches(2, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void King_Moves_Contains_5_2()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(5, 1));

            Assert.IsTrue(moves.Any(bc => bc.Matches(5, 2)));
        }
    }
}
