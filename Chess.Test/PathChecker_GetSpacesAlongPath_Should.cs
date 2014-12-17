using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class PathChecker_GetSpacesAlongPath_Should
    {
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_81_For_Path_From_11_To_81()
        {
            var target = new PathChecker(BoardCoordinate.For(1, 1), BoardCoordinate.For(8, 1));

            Assert.IsFalse(target.GetSpacesAlongPath().Any(bc => bc.Matches(8, 1)));
        }
    }
}
