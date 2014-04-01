using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    public struct BoardCoordinate
    {
        private int _x;
        public int X { get { return _x; } }

        private int _y;
        public int Y { get { return _y; } }

        public BoardCoordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public bool IsCoordinateValidForBoardSize(int boardSize)
        {
            return IsDimensionValidForBoardSize(X, boardSize) && IsDimensionValidForBoardSize(Y, boardSize);
        }

        private static bool IsDimensionValidForBoardSize(int dimensionValue, int boardSize)
        {
            return dimensionValue > 0 && dimensionValue <= boardSize;
        }
    }
}
