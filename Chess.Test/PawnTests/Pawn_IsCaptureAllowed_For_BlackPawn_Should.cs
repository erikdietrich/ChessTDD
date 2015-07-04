using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.PawnTests
{
    [TestClass]
    public class Pawn_IsCaptureAllowed_For_BlackPawn_Should
    {
        private Pawn Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Pawn(false);    
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_True_For_16_From_27()
        {
            Assert.IsTrue(IsCaptureAllowedFrom27(1, 6));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_False_For_18_From_27()
        {
            Assert.IsFalse(IsCaptureAllowedFrom27(1, 8));
        }
        private bool IsCaptureAllowedFrom27(int xCoordinate, int yCoordinate)
        {
            return Target.IsCaptureAllowed(BoardCoordinate.For(2, 7), BoardCoordinate.For(xCoordinate, yCoordinate));
        }
    }
}
