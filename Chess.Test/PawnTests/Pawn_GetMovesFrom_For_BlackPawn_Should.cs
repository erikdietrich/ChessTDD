using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.PawnTests
{
    [TestClass]
    public class Pawn_GetMovesFrom_For_BlackPawn_Should
    {
        private Pawn Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesFrom27;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Pawn(false);
            MovesFrom27 = Target.GetMovesFrom(BoardCoordinate.For(2, 7));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Collection_Containing_26()
        {
            Assert.IsTrue(MovesFrom27.Any(bc => bc.Matches(2, 6)));
        }
    }
}
