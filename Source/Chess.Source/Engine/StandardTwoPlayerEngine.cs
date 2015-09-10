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
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;
    using Chess.Source.Movements.Strategies;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;
        private readonly IMovementStrategy movementStrategy;

        private int currentPlayerIndex;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            movementStrategy = new NormalMovementStrategy();
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
                    Position from = move.From;
                    Position to = move.To;
                    var figure = board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, move.To);

                    var availableMovements = figure.Move(this.movementStrategy);
                    foreach (var movement in availableMovements)
                    {
                        movement.VlidateMove(figure, board, move);
                    }
                    board.MoveFigureAtPosition(figure, from, to);

                    // TODO: Check castle => Check if castle valid
                    // TODO: Move figure (Check pawn for An-Pasan)
                    // TODO: Check check
                    // TODO: If in check => check checkmate
                    // TODO: If not in check => check drow
                    // TODO: Continue
                    this.renderer.RenderBoard(this.board);
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

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(string.Format("Position {0}{1} is empty!", from.Col, from.Row));
            }
            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(string.Format("Figure at {0}{1} is not yiurs!", from.Col, from.Row));
            }
        }

        private void CheckIfToPositionIsEmpty(IFigure figure, Position to)
        {
            var figureAtPosition = this.board.GetFigureAtPosition(to);
            if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
            {
                throw new InvalidOperationException(string.Format("You already have a figure at {0}{1}!", to.Col, to.Row));
            }
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
