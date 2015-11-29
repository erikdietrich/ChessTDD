using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_WhiteKing_And_Rooks_Only_Should
    {
        private int[] KingStart
        {
            get { return new int[] { 5, 1 }; }
        }

        private int[] KingMove
        {
            get { return new int[] { 4, 1 }; }
        }

        private int[] KingRookStart
        {
            get { return new int[] { 8, 1 }; }
        }

        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();

            Target.AddPiece(new Rook(), 1, 1);
            Target.AddPiece(new Rook(), KingRookStart[0], KingRookStart[1]);
            Target.AddPiece(new King(), KingStart[0], KingStart[1]);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Castling_Option_When_King_Has_Moved()
        {
            Target.MovePiece(KingStart[0], KingStart[1], KingMove[0], KingMove[1]);
            Target.MovePiece(KingMove[0], KingMove[1], KingStart[0], KingStart[1]);

            var kingMoves = Target.GetMovesFrom(KingStart[0], KingStart[1]);

            Assert.IsFalse(kingMoves.Any(bc => bc[0] == 7 && bc[1] == 1));
        }

    }
}
