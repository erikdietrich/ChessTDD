using Chess.Test.Production;
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

        private static readonly BoardCoordinate DefaultCoordinate = new BoardCoordinate(1, 1);
        private const int DefaultBoardSize = 8;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Rook();
        }

        [TestClass]
        public class GetMovesFrom : RookTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_7_Vertical_Moves_With_Board_Size_8()
            {
                var moves = Target.GetMovesFrom(DefaultCoordinate, DefaultBoardSize);

                Assert.AreEqual<int>(7, moves.Where(bc => bc.X == 1).ToList().Count());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_7_Horizontal_Moves_With_Board_Size_8()
            {
                var moves = Target.GetMovesFrom(DefaultCoordinate, DefaultBoardSize);

                Assert.AreEqual<int>(7, moves.Where(bc => bc.Y == 1).Count());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_No_Moves_That_Contain_A_Zero()
            {
                var moves = Target.GetMovesFrom(DefaultCoordinate, DefaultBoardSize);

                Assert.AreEqual<int>(0, moves.Where(bc => bc.X == 0 || bc.Y == 0).Count());
            }
        }
    }
}
