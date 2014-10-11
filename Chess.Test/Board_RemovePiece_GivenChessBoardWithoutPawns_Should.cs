using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    [TestClass]
    public class Board_RemovePiece_GivenChessBoardWithoutPawns_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.SetupStandardPieces(Target, 1);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Result_In_GetPiece_For_1_1_Being_Null_When_Called_With_1_1()
        {
            Target.RemovePiece(BoardCoordinate.For(1, 1));

            Assert.IsNull(Target.GetPiece(BoardCoordinate.For(1, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_When_Called_With_1_2()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.RemovePiece(BoardCoordinate.For(1, 2)));
        }
    }
}
