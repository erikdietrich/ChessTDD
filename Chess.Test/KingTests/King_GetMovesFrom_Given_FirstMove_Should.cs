using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test.KingTests
{
    [TestClass]
    public class King_GetMovesFrom_Should
    {
        private King Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesFrom51
        {
            get { return Target.GetMovesFrom(5, 1); }
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new King();
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Square_With_X_Coordinate_Two_Greater()
        {
            Assert.IsTrue(MovesFrom51.Any(bc => bc.X == 7 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Square_With_X_Coordinate_2_Less()
        {
            Assert.IsTrue(MovesFrom51.Any(bc => bc.X == 3 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Square_With_X_Coordinate_2_Less_When_King_Has_Moved()
        {
            Target.HasMoved = true;

            Assert.IsFalse(MovesFrom51.Any(bc => bc.X == 3 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Square_With_X_Coordinate_2_More_When_King_Has_Moved()
        {
            Target.HasMoved = true;

            Assert.IsFalse(MovesFrom51.Any(bc => bc.X == 7 && bc.Y == 1));
        }

    }
}
