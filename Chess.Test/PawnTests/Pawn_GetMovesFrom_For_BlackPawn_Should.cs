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

        private IEnumerable<int[]> MovesFrom27;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Pawn(false);
            MovesFrom27 = Target.GetMovesFrom(2, 7);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Collection_Containing_26()
        {
            Assert.IsTrue(MovesFrom27.Any(bc => bc[0] == 2 && bc[1] == 6));
        }
    }
}
