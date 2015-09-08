namespace Chess.Source.InputProviders
{
    using System;
    using System.Collections.Generic;

    using Chess.Source.Players.Contracts;
    using Chess.Source.Players;
    using Chess.Source.Common;
    using Chess.Source.InputProviders.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public const string PlayerNameMasage = "Enter Player {0} name: ";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();

                int centerRow = Console.WindowHeight / 2;
                int centerCol = Console.WindowWidth / 2 - PlayerNameMasage.Length / 2;
                Console.SetCursorPosition(centerCol, centerRow);

                Console.Write(string.Format(PlayerNameMasage, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }
            return players;
        }
    }
}
