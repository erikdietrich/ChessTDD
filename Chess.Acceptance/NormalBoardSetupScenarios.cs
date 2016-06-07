using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

using static System.Linq.Enumerable;

namespace Chess.Acceptance
{
    [Binding]
    public class NormalBoardSetupScenarios
    {
        private static IEnumerable<int> NonKnightCoordinates => Range(1, 8).Where(i => i != 2 && i != 7);

        private static Board Board
        {
            get { return GetFromContext<Board>(); }
            set { SetInContext(value); }
        }

        [When(@"there is a chess board set up as")]
        public void SetBoardInContextFromTable(Table table)
        {
            Board = BuildBoardFromTable(table);
        }

        [When(@"there is a move from \((.*),(.*)\) to \((.*),(.*)\)")]
        public void ThereIsAMoveFrom(int startX, int startY, int destinationX, int destinationY)
        {
            Board.MovePiece(BoardCoordinate.For(startX, startY), BoardCoordinate.For(destinationX, destinationY));
        }
                
        [Then(@"the piece at \((.*),(.*)\) should have exactly the following moves")]
        public void ThenThePieceAtShouldHaveTheFollowingMoves(int xCoordinate, int yCoordinate, Table table)
        {
            var boardMoves = Board.GetMovesFrom(BoardCoordinate.For(xCoordinate, yCoordinate)).ToList();

            var tableCoordinates = GetCoordinatesFromTable(table);

            CollectionAssert.AreEquivalent(tableCoordinates, boardMoves);
        }

        [Then(@"all white non-knight pieces should have no moves")]
        public void ThenAllWhiteNon_KnightPiecesShouldHaveNoMoves()
        {
            var movesCount = GetTotalMoves(NonKnightCoordinates, 1);
            Assert.AreEqual<int>(0, movesCount);
        }


        [Then(@"all white pawns should have two moves")]
        public void ThenAllWhitePawnsShouldHaveTwoMoves()
        {
            var movesCount = GetTotalMoves(Range(1, 8), 2);
            Assert.AreEqual<int>(16, movesCount);
        }

        [Then(@"all black non-knight pieces should have no moves")]
        public void ThenAllBlackNon_KnightPiecesShouldHaveNoMoves()
        {
            var movesCount = GetTotalMoves(NonKnightCoordinates, 8);
            Assert.AreEqual<int>(0, movesCount);
        }

        [Then(@"all black pawns should have two moves")]
        public void ThenAllBlackPawnsShouldHaveTwoMoves()
        {
            var movesCount = GetTotalMoves(Range(1, 8), 7);

            Assert.AreEqual<int>(16, movesCount);
        }



        private static Board BuildBoardFromTable(Table table)
        {
            var builder = new AsciiBoardBuilder();
            var indeces = Enumerable.Range(0, 8).ToList();
            indeces.ForEach(ri => indeces.ForEach(ci => AddNonEmptyPiece(builder, table, ri, ci)));
            var builderGenerateBoard = builder.GenerateBoard();
            return builderGenerateBoard;
        }

        private static void AddNonEmptyPiece(AsciiBoardBuilder builder, Table table, int rowIndex, int columnIndex)
        {
            var xCoordinate = columnIndex + 1;
            var yCoordinate = 8 - rowIndex;
            var pieceString = table.Rows[rowIndex][columnIndex];

            if (!string.IsNullOrEmpty(pieceString))
                builder.AddPiece(BoardCoordinate.For(xCoordinate, yCoordinate), pieceString);

        }

        private static int GetTotalMoves(IEnumerable<int> xCoordinates, int row) => xCoordinates.SelectMany(x => BoardMoves(x, row)).Count();

        private static IEnumerable<BoardCoordinate> BoardMoves(int x, int y) => Board.GetMovesFrom(BoardCoordinate.For(x, y));

        private static T GetFromContext<T>() => ScenarioContext.Current.Get<T>();
        
        private static void SetInContext<T>(T data) => ScenarioContext.Current.Set<T>(data);
        
        private static List<BoardCoordinate> GetCoordinatesFromTable(Table tableOfBoardCoordinates)
        {
            return tableOfBoardCoordinates.Rows.Select(r => BoardCoordinate.For(int.Parse(r[0]), int.Parse(r[1]))).ToList();
        }
        

    }
}
