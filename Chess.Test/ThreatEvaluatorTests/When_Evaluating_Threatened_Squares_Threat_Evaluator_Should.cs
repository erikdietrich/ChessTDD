using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.ThreatEvaluatorTests
{
    [TestClass]
    public class When_Evaluating_Threatened_Squares_Threat_Evaluator_Should
    {
        private ThreatEvaluator Target { get; set; }

        private Board Board { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Board = new Board();
            Target = new ThreatEvaluator(Board); 
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_A_Square_With_On_Empty_Board()
        {
            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(1, 1), true);

            Assert.IsFalse(isSquareThreatened);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_True_For_Square_Adjacent_To_Opposing_Rook()
        {
            Board.AddPiece(new Rook(true), BoardCoordinate.For(1, 2));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(1, 1), false);

            Assert.IsTrue(isSquareThreatened);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_Square_KiddyCorner_To_Rook()
        {
            Board.AddPiece(new Rook(true), BoardCoordinate.For(1, 1));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(2, 2), false);

            Assert.IsFalse(isSquareThreatened);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_True_For_Square_KiddyCorner_To_King()
        {
            Board.AddPiece(new King(true), BoardCoordinate.For(5, 1));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(4, 2), false);

            Assert.IsTrue(isSquareThreatened);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_Square_Directly_In_Front_Of_Pawn()
        {
            Board.AddPiece(new Pawn(true), BoardCoordinate.For(1, 2));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(1, 3), false);

            Assert.IsFalse(isSquareThreatened);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_Pieces_Of_Same_Color()
        {
            Board.AddPiece(new Rook(true), BoardCoordinate.For(1, 2));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(1, 1), true);

            Assert.IsFalse(isSquareThreatened);
        }
    }
}
