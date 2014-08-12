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
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 1)).Any());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 1)).Any(bc => bc.X == 2 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_1_For_2_2()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(2, 2)).Any(bc => bc.X == 1 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_1_For_1_2()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 2)).Any(bc => bc.X == 2 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_Negative_Values_For_BoardCoordinates()
            {
                Assert.IsFalse(Target.GetMovesFrom(new BoardCoordinate(1, 2)).Any(bc => bc.Y < 0 || bc.X < 0));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_8_8_For_1_1()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 1)).Any(bc => bc.Y == 8 && bc.X == 8));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_8_1_For_1_8()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 8)).Any(bc => bc.Y == 1 && bc.X == 8));
            }
        }
    }
}
