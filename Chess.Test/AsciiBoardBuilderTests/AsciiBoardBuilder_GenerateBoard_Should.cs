using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.AsciiBoardBuilderTests
{
    [TestClass]
    public class AsciiBoardBuilder_GenerateBoard_Should
    {
        private AsciiBoardBuilder Target { get; set; }

        private BoardCoordinate SomeCoordinate
        {
            get { return BoardCoordinate.For(1, 1); }
        }

        private Board GeneratedBoard
        {
            get
            {
                return Target.GenerateBoard();
            }
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new AsciiBoardBuilder();
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Empty_Board()
        {
            Assert.AreEqual<int>(0, GeneratedBoard.PieceCount);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_One_Piece_When_SinglePawn_Is_Added()
        {
            Target.AddPiece(BoardCoordinate.For(1, 1), "WP");

            Assert.AreEqual<int>(1, GeneratedBoard.PieceCount);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Two_Pieces_When_Two_Pawns_Are_Added()
        {
            Target.AddPiece(BoardCoordinate.For(1, 1), "WP");
            Target.AddPiece(BoardCoordinate.For(1, 2), "WP");

            Assert.AreEqual<int>(2, GeneratedBoard.PieceCount);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_A_White_Bishop_When_WB_Is_Added()
        {
            Target.AddPiece(SomeCoordinate, "WB");

            var addedPiece = GeneratedBoard.GetPiece(SomeCoordinate);

            var isWhiteBishop = addedPiece.GetType() == typeof(Bishop) && addedPiece.IsFirstPlayerPiece;

            Assert.IsTrue(isWhiteBishop);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Black_Bishop_When_BB_Is_Added()
        {
            Target.AddPiece(SomeCoordinate, "BB");

            var addedPiece = GeneratedBoard.GetPiece(SomeCoordinate);

            var isBlackBishop = addedPiece.GetType() == typeof(Bishop) && !addedPiece.IsFirstPlayerPiece;

            Assert.IsTrue(isBlackBishop);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Queen_When_WQ_Is_Added()
        {
            Target.AddPiece(SomeCoordinate, "WQ");
            var addedPiece = GeneratedBoard.GetPiece(SomeCoordinate);

            Assert.IsInstanceOfType(addedPiece, typeof(Queen));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_King_When_BK_Is_Added()
        {
            Target.AddPiece(SomeCoordinate, "BK");
            var addedPiece = GeneratedBoard.GetPiece(SomeCoordinate);

            Assert.IsInstanceOfType(addedPiece, typeof(King));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Rook_When_WR_Is_Added()
        {
            Target.AddPiece(SomeCoordinate, "WR");
            var addedPiece = GeneratedBoard.GetPiece(SomeCoordinate);

            Assert.IsInstanceOfType(addedPiece, typeof(Rook));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Knight_When_BKn_Is_Added()
        {
            Target.AddPiece(SomeCoordinate, "BKn");
            var addedPiece = GeneratedBoard.GetPiece(SomeCoordinate);

            Assert.IsInstanceOfType(addedPiece, typeof(Knight));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_When_Color_Is_Not_Specified()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(SomeCoordinate, "P"));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_When_First_Character_Is_Not_B_Or_W()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(SomeCoordinate, "DD"));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_NullArgumentException_On_Null_PieceString()
        {
            ExtendedAssert.Throws<ArgumentNullException>(() => Target.AddPiece(SomeCoordinate, null));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_On_Empty_PieceString()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(SomeCoordinate, string.Empty));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_For_Single_Character_Piece()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(SomeCoordinate, "1"));
        }

    }
}
