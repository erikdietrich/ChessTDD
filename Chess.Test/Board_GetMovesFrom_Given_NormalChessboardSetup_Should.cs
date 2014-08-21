using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test
{
    [TestClass]
    public class Board_GetMovesFrom_Given_NormalChessboardSetup_Should
    {
        private Board Target { get;set;}

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();

            var xCoordinates = Enumerable.Range(1, 8).ToList();
            xCoordinates.ForEach(xc => Target.AddPiece(new Pawn(), new BoardCoordinate(xc, 2)));

            Target.AddPiece(new Rook(), new BoardCoordinate(1, 1));
            Target.AddPiece(new Rook(), new BoardCoordinate(8, 1));

            Target.AddPiece(new Knight(), new BoardCoordinate(2, 1));
            Target.AddPiece(new Knight(), new BoardCoordinate(7, 1));

            Target.AddPiece(new Bishop(), new BoardCoordinate(3, 1));
            Target.AddPiece(new Bishop(), new BoardCoordinate(6, 1));

            Target.AddPiece(new Queen(), new BoardCoordinate(4, 1));
            Target.AddPiece(new King(), new BoardCoordinate(5, 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_A_Set_Of_Moves_For_A_Pawn_Containing_The_Space_One_Ahead()
        {
            var moves = Target.GetMovesFrom(new BoardCoordinate(1, 2));

            Assert.IsTrue(moves.Any(bc => bc.Matches(1, 3)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Returns_A_Set_Of_Moves_For_A_Pawn_Containing_Space_Two_Ahead()
        {
            var moves = Target.GetMovesFrom(new BoardCoordinate(1, 2));

            Assert.IsTrue(moves.Any(bc => bc.Matches(1, 4)));
        }
    }
}
