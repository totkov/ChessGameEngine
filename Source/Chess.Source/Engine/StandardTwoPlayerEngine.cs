namespace Chess.Source.Engine
{
    using System.Collections.Generic;

    using Chess.Source.Board;
    using Chess.Source.Engine.Contracts;
    using Chess.Source.Players.Contracts;
    using Chess.Source.Renderers.Contracts;
    using Chess.Source.InputProviders.Contracts;
    using Chess.Source.Board.Contracts;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private readonly IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
        }

        public IList<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            var players = this.input.GetPlayers(2);
            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(this.board);
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
