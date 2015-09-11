namespace Chess.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Chess.Source.Common;

    [TestClass]
    public class ObjectValidatorTests
    {
        [TestMethod]
        public void Test_CheckIfObjectIsNullWhitValidData()
        {
            object testObject = new object();
            ObjectValidator.CheckIfObjectIsNull(testObject);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_CheckIfObjectIsNullWhitInvalidData()
        {
            object testObject = null;
            ObjectValidator.CheckIfObjectIsNull(testObject);
        }
    }
}
