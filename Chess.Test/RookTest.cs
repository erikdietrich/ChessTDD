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
        [TestClass]
        public class GetMovesFrom
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Empty_Collection()
            {
                var rook = new Rook();

                Assert.AreEqual<int>(0, rook.GetMovesFrom(1, 1).Count());
            }
        }
    }
}
