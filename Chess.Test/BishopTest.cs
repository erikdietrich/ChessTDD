using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class BishopTest
    {
        private Bishop Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Bishop();
        }

        [TestClass]
        public class GetMovesFrom : BishopTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Non_Empty_Collection()
            {
                Assert.IsTrue(Target.GetMovesFrom(1, 1).Any());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                Assert.IsTrue(Target.GetMovesFrom(1, 1).Any(bc => bc[0] == 2 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_1_For_2_2()
            {
                Assert.IsTrue(Target.GetMovesFrom(2, 2).Any(bc => bc[0] == 1 && bc[1] == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_1_For_1_2()
            {
                Assert.IsTrue(Target.GetMovesFrom(1, 2).Any(bc => bc[0] == 2 && bc[1] == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_Negative_Values_For_BoardCoordinates()
            {
                Assert.IsFalse(Target.GetMovesFrom(1, 2).Any(bc => bc[1] < 0 || bc[0] < 0));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_8_8_For_1_1()
            {
                Assert.IsTrue(Target.GetMovesFrom(1, 1).Any(bc => bc[1] == 8 && bc[0] == 8));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_8_1_For_1_8()
            {
                Assert.IsTrue(Target.GetMovesFrom(1, 8).Any(bc => bc[1] == 1 && bc[0] == 8));
            }
        }
    }
}
