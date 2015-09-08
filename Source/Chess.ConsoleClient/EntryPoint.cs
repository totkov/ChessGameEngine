namespace Chess.ConsoleClient
{
    using System;

    using Chess.Source.Renderers;
    using Chess.Source.Renderers.Contracts;
    using Chess.Source.Engine;
    using Chess.Source.Engine.Contracts;
    using Chess.Source.Engine.Initializations;
    using Chess.Source.InputProviders;
    using Chess.Source.InputProviders.Contracts;

    public class EntryPoint
    {
        public static void Main()
        {
            ChessFacade.Start();
        }
    }
}
