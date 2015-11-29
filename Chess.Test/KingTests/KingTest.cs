using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.KingTests
{
    [TestClass]
    public class KingTest
    {
        private King Target { get; set; }

        private IEnumerable<int[]> MovesFrom3_3;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new King();
            MovesFrom3_3 = Target.GetMovesFrom(3, 3);
        }

        [TestClass]
        public class GetMovesFrom : KingTest
        {

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_2_For_1_1()
            {
                var moves = Target.GetMovesFrom(1, 1);

                Assert.IsTrue(moves.Any(bc => bc[0] == 1 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                var moves = Target.GetMovesFrom(1, 1);

                Assert.IsTrue(moves.Any(bc => bc[0] == 2 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_4_For_3_3()
            {
                Assert.IsTrue(MovesFrom3_3.Any(bc => bc[0] == 3 && bc[1] == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_2_For_3_3()
            {
                Assert.IsTrue(MovesFrom3_3.Any(bc => bc[0] == 3 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_For_3_3()
            {
                Assert.IsTrue(MovesFrom3_3.Any(bc => bc[0] == 2 && bc[1] == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_0_0_From_1_1()
            {
                var moves = Target.GetMovesFrom(1, 1);

                Assert.IsFalse(moves.Any(bc => bc[1] == 0 || bc[0] == 0));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_3_5_For_3_3()
            {
                Assert.IsFalse(MovesFrom3_3.Any(bc => bc[0] == 3 && bc[1] == 5));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Has_Seven_Moves_When_Starting_At_Back_End_Of_Board()
            {
                var moves = Target.GetMovesFrom(4, 8);

                Assert.AreEqual<int>(7, moves.Count());
            }
        }
        
    }
}
