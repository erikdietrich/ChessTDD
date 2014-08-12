using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;

namespace Chess.Test
{
    [TestClass]
    public class BoardCoordinateTest
    {
        [TestClass]
        public class IsCoordinateValidForBoardSize
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_X_Less_Than_Zero()
            {
                var coordinate = new BoardCoordinate(-12, 2);

                Assert.IsFalse(coordinate.IsCoordinateValidForBoardSize(5));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_Y_Less_Than_Zero()
            {
                var coordinate = new BoardCoordinate(1, -23);

                Assert.IsFalse(coordinate.IsCoordinateValidForBoardSize(8));
            }
        }
    }
}
