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

    public static class ChessFacade
    {
        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandardTwoPlayerEngine(renderer, inputProvider);

            IGameInitializationStrategy gameInitializationStrategy = new StandardStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);
            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
