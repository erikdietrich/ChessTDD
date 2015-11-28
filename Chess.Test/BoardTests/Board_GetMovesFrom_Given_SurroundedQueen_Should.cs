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
            Target.AddPiece(new Rook(false), 3, 1);
            Target.AddPiece(new Rook(false), 5, 1);
            Target.AddPiece(new Bishop(false), 3, 2);
            Target.AddPiece(new Bishop(false), 4, 2);
            Target.AddPiece(new Pawn(false), 5, 2);

            Target.AddPiece(new Queen(), 4, 1);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Move_At_1_1()
        {
            var moves = Target.GetMovesFrom(4, 1);

            Assert.IsFalse(moves.Any(bc => bc.X == 1 && bc.Y == 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_Move_At_2_3()
        {
            var moves = Target.GetMovesFrom(4, 1);

            Assert.IsFalse(moves.Any(bc => bc.X == 2 && bc.Y == 3));
        }
    }
}
