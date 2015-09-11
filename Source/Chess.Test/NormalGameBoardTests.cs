namespace Chess.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Chess.Source.Common;
    using Chess.Source.Board;
    using Chess.Source.Figures;

    [TestClass]
    public class NormalGameBoardTests
    {
        // AddFigure()
        [TestMethod]
        public void Test_AddFigureWhitValidData()
        {
            Board testBoard = new Board();
            Position position = new Position(5, 'a');
            Pawn testPawn = new Pawn(ChessColor.White);

            testBoard.AddFigure(testPawn, position);

            Assert.AreSame(testPawn, testBoard.GetFigureAtPosition(position));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_AddFigureWhitInvalidFigureAndValidPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(5, 'a');
            Pawn testPawn = null;

            testBoard.AddFigure(testPawn, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_AddFigureWhitValidFigureAndInvalidPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(-61, 'q');
            Pawn testPawn = new Pawn(ChessColor.White);

            testBoard.AddFigure(testPawn, position);
        }

        // RemoveFigure()
        [TestMethod]
        public void Test_RemoveFigureWhitValidPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(8, 'c');
            Bishop testBishop = new Bishop(ChessColor.White);

            testBoard.AddFigure(testBishop, position);

            testBoard.RemoveFigure(position);

            Assert.IsNull(testBoard.GetFigureAtPosition(position));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_RemoveFigureWhitValidЕmptyPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(8, 'c');

            testBoard.RemoveFigure(position);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_RemoveFigureWhitInvalidPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(14, '0');

            testBoard.RemoveFigure(position);
        }

        // GetFigureAtPosition()
        [TestMethod]
        public void Test_GetFigureAtPositionWhitValidPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(8, 'c');
            Bishop testBishop = new Bishop(ChessColor.White);

            testBoard.AddFigure(testBishop, position);

            Assert.AreSame(testBishop, testBoard.GetFigureAtPosition(position));
        }

        [TestMethod]
        public void Test_GetFigureAtPositionWhitValidEmptyPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(8, 'c');

            Assert.AreEqual(null, testBoard.GetFigureAtPosition(position));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_GetFigureAtPositionWhitInvalidPosition()
        {
            Board testBoard = new Board();
            Position position = new Position(100, 'w');

            Assert.AreEqual(null, testBoard.GetFigureAtPosition(position));
        }

        // MoveFigureAtPosition()
        [TestMethod]
        public void Test_MoveFigureAtPositionWhitValidData()
        {
            Board testBoard = new Board();
            Position fromPosition = new Position(2, 'a');
            Position toPosition = new Position(4, 'a');
            Pawn testPawn = new Pawn(ChessColor.White);

            testBoard.AddFigure(testPawn, fromPosition);

            testBoard.MoveFigureAtPosition(testPawn, fromPosition, toPosition);

            bool result = (testPawn == testBoard.GetFigureAtPosition(toPosition)) &&
                (testBoard.GetFigureAtPosition(fromPosition) == null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_MoveFigureAtPositionWhitInvadidFigure()
        {
            Board testBoard = new Board();
            Position fromPosition = new Position(2, 'a');
            Position toPosition = new Position(4, 'a');
            Pawn testPawn = new Pawn(ChessColor.White);

            testBoard.AddFigure(testPawn, fromPosition);

            testBoard.MoveFigureAtPosition(null, fromPosition, toPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_MoveFigureAtPositionWhitInvalidFromPosition()
        {
            Board testBoard = new Board();
            Position fromPosition = new Position(2, 'a');
            Position invalidFromPosition = new Position(0, '1');
            Position toPosition = new Position(4, 'a');
            Pawn testPawn = new Pawn(ChessColor.White);

            testBoard.AddFigure(testPawn, fromPosition);

            testBoard.MoveFigureAtPosition(testPawn, invalidFromPosition, toPosition);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_MoveFigureAtPositionWhitInvalidToPosition()
        {
            Board testBoard = new Board();
            Position fromPosition = new Position(2, 'a');
            Position invalidToPosition = new Position(4, 'r');
            Pawn testPawn = new Pawn(ChessColor.White);

            testBoard.AddFigure(testPawn, fromPosition);

            testBoard.MoveFigureAtPosition(null, fromPosition, invalidToPosition);
        }
    }
}
