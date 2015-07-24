using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.PawnTests
{
    [TestClass]
    public class PawnTest
    {
        private Pawn Target { get; set; }

        private IEnumerable<BoardCoordinate> MovesFrom22;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Pawn();
            MovesFrom22 = Target.GetMovesFrom(new BoardCoordinate(2, 2));
        }

        [TestClass]
        public class GetMovesFrom : PawnTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_3_As_One_Result_When_Passed_2_2()
            {
                Assert.IsTrue(MovesFrom22.Any(bc => bc.X == 2 && bc.Y == 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_2_4__As_One_Result_When_Passed_2_2_When_Piece_Has_Not_Moved()
            {
                Assert.IsTrue(MovesFrom22.Any(bc => bc.X == 2 && bc.Y == 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Does_Not_Return_2_4_When_Passed_2_2_If_Piece_Has_Already_Moved()
            {
                Target.HasMoved = true;

                Assert.IsFalse(MovesFrom22.Any(bc => bc.X == 2 && bc.Y == 4));
            }

        }

        [TestClass]
        public class IsCaptureAllowed : PawnTest
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_Square_In_Front_Of_Pawn()
            {
                Assert.IsFalse(CanCaptureFrom22(2, 3));   
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_LeftOne_Up_One()
            {
                Assert.IsTrue(CanCaptureFrom22(1, 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_Some_Oblique_Square()
            {
                Assert.IsFalse(CanCaptureFrom22(6, 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_RightOne_UpOne()
            {
                Assert.IsTrue(CanCaptureFrom22(3, 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_RightOne_UpTwo()
            {
                Assert.IsFalse(CanCaptureFrom22(3, 4));
            }

            private bool CanCaptureFrom22(int xCoordinate, int yCoordinate)
            {
                return Target.IsCaptureAllowed(BoardCoordinate.For(2, 2), BoardCoordinate.For(xCoordinate, yCoordinate));
            }
        }
 
        [TestClass]
        public class IsNonCaptureAllowed : PawnTest 
        {
            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_RightOne_UpOne()
            {
                Assert.IsFalse(CanMakeNonCaptureMoveFrom22(3, 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_RightOne_UpTwo()
            {
                Assert.IsFalse(CanMakeNonCaptureMoveFrom22(3, 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_UpOne()
            {
                Assert.IsTrue(CanMakeNonCaptureMoveFrom22(2, 3));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_True_For_UpTwo()
            {
                Assert.IsTrue(CanMakeNonCaptureMoveFrom22(2, 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_UpTwo_After_Pawn_HasMoved()
            {
                Target.HasMoved = true;
                Assert.IsFalse(CanMakeNonCaptureMoveFrom22(2, 4));
            }

            [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
            public void Returns_False_For_UpThree()
            {
                Assert.IsFalse(CanMakeNonCaptureMoveFrom22(2, 5));
            }

            private bool CanMakeNonCaptureMoveFrom22(int xCoordinate, int yCoordinate)
            {
                return Target.IsNonCaptureAllowed(BoardCoordinate.For(2, 2), BoardCoordinate.For(xCoordinate, yCoordinate));
            }
        }
    }
}