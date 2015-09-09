namespace Chess.Source.Engine.Initializations
{
    using System;
    using System.Collections.Generic;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Engine.Contracts;
    using Chess.Source.Players.Contracts;
    using Chess.Source.Figures;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int NumberOfPlayers = 2;
        private const int BoardTotalRowsAndCols = 8;

        private List<Type> figureTypes;

        public StandardStartGameInitializationStrategy()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddArmyToBoardRow(firstPlayer, board, 1);
            this.AddPawnsToBoardRow(firstPlayer, board, 2);

            this.AddArmyToBoardRow(secondPlayer, board, 8);
            this.AddPawnsToBoardRow(secondPlayer, board, 7);
        }

        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var figureType = this.figureTypes[i];
                var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(figureInstance);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(figureInstance, position);
            }
        }

        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != NumberOfPlayers)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs 8x8 board!");
            }
        }
    }
}
