namespace Chess.Source.Engine.Contracts
{
    using System.Collections.Generic;

    using Chess.Source.Players.Contracts;
    using Chess.Source.Board.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
