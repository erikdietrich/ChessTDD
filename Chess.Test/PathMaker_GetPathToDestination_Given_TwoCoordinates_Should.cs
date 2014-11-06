using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class PathMaker_GetPathToDestination_Given_TwoCoordinates_Should
    {
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_7_Spaces()
        {
            var target = new PathMaker(BoardCoordinate.For(1, 1), BoardCoordinate.For(8, 1));

            Assert.AreEqual<int>(7, target.GetPathToDestination().Count());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_Collection_For_11_And_23()
        {
            var origin = BoardCoordinate.For(1, 1);
            var destination = BoardCoordinate.For(2, 3);

            var target = new PathMaker(origin, destination);

            Assert.IsFalse(target.GetPathToDestination().Any());
        }
    }
}
