using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test.KingTests
{
    [TestClass]
    public class King_GetMovesFrom_Given_FirstMove_Should
    {
        private King Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesFrom51;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new King();
            MovesFrom51 = Target.GetMovesFrom(BoardCoordinate.For(5, 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Square_With_X_Coordinate_Two_Greater()
        {
            Assert.IsTrue(MovesFrom51.Any(bc => bc.Matches(7, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Square_With_X_Coordinate_3_Less()
        {
            Assert.IsTrue(MovesFrom51.Any(bc => bc.Matches(2, 1)));
        }

    }
}
