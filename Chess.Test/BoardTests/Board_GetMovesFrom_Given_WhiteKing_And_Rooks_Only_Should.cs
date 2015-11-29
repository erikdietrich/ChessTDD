using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_WhiteKing_And_Rooks_Only_Should
    {
        private BoardCoordinate KingStart
        {
            get { return BoardCoordinate.For(5,1);}
        }

        private BoardCoordinate KingMove
        {
            get { return BoardCoordinate.For(4, 1); }
        }

        private BoardCoordinate KingRookStart
        {
            get { return BoardCoordinate.For(8, 1); }
        }

        private BoardCoordinate KingRookMove
        {
            get { return BoardCoordinate.For(8, 2); }
        }

        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();

            Target.AddPiece(new Rook(), 1, 1);
            Target.AddPiece(new Rook(), KingRookStart.X, KingRookStart.Y);
            Target.AddPiece(new King(), KingStart.X, KingStart.Y);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Castling_Option_When_King_Has_Moved()
        {
            Target.MovePiece(KingStart.X, KingStart.Y, KingMove.X, KingMove.Y);
            Target.MovePiece(KingMove.X, KingMove.Y, KingStart.X, KingStart.Y);

            var kingMoves = Target.GetMovesFrom(KingStart.X, KingStart.Y);

            Assert.IsFalse(kingMoves.Any(bc => bc[0] == 7 && bc[1] == 1));
        }

    }
}
