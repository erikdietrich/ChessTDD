using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test.BoardTests
{
    [TestClass]
    public class Board_Constructor_Should
    {
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_On_Negative_BoardSize()
        {
            ExtendedAssert.Throws<ArgumentException>(() => new Board(-1));
        }

        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Throw_ArgumentException_On_Zero_BoardSize()
        {
            ExtendedAssert.Throws<ArgumentException>(() => new Board(0));
        }
    }
}
