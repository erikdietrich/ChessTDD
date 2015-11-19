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

        private IEnumerable<BoardCoordinate> MovesFrom3_3;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new King();
            MovesFrom3_3 = Target.GetMovesFrom(new BoardCoordinate(3, 3));
        }

        [TestClass]
        public class GetMovesFrom : KingTest
        {

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_2_For_1_1()
            {
                var moves = Target.GetMovesFrom(new BoardCoordinate(1, 1));

                Assert.IsTrue(moves.Any(bc => bc.X == 1 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                var moves = Target.GetMovesFrom(new BoardCoordinate(1, 1));

                Assert.IsTrue(moves.Any(bc => bc.X == 2 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_4_For_3_3()
            {
                Assert.IsTrue(MovesFrom3_3.Any(bc => bc.X == 3 && bc.Y == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_3_2_For_3_3()
            {
                Assert.IsTrue(MovesFrom3_3.Any(bc => bc.X == 3 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_For_3_3()
            {
                Assert.IsTrue(MovesFrom3_3.Any(bc => bc.X == 2 && bc.Y == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_0_0_From_1_1()
            {
                var moves = Target.GetMovesFrom(new BoardCoordinate(1, 1));

                Assert.IsFalse(moves.Any(bc => bc.Y == 0 || bc.X == 0));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_3_5_For_3_3()
            {
                Assert.IsFalse(MovesFrom3_3.Any(bc => bc.X == 3 && bc.Y == 5));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Has_Five_Moves_When_Starting_At_Back_End_Of_Board()
            {
                var moves = Target.GetMovesFrom(BoardCoordinate.For(4, 8));

                Assert.AreEqual<int>(5, moves.Count());
            }
        }
        
    }
}
