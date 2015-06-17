using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_SurroundedQueen_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            Target.AddPiece(new Rook(false), BoardCoordinate.For(3, 1));
            Target.AddPiece(new Rook(false), BoardCoordinate.For(5, 1));
            Target.AddPiece(new Bishop(false), BoardCoordinate.For(3, 2));
            Target.AddPiece(new Bishop(false), BoardCoordinate.For(4, 2));
            Target.AddPiece(new Pawn(false), BoardCoordinate.For(5, 2));

            Target.AddPiece(new Queen(), BoardCoordinate.For(4, 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Move_At_1_1()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(4, 1));

            Assert.IsFalse(moves.Any(bc => bc.Matches(1, 1)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Move_At_2_3()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(4, 1));

            Assert.IsFalse(moves.Any(bc => bc.Matches(2, 3)));
        }
    }
}
