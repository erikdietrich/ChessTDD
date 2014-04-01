using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test
{
    [TestClass]
    public class BoardTest
    {
        private Pawn Piece { get; set; }

        private Board Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Piece = new Pawn();
            Target = new Board();
        }

        [TestClass]
        public class GetPiece : BoardTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Retrieves_Piece_Added_To_Location()
            {
                Target.AddPiece(Piece, new BoardCoordinate(1, 1));

                Assert.AreEqual<Pawn>(Piece, Target.GetPiece(new BoardCoordinate(1, 1)));
            }
        }

        [TestClass]
        public class AddPiece : BoardTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Throw_Exception_When_Adding_A_Piece_To_An_Unoccupied_Square()
            {
                Target.AddPiece(new Pawn(), new BoardCoordinate(2, 1));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_When_BoardCoordinate_Has_Larger_X_Value_Than_Board_Size()
            {
                var coordinate = new BoardCoordinate(9, 1);

                ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(new Pawn(), coordinate));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_When_BoardCoordinate_Has_Larger_Y_Value_Than_Board_Size()
            {
                var coordinate = new BoardCoordinate(1, 9);

                ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(new Pawn(), coordinate));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Throws_Exception_When_BoardCoordinate_Has_Zero_X_Value()
            {
                var coordinate = new BoardCoordinate(0, 3);

                ExtendedAssert.Throws<ArgumentException>(() => Target.AddPiece(new Pawn(), coordinate));
            }
        }
    }

    public class Board
    {
        private const int BoardSize = 8;
        private readonly Pawn[,] _pieces = new Pawn[BoardSize,BoardSize];

        public void AddPiece(Pawn piece, BoardCoordinate moveTarget)
        {
            if (!moveTarget.IsCoordinateValidForBoardSize(BoardSize))
                throw new ArgumentException("moveTarget");

            _pieces[moveTarget.X, moveTarget.Y] = piece;
        }

        public Pawn GetPiece(BoardCoordinate squareInQuestion)
        {
            return _pieces[squareInQuestion.X, squareInQuestion.Y];
        }

        
    }
}
