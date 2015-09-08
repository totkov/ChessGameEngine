namespace Chess.Source.Engine.Contracts
{
    using System.Collections.Generic;
    using Chess.Source.Players.Contracts;

    public interface IChessEngine
    {
        IList<IPlayer> Players { get; }
        void Initialize(IGameInitializationStrategy gameInitializationStrategy);
        void Start();
        void WinningConditions();
    }
}
