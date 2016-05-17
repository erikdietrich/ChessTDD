using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class PiecePositioner_Given_NormalSizedBoard_Should
    {
        private Board TheBoard { get; set; }

        private PiecePositioner Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            TheBoard = new Board();
            Target = new PiecePositioner(TheBoard);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Set_The_Pawns_At_Position_7_To_Be_Player2()
        {
            Target.SetupStandardBoard();
            var firstPawnOnTheLeft = TheBoard.GetPiece(BoardCoordinate.For(1, 7));

            Assert.IsFalse(firstPawnOnTheLeft.IsFirstPlayerPiece);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Argument_Exception_For_OutOfBounds_Row_To_SetupStandardPawns()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.SetupStandardPawns(9), "row");
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_For_Zero_Row_To_SetupStandardPawns()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.SetupStandardPawns(0));
        }
    }
}
