namespace Chess.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Chess.Source.Common;
    using Chess.Source.Players;
    using Chess.Source.Figures;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Test_CreatePlayer()
        {
            string name = "Test";
            ChessColor color = ChessColor.White;

            Player tested = new Player(name, color);

            Assert.AreEqual(name, tested.Name);
            Assert.AreEqual(color, tested.Color);
        }

        [TestMethod]
        public void Test_AddFigureWhitValidData()
        {
            Player tested = new Player("Test", ChessColor.White);
            Pawn testPawn = new Pawn(ChessColor.White);

            tested.AddFigure(testPawn);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_AddFigureNull()
        {
            Player tested = new Player("Test", ChessColor.White);

            tested.AddFigure(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_AddFigureWhitInvalidColor()
        {
            Player tested = new Player("Test", ChessColor.White);
            Pawn testPawn = new Pawn(ChessColor.Black);

            tested.AddFigure(testPawn);
        }

        [TestMethod]
        public void Test_RemoveFigureWhitValidData()
        {
            Player tested = new Player("Test", ChessColor.White);
            Pawn testPawn = new Pawn(ChessColor.White);
            tested.AddFigure(testPawn);
            tested.RemoveFigure(testPawn);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_RemoveFigureNull()
        {
            Player tested = new Player("Test", ChessColor.White);

            tested.RemoveFigure(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RemoveFigureWhitInvalidColor()
        {
            Player tested = new Player("Test", ChessColor.White);
            Pawn testPawn = new Pawn(ChessColor.Black);

            tested.RemoveFigure(testPawn);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RemoveFigureWhitNotExistFigure()
        {
            Player tested = new Player("Test", ChessColor.White);
            Pawn testPawn = new Pawn(ChessColor.White);

            tested.RemoveFigure(testPawn);
        }
    }
}
