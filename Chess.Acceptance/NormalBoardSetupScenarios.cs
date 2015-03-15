using Chess.Test.BoardTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Chess.Acceptance
{
    [Binding]
    public class NormalBoardSetupScenarios
    {
        [Given(@"A normal chessboard initial setup")]
        public void GivenANormalChessboardInitialSetup()
        {
            var board = new Board();
            var positioner = new PiecePositioner(board);
            positioner.SetupStandardBoard();

            SetInContext(board);
        }


        [When(@"I look for moves for the pawn in column (.*)")]
        public void WhenILookForMovesForThePawnInColumn(int column)
        {
            var board = GetFromContext<Board>();
            var moves = board.GetMovesFrom(BoardCoordinate.For(column, 2));
            SetInContext(moves);
        }

        [Then(@"The result contains a space one ahead in column (.*)")]
        public void ThenTheResultContainsASpaceOneAhead(int column)
        {
            Assert.IsTrue(ContextContainsMatchFor(column, 3));
        }

        [Then(@"The result contains a space two ahead in column (.*)")]
        public void ThenTheResultContainsASpaceTwoAhead(int column)
        {
            Assert.IsTrue(ContextContainsMatchFor(column, 4));
        }

        [Then(@"The result does not contain a space three ahead in column (.*)")]
        public void ThenTheResultDoesNotContainASpaceThreeAhead(int column)
        {
            Assert.IsFalse(ContextContainsMatchFor(column, 5));
        }

        [Then(@"The result does not contain the capture space one up and one over for column (.*)")]
        public void ThenTheResultDoesNotContainTheCaptureSpaceOneUpAndOneOver(int column)
        {
            Assert.IsFalse(ContextContainsMatchFor(column + 1, 2));
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
