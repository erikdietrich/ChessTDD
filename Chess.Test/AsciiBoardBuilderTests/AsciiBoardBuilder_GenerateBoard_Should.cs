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
            Target.AddPiece(1, 1, "WP");

            Assert.AreEqual<int>(1, GeneratedBoard.PieceCount);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Two_Pieces_When_Two_Pawns_Are_Added()
        {
            Target.AddPiece(1, 1, "WP");
            Target.AddPiece(1, 2, "WP");

            Assert.AreEqual<int>(2, GeneratedBoard.PieceCount);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_A_White_Bishop_At_1_3_When_WB_Is_Added_To_1_3()
        {
            Target.AddPiece(1, 3, "WB");

            var addedPiece = GeneratedBoard.GetPiece(BoardCoordinate.For(1, 3));

            var isWhiteBishop = addedPiece.GetType() == typeof(Bishop) && addedPiece.IsFirstPlayerPiece;

            Assert.IsTrue(isWhiteBishop);            
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Black_Bishop_At_1_3_When_BB_Is_Added_To_1_3()
        {
            Target.AddPiece(1, 3, "BB");

            var addedPiece = GeneratedBoard.GetPiece(BoardCoordinate.For(1, 3));

            var isBlackBishop = addedPiece.GetType() == typeof(Bishop) && !addedPiece.IsFirstPlayerPiece;

            Assert.IsTrue(isBlackBishop);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Generate_Board_With_Queen_At_1_1_When_WQ_Is_Added_To_1_1()
        {
            Target.AddPiece(1, 1, "WQ");

            var addedPiece = GeneratedBoard.GetPiece(BoardCoordinate.For(1, 1));

            Assert.IsInstanceOfType(addedPiece, typeof(Queen));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_Exception_When_Color_Is_Not_Specified()
        {
            ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(1, 1, "P"));
        }

    }
    public class AsciiBoardBuilder
    {
        private readonly Board _board = new Board();

        public Board GenerateBoard()
        {
            return _board;
        }
        public void AddPiece(int row, int column, string piece)
        {
            if (piece == "P")
                throw new ArgumentException("Invalid Piece Type");

            var isFirstPlayerPiece = piece[0] == 'W';
            var pieceToAdd = BuildPiece(piece.Substring(1), isFirstPlayerPiece);

            _board.AddPiece(pieceToAdd, BoardCoordinate.For(row, column));
        }

        private Piece BuildPiece(string pieceString, bool isFirstPlayerPiece)
        {
            switch(pieceString)
            {
                case "P": return new Pawn(isFirstPlayerPiece);
                case "B": return new Bishop(isFirstPlayerPiece);
                case "Q": return new Queen(isFirstPlayerPiece);
                default: return null;
            }
        }
    }
}
