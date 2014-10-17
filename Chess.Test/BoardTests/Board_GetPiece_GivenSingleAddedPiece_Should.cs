using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_GetPiece_GivenSingleAddedPiece_Should
    {
        private Pawn Piece { get; set; }
        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Piece = new Pawn();
            Target = new Board();

            Target.AddPiece(Piece, new BoardCoordinate(1, 1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Retrieves_Piece_Added_To_Location()
        {
            Assert.AreEqual<Piece>(Piece, Target.GetPiece(new BoardCoordinate(1, 1)));
        }
    }
}