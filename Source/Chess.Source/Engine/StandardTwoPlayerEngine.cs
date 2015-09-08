namespace Chess.Source.Engine
{
    using System.Collections.Generic;

    using Chess.Source.Engine.Contracts;
    using Chess.Source.Players.Contracts;


    public class StandardTwoPlayerEngine : IChessEngine
    {
        private readonly IList<IPlayer> players;

        public IList<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            throw new System.NotImplementedException();
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
