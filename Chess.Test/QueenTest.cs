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

        private IEnumerable<int[]> MovesFrom11;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Queen();

            MovesFrom11 = Target.GetMovesFrom(1, 1);
        }

        [TestClass]
        public class GetMovesFrom : QueenTest
        {

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_2_For_1_1()
            {
                Assert.IsTrue(MovesFrom11.Any(bc => bc[0] == 1 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                Assert.IsTrue(MovesFrom11.Any(bc => bc[0] == 2 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_3_For_1_1()
            {
                Assert.IsTrue(MovesFrom11.Any(bc => bc[0] == 3 && bc[1] == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_0_0_From_1_1()
            {
                Assert.IsFalse(MovesFrom11.Any(bc => bc[0] == 0 || bc[1] == 0));
            }
        }
    }
}
