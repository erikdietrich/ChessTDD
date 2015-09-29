using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_ChessboardSetupWithOnlyBlackKing_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            var positioner = new PiecePositioner(Target);
            positioner.SetupStandardPieces(1);
            positioner.SetupStandardPawns(2);

            Target.AddPiece(new King(false), BoardCoordinate.For(4, 8));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Seven_Moves_For_Added_Black_King()
        {
            var movesForBlackKing = Target.GetMovesFrom(BoardCoordinate.For(4, 8)).Count();

            Assert.AreEqual<int>(7, movesForBlackKing);
        }

    }
}
