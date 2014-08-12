using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class QueenTest
    {
        private Queen Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesFrom11;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Queen();

            MovesFrom11 = Target.GetMovesFrom(new BoardCoordinate(1, 1));
        }

        [TestClass]
        public class GetMovesFrom : QueenTest
        {

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_2_For_1_1()
            {
                Assert.IsTrue(MovesFrom11.Any(bc => bc.X == 1 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                Assert.IsTrue(MovesFrom11.Any(bc => bc.X == 2 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_3_For_1_1()
            {
                Assert.IsTrue(MovesFrom11.Any(bc => bc.X == 3 && bc.Y == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_0_0_From_1_1()
            {
                Assert.IsFalse(MovesFrom11.Any(bc => bc.X == 0 || bc.Y == 0));
            }
        }
    }
}
