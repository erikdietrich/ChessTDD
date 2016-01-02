using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.ThreatEvaluator
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
            Board.AddPiece(new Rook(false), BoardCoordinate.For(1, 2));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(1, 1), true);

            Assert.IsTrue(isSquareThreatened);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_Square_KiddyCorner_To_Rook()
        {
            Board.AddPiece(new Rook(false), BoardCoordinate.For(1, 1));

            var isSquareThreatened = Target.IsThreatened(BoardCoordinate.For(2, 2), true);

            Assert.IsFalse(isSquareThreatened);
        }
    }
    public class ThreatEvaluator
    {
        private readonly Board _board;

        public ThreatEvaluator(Board board)
        {
            _board = board;
        }

        public bool IsThreatened(BoardCoordinate victim, bool isFirstPlayerAttacking)
        {
            var numbers = Enumerable.Range(1, _board.Size);

            var coordinates = numbers.SelectMany(x => numbers, (x, y) => BoardCoordinate.For(x, y));

            return coordinates.Any(c => DoesSquareAttack(c, victim));
        }

        private bool DoesSquareAttack(BoardCoordinate attacker, BoardCoordinate victim)
        {
            var piece = _board.GetPiece(attacker);

            return piece !=  null && _board.GetMovesFrom(attacker).Any(m => m.Matches(victim));
        }

    }
}
