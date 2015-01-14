using Chess.Test.BoardTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Chess.Acceptance
{
    [Binding]
    public class PawnMovesSteps
    {
        private static T GetFromContext<T>()
        {
            return ScenarioContext.Current.Get<T>();
        }

        private static void SetInContext<T>(T data)
        {
            ScenarioContext.Current.Set<T>(data);
        }

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
            var moves = GetFromContext<IEnumerable<BoardCoordinate>>();
            Assert.IsTrue(moves.Any(m => m.Matches(1, 3)));
        }
    }
}
