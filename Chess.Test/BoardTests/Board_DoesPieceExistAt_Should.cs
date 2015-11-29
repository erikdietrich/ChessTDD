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

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_Empty_Square()
        {
            Assert.IsFalse(Target.DoesPieceExistAt(1, 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_True_For_Populated_Square()
        {
            Target.AddPiece(new Rook(), 1, 1);

            Assert.IsTrue(Target.DoesPieceExistAt(1, 1));
        }
    }
}
