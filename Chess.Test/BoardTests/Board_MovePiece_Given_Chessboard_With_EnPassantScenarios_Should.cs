using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_MovePiece_Given_Chessboard_With_EnPassantScenarios_Should
    {
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            new PiecePositioner(Target).SetupStandardBoard();
            Target.MovePiece(BoardCoordinate.For(2, 7), BoardCoordinate.For(2, 5));
            Target.MovePiece(BoardCoordinate.For(2, 5), BoardCoordinate.For(2, 4));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Set_Pawn_CanPerformEnPassant_Flag_For_Black_Pawn_At_24()
        {
            Target.MovePiece(BoardCoordinate.For(1, 2), BoardCoordinate.For(1, 4));

            var piece = Target.GetPiece(BoardCoordinate.For(2, 4)) as Pawn;
            
            Assert.IsTrue(piece.CanPerformEnPassant);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Not_Set_Pawn_IsVulnerableToEn_Passant_For_Normal_Scenario()
        {
            Target.MovePiece(BoardCoordinate.For(1, 2), BoardCoordinate.For(1, 3));

            var piece = Target.GetPiece(BoardCoordinate.For(1, 3)) as Pawn;

            Assert.IsFalse(piece.CanPerformEnPassant);
        }
    }
}
