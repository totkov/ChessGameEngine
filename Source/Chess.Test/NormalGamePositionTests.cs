namespace Chess.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Chess.Source.Common;

    [TestClass]
    public class NormalGamePositionTests
    {
        [TestMethod]
        public void Test_CreatePositionWhitValidData()
        {
            int chessRow = 7;
            char chessCol = 'c';
            Position testedPosition = new Position(chessRow, chessCol);
            bool result = testedPosition.Row == chessRow && testedPosition.Col == chessCol;
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_CreatePositionWhitInvalidData()
        {
            int chessRow = 12;
            char chessCol = 'k';
            Position testedPosition = new Position(chessRow, chessCol);
        }

        [TestMethod]
        public void Test_CreatePositionFromChessCoordinates()
        {
            int chessRow = 3;
            char chessCol = 'e';
            Position testedPosition = Position.FromChessCoordinates(chessRow, chessCol);
            bool result = testedPosition.Row == chessRow && testedPosition.Col == chessCol;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_MethodCheckIfPositionIsValidWhitValidData()
        {
            Position testedPosition = new Position(6, 'h');
            Position.CheckIfPositionIsValid(testedPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_MethodCheckIfPositionIsValidWhitInvalidData()
        {
            Position testedPosition = new Position(0, 'q');
            Position.CheckIfPositionIsValid(testedPosition);
        }
    }
}
