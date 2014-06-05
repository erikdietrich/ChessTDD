using Chess.Test.Production;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test
{
    [TestClass]
    public class BishopTest
    {
        private Bishop Target { get; set; }

        private const int DefaultBoardSize = 8;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Bishop();
        }

        [TestClass]
        public class GetMovesFrom : BishopTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_Non_Empty_Collection()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 1), DefaultBoardSize).Any());
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_2_For_1_1()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 1), DefaultBoardSize).Any(bc => bc.X == 2 && bc.Y == 2));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_1_1_For_2_2()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(2, 2), DefaultBoardSize).Any(bc => bc.X == 1 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_1_For_1_2()
            {
                Assert.IsTrue(Target.GetMovesFrom(new BoardCoordinate(1, 2), DefaultBoardSize).Any(bc => bc.X == 2 && bc.Y == 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_Negative_Values_For_BoardCoordinates()
            {
                Assert.IsFalse(Target.GetMovesFrom(new BoardCoordinate(1, 2), DefaultBoardSize).Any(bc => bc.Y < 0 || bc.X < 0));
            }
        }
    }


    public class Bishop : Piece
    {
        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize)
        {
            var moves = new List<BoardCoordinate>();
            for (int index = 1; index <= boardSize; index++)
            {
                var upOneOverOne = new BoardCoordinate(startingLocation.X + index, startingLocation.Y + index);
                if (upOneOverOne.IsCoordinateValidForBoardSize(boardSize))
                    moves.Add(upOneOverOne);

                var downOneOverOne = new BoardCoordinate(startingLocation.X + index, startingLocation.Y - index);
                if (downOneOverOne.IsCoordinateValidForBoardSize(boardSize))
                    moves.Add(downOneOverOne);

                var upOneBackOne = new BoardCoordinate(startingLocation.X - index, startingLocation.Y + index);
                if (upOneBackOne.IsCoordinateValidForBoardSize(boardSize))
                    moves.Add(upOneBackOne);

                var downOneBackOne = new BoardCoordinate(startingLocation.X - index, startingLocation.Y - index);
                if(downOneBackOne.IsCoordinateValidForBoardSize(boardSize))
                    moves.Add(downOneBackOne);
            }
            return moves;
        }
    }
}
