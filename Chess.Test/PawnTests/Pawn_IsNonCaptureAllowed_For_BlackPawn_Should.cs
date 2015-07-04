using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Test.PawnTests
{
    [TestClass]
    public class Pawn_IsNonCaptureAllowed_For_BlackPawn_Should
    {
        private Pawn Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Pawn(false);
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Return_True_For_26_From_27()
        {
            Assert.IsTrue(Target.IsNonCaptureAllowed(BoardCoordinate.For(2, 7), BoardCoordinate.For(2, 6)));
        }
    }
}
