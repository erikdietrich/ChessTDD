using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_DoesPieceExistAt_Should
    {
        private Board Target { get; set; }
        private BoardCoordinate Coordinate { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            Coordinate = BoardCoordinate.For(1, 1);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_Empty_Square()
        {
            Assert.IsFalse(Target.DoesPieceExistAt(Coordinate));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_True_For_Populated_Square()
        {
            Target.AddPiece(new Rook(), Coordinate);

            Assert.IsTrue(Target.DoesPieceExistAt(Coordinate));
        }
    }
}
