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
        [TestClass]
        public class GetMovesFrom
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_As_One_Result_When_Passed_2_2()
            {
                var pawn = new Pawn();

                var possibleMoves = pawn.GetMovesFrom(2, 2);

                Assert.IsTrue(possibleMoves.Any(bc => bc.X == 2 && bc.Y == 3));
            }
        }
    }

    public class Pawn
    {
        public IEnumerable<BoardCoordinate> GetMovesFrom(int xCoordinate, int yCoordinate)
        {
            yield return new BoardCoordinate(xCoordinate, yCoordinate + 1);
        }
    }
}
