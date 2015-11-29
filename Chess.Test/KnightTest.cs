using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class KnightTest
    {
        private Knight Target { get; set; }

        private IEnumerable<int[]> MovesFrom33
        {
            get { return GetMoves(3, 3); }
        }

        private IEnumerable<int[]> GetMoves(int x, int y)
        {
            return Target.GetMovesFrom(x, y);
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Knight();
        }

        [TestClass]
        public class GetMovesFrom : KnightTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_2_For_1_1()
            {
                var moves = GetMoves(1, 1);

                Assert.IsTrue(moves.Any(bc => bc[0] == 3 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_For_1_1()
            {
                var moves = GetMoves(1, 1);

                Assert.IsTrue(moves.Any(bc => bc[0] == 2 && bc[1] == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_4_3_For_2_2()
            {
                var moves = GetMoves(2, 2);

                Assert.IsTrue(moves.Any(bc => bc[0] == 4 && bc[1] == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_4_For_2_2()
            {
                var moves = GetMoves(2, 2);

                Assert.IsTrue(moves.Any(bc => bc[0] == 3 && bc[1] == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_4_1_For_2_2()
            {
                var moves = GetMoves(2, 2);

                Assert.IsTrue(moves.Any(bc => bc[0] == 4 && bc[1] == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_2_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc[0] == 1 && bc[1] == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_4_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc[0] == 1 && bc[1] == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_1_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc[0] == 2 && bc[1] == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_5_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc[0] == 2 && bc[1] == 5));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_4_1_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc[0] == 4 && bc[1] == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_Illegal_Moves()
            {
                var moves = GetMoves(1, 1);
                Assert.IsFalse(moves.Any(bc => bc[0] == -1 && bc[1] == 0));
            }
        }
    }
}
