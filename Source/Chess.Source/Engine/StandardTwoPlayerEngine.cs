namespace Chess.Source.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    using Chess.Source.Board;
    using Chess.Source.Engine.Contracts;
    using Chess.Source.Players.Contracts;
    using Chess.Source.Renderers.Contracts;
    using Chess.Source.InputProviders.Contracts;
    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        private int currentPlayerIndex;

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
            private set 
            {
                this.players = value;
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            this.players = this.input.GetPlayers(2);
            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(this.board);
            this.SetFirstPlayerIndex();
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }
            }
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }
    }
}
