using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class RookTest
    {
        private Rook Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesFrom11;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Rook();
            MovesFrom11 = Target.GetMovesFrom(new BoardCoordinate(1, 1));
        }

        [TestClass]
        public class GetMovesFrom : RookTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_7_Vertical_Moves_With_Board_Size_8()
            {
                Assert.AreEqual<int>(7, MovesFrom11.Where(bc => bc.X == 1).ToList().Count());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_7_Horizontal_Moves_With_Board_Size_8()
            {
                Assert.AreEqual<int>(7, MovesFrom11.Where(bc => bc.Y == 1).Count());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_No_Moves_That_Contain_A_Zero()
            {
                Assert.AreEqual<int>(0, MovesFrom11.Where(bc => bc.X == 0 || bc.Y == 0).Count());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_7_4_From_7_1()
            {
                var moves = Target.GetMovesFrom(new BoardCoordinate(7, 1));

                Assert.IsTrue(moves.Any(bc => bc.X == 7 && bc.Y == 4));
            }
        }
    }
}
