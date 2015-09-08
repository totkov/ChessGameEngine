namespace Chess.Source.InputProviders.Contracts
{
    using System.Collections.Generic;

    using Chess.Source.Players.Contracts;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
    }
}
