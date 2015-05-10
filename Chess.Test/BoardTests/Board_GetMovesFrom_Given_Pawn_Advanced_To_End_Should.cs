using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_Pawn_Advanced_To_End_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            var startingPosition = BoardCoordinate.For(1, 7);
            Target.AddPiece(new Pawn(), startingPosition);
            Target.MovePiece(startingPosition, BoardCoordinate.For(1, 8));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Bomb()
        {
            Assert.AreEqual<int>(0, Target.GetMovesFrom(BoardCoordinate.For(1, 8)).Count());
        }
    }
}
