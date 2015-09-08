namespace Chess.ConsoleClient
{
    using System;

    using Chess.Source.Renderers;
    using Chess.Source.Renderers.Contracts;

    public class EntryPoint
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();
        }
    }
}
