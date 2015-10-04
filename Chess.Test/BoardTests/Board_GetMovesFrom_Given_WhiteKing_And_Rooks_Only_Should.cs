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

            Target.AddPiece(new Rook(), BoardCoordinate.For(1, 1));
            Target.AddPiece(new Rook(), KingRookStart);
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

        //[TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        //public void Not_Return_Castling_Option_When_Rook_Has_Moved()
        //{
        //    Target.MovePiece(KingRookStart, KingRookMove);
        //    Target.MovePiece(KingRookMove, KingRookStart);

        //    var kingMoves = Target.GetMovesFrom(KingStart);

        //    Assert.IsFalse(kingMoves.Any(bc => bc.Matches(7, 1)));
        //}

    }
}
