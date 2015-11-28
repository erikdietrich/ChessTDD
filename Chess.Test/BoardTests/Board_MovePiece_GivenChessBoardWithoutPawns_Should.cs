using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_MovePiece_GivenChessBoardWithoutPawns_Should
    {
        private BoardCoordinate OriginCoordinate { get; set; }
        private BoardCoordinate DestinationCoordinate { get; set; }

        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Board();
            OriginCoordinate = BoardCoordinate.For(1, 1);
            DestinationCoordinate = BoardCoordinate.For(1, 2);
            new PiecePositioner(Target).SetupStandardPieces(1);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Result_In_Piece_At_1_2_When_Rook_At_1_1_Is_Moved_To_1_2()
        {
            Target.MovePiece(OriginCoordinate.X, OriginCoordinate.Y, DestinationCoordinate.X, DestinationCoordinate.Y);

            Assert.IsTrue(Target.DoesPieceExistAt(DestinationCoordinate.X, DestinationCoordinate.Y));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Result_In_No_Pieced_At_1_1_When_Rook_At_1_1_Is_Moved_To_1_2()
        {
            Target.MovePiece(OriginCoordinate.X, OriginCoordinate.Y, DestinationCoordinate.X, DestinationCoordinate.Y);

            Assert.IsFalse(Target.DoesPieceExistAt(OriginCoordinate.X, OriginCoordinate.Y));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Result_In_Piece_At_Origin_Relocated_To_Destination()
        {
            var pieceThatWillBeMoved = Target.GetPiece(OriginCoordinate.X, OriginCoordinate.Y);
            Target.MovePiece(OriginCoordinate.X, OriginCoordinate.Y, DestinationCoordinate.X, DestinationCoordinate.Y);

            Assert.AreEqual<Piece>(pieceThatWillBeMoved, Target.GetPiece(DestinationCoordinate.X, DestinationCoordinate.Y));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_For_Out_Of_Bounds_Origin_Argument()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.MovePiece(1, 9, 2, 2));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_For_OutOfBounds_Destination_Argument()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.MovePiece(OriginCoordinate.X, OriginCoordinate.Y, 10, 10));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_When_Attempt_Is_Made_To_Move_Nonexistent_Piece()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => Target.MovePiece(DestinationCoordinate.X, DestinationCoordinate.Y, OriginCoordinate.X, OriginCoordinate.Y));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void SetHasMoved_When_A_Piece_Is_Moved()
        {
            Target.MovePiece(OriginCoordinate.X, OriginCoordinate.Y, DestinationCoordinate.X, DestinationCoordinate.Y);
            var movedPiece = Target.GetPiece(DestinationCoordinate.X, DestinationCoordinate.Y);

            Assert.IsTrue(movedPiece.HasMoved);
        }

    }
}
