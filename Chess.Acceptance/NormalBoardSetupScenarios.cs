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
        public void ThenAllNon_KnightPiecesShouldHaveNoMoves()
        {
            var nonKnightCoordinates = Range(1, 8).Where(i => i != 2 && i != 7);
            var movesCount = nonKnightCoordinates.SelectMany(xCoordinate => BoardMoves(xCoordinate, 1)).Count();
            Assert.AreEqual<int>(0, movesCount);
        }


        [Then(@"all white pawns should have two moves")]
        public void ThenAllWhitePawnsShouldHaveTwoMoves()
        {
            var movesCount = Range(1, 8).SelectMany(xCoordinate => BoardMoves(xCoordinate, 2)).Count();
            Assert.AreEqual<int>(16, movesCount);
        }


        private Board BuildBoardFromTable(Table table)
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

        private static IEnumerable<BoardCoordinate> BoardMoves(int x, int y)
        {
            return Board.GetMovesFrom(BoardCoordinate.For(x, y));
        }

        private static T GetFromContext<T>()
        {
            return ScenarioContext.Current.Get<T>();
        }

        private static void SetInContext<T>(T data)
        {
            ScenarioContext.Current.Set<T>(data);
        }

        private static List<BoardCoordinate> GetCoordinatesFromTable(Table tableOfBoardCoordinates)
        {
            return tableOfBoardCoordinates.Rows.Select(r => BoardCoordinate.For(int.Parse(r[0]), int.Parse(r[1]))).ToList();
        }
        

    }
}
