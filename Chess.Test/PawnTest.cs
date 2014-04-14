using Chess.Test.Production;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test
{
    [TestClass]
    public class PawnTest
    {
        private Pawn Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Pawn();
        }

        [TestClass]
        public class GetMovesFrom : PawnTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_As_One_Result_When_Passed_2_2()
            {
                var possibleMoves = Target.GetMovesFrom(2, 2);

                Assert.IsTrue(possibleMoves.Any(bc => bc.X == 2 && bc.Y == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_4__As_One_Result_When_Passed_2_2_When_Piece_Has_Not_Moved()
            {
                var possibleMoves = Target.GetMovesFrom(2, 2);

                Assert.IsTrue(possibleMoves.Any(bc => bc.X == 2 && bc.Y == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_2_4_When_Passed_2_2_If_Piece_Has_Already_Moved()
            {
                Target.HasMoved = true;

                var possibleMoves = Target.GetMovesFrom(2, 2);

                Assert.IsFalse(possibleMoves.Any(bc => bc.X == 2 && bc.Y == 4));
            }
        }
    }
}