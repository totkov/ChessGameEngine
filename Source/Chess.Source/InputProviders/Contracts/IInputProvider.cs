namespace Chess.Source.InputProviders.Contracts
{
    using System.Collections.Generic;

    using Chess.Source.Players.Contracts;
    using Chess.Source.Common;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
        Move GetNextPlayerMove(IPlayer player);
    }
}
