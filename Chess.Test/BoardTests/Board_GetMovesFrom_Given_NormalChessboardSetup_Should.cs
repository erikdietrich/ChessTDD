using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetMovesFrom_Given_NormalChessboardSetup_Should
    {
        private Board Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesForLeftWhiteKnight
        {
            get { return Target.GetMovesFrom(BoardCoordinate.For(2, 1)); }
        }

        private void SetupStandardPawns(int row)
        {
            var xCoordinates = Enumerable.Range(1, 8).ToList();
            xCoordinates.ForEach(xc => Target.AddPiece(new Pawn(), new BoardCoordinate(xc, row)));
        }

        public static void SetupStandardPieces(Board target, int row, bool isFirstPlayerPiece = true)
        {
            target.AddPiece(new Rook(isFirstPlayerPiece), new BoardCoordinate(1, row));
            target.AddPiece(new Rook(isFirstPlayerPiece), new BoardCoordinate(8, row));

            target.AddPiece(new Knight(isFirstPlayerPiece), new BoardCoordinate(2, row));
            target.AddPiece(new Knight(isFirstPlayerPiece), new BoardCoordinate(7, row));

            target.AddPiece(new Bishop(isFirstPlayerPiece), new BoardCoordinate(3, row));
            target.AddPiece(new Bishop(isFirstPlayerPiece), new BoardCoordinate(6, row));

            target.AddPiece(new Queen(isFirstPlayerPiece), new BoardCoordinate(4, row));
            target.AddPiece(new King(isFirstPlayerPiece), new BoardCoordinate(5, row));
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();

            SetupStandardPawns(2);
            SetupStandardPieces(Target, 1);

            SetupStandardPawns(7);
            SetupStandardPieces(Target, 8);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_A_Set_Of_Moves_For_A_Pawn_Containing_The_Space_One_Ahead()
        {
            var moves = Target.GetMovesFrom(new BoardCoordinate(1, 2));

            Assert.IsTrue(moves.Any(bc => bc.Matches(1, 3)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_A_Set_Of_Moves_For_A_Pawn_Containing_Space_Two_Ahead()
        {
            var moves = Target.GetMovesFrom(new BoardCoordinate(1, 2));

            Assert.IsTrue(moves.Any(bc => bc.Matches(1, 4)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_Set_For_Rook_At_1_1()
        {
            var moves = Target.GetMovesFrom(new BoardCoordinate(1, 1));

            Assert.IsFalse(moves.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_Set_For_Rook_At_8_1()
        {
            var moves = Target.GetMovesFrom(BoardCoordinate.For(8, 1));

            Assert.IsFalse(moves.Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Empty_Set_For_Rook_At_8_8()
        {
            Assert.IsFalse(Target.GetMovesFrom(BoardCoordinate.For(8, 8)).Any());
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Set_With_33_For_Knight_At_21()
        {
            Assert.IsTrue(MovesForLeftWhiteKnight.Any(bc => bc.Matches(3, 3)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_Set_With_13_For_Knight_At_21()
        {
            Assert.IsTrue(MovesForLeftWhiteKnight.Any(bc => bc.Matches(1, 3)));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Return_42_For_Knight_At_21()
        {
            Assert.IsFalse(MovesForLeftWhiteKnight.Any(bc => bc.Matches(4, 2)));
        }

    }
}
