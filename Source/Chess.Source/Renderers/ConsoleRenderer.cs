namespace Chess.Source.Renderers
{
    using System;
    using System.Threading;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "CHESS";

        public void RenderMainMenu()
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - Logo.Length / 2;
            Console.SetCursorPosition(centerCol, centerRow);

            // TODO: add main menu
            
            Console.WriteLine(Logo);

            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}
