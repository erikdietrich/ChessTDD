using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_WhiteKing_Should
    {
        private static readonly BoardCoordinate QueensRook = BoardCoordinate.For(1, 1);
        private static readonly BoardCoordinate KingStart = BoardCoordinate.For(5, 1);
        private static readonly BoardCoordinate KingMove = BoardCoordinate.For(4, 1);        

        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();

            Target.AddPiece(new Rook(), QueensRook);
            Target.AddPiece(new King(), KingStart);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Castling_Option_When_King_Has_Moved()
        {
            Target.MovePiece(KingStart, KingMove);
            Target.MovePiece(KingMove, KingStart);

            var kingMoves = Target.GetMovesFrom(KingStart);

            Assert.IsFalse(kingMoves.Any(bc => bc.Matches(7, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Allow_King_To_Move_Into_Check()
        {
            Target.AddPiece(new Queen(false), BoardCoordinate.For(4, 8));

            var kingMoves = Target.GetMovesFrom(KingStart);

            Assert.IsFalse(kingMoves.Any(bc => bc.X == 4));
        }
    }
}
