using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Test
{
    public static class ExtendedAssert
    {
        public static void Throws<TException>(Action executable) where TException : Exception
        {
            try
            {
                executable();
            }
            catch (Exception ex)
            {
                AssertExceptionMatch<TException>(ex);
                return;
            }
            FailNoException<TException>();
        }

        public static void Throws<TException>(Action executable, string exceptionMessage) where TException : Exception
        {
            try
            {
                executable();
            }
            catch (Exception ex) 
            {
                AssertExceptionMatch<TException>(ex);
                Assert.IsTrue(ex.Message == exceptionMessage, "Message was not the expected message.");
                return;
            }
            FailNoException<TException>();
        }

        private static void AssertExceptionMatch<TException>(Exception ex) where TException : Exception
        {
            Assert.IsTrue(ex.GetType() == typeof(TException), String.Format("Expected exception of type {0} but got {1}", typeof(TException), ex.GetType()));
        }
        private static void FailNoException<TException>() where TException : Exception
        {
            Assert.Fail(String.Format("Expected exception of type {0}, but no exception was thrown.", typeof(TException)));
        }
    }
}
