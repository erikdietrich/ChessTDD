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

        private IEnumerable<BoardCoordinate> MovesFrom33
        {
            get { return GetMoves(3, 3); }
        }

        private IEnumerable<BoardCoordinate> GetMoves(int x, int y)
        {
            return Target.GetMovesFrom(new BoardCoordinate(x, y));
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

                Assert.IsTrue(moves.Any(bc => bc.X == 3 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_For_1_1()
            {
                var moves = GetMoves(1, 1);

                Assert.IsTrue(moves.Any(bc => bc.X == 2 && bc.Y == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_4_3_For_2_2()
            {
                var moves = GetMoves(2, 2);

                Assert.IsTrue(moves.Any(bc => bc.X == 4 && bc.Y == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_4_For_2_2()
            {
                var moves = GetMoves(2, 2);

                Assert.IsTrue(moves.Any(bc => bc.X == 3 && bc.Y == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_4_1_For_2_2()
            {
                var moves = GetMoves(2, 2);

                Assert.IsTrue(moves.Any(bc => bc.X == 4 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_2_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc.X == 1 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_4_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc.X == 1 && bc.Y == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_1_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc.X == 2 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_5_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc.X == 2 && bc.Y == 5));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_4_1_For_3_3()
            {
                Assert.IsTrue(MovesFrom33.Any(bc => bc.X == 4 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_Illegal_Moves()
            {
                var moves = GetMoves(1, 1);
                Assert.IsFalse(moves.Any(bc => bc.X == -1 && bc.Y == 0));
            }
        }
    }
}
