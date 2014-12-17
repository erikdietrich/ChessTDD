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
        [Given(@"A normal chessboard initial setup")]
        public void GivenANormalChessboardInitialSetup()
        {
            var board = new Board();
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.SetupStandardPieces(board, 1);
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.SetupStandardPieces(board, 8, false);
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.SetupStandardPawns(board, 2);
            Board_GetMovesFrom_Given_NormalChessboardSetup_Should.SetupStandardPawns(board, 7);

            ScenarioContext.Current.Add("board", board);
        }

        [Given(@"I am the first player")]
        public void GivenIAmTheFirstPlayer()
        {
        }

        [When(@"I look for moves available for pawn")]
        public void WhenILookForMovesAvailableForPawn()
        {
            var moves = ((Board)ScenarioContext.Current["board"]).GetMovesFrom(BoardCoordinate.For(1, 2));
            ScenarioContext.Current.Add("moves", moves);
        }

        [Then(@"The result contains a space one ahead")]
        public void ThenTheResultContainsASpaceOneAhead()
        {
            var moves = ((IEnumerable<BoardCoordinate>)ScenarioContext.Current["moves"]);
            Assert.IsTrue(moves.Any(m => m.Matches(1, 3)));
        }
    }
}
