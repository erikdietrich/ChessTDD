using Chess.Test.BoardTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Chess.Acceptance
{
    [Binding]
    public class WhiteFirstColumnPawnMoves
    {
        [Given(@"A normal chessboard initial setup")]
        public void GivenANormalChessboardInitialSetup()
        {
            var board = new Board();
            var positioner = new PiecePositioner(board);
            positioner.SetupStandardBoard();

            SetInContext(board);
        }

        [Given(@"I am the first player")]
        public void GivenIAmTheFirstPlayer()
        {
        }

        [When(@"I look for moves available for pawn")]
        public void WhenILookForMovesAvailableForPawn()
        {
            var board = GetFromContext<Board>();
            var moves = board.GetMovesFrom(BoardCoordinate.For(1, 2));
            SetInContext(moves);
        }

        [Then(@"The result contains a space one ahead")]
        public void ThenTheResultContainsASpaceOneAhead()
        {
            Assert.IsTrue(ContextContainsMatchFor(1, 3));
        }

        [Then(@"The result contains a space two ahead")]
        public void ThenTheResultContainsASpaceTwoAhead()
        {
            Assert.IsTrue(ContextContainsMatchFor(1, 4));
        }

        [Then(@"The result does not contain a space three ahead")]
        public void ThenTheResultDoesNotContainASpaceThreeAhead()
        {
            Assert.IsFalse(ContextContainsMatchFor(1, 5));
        }

        [Then(@"The result does not contain the capture space one up and one over")]
        public void ThenTheResultDoesNotContainTheCaptureSpaceOneUpAndOneOver()
        {
            Assert.IsFalse(ContextContainsMatchFor(2, 2));
        }


        private static T GetFromContext<T>()
        {
            return ScenarioContext.Current.Get<T>();
        }

        private static void SetInContext<T>(T data)
        {
            ScenarioContext.Current.Set<T>(data);
        }

        private static bool ContextContainsMatchFor(int x, int y)
        {
            var moves = GetFromContext<IEnumerable<BoardCoordinate>>();
            return moves.Any(m => m.Matches(x, y));
        }

        

    }
}
