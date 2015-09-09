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


        /// <summary>
        /// Command is in format: a5-c5
        /// </summary>
        public Move GetNextPlayerMove(IPlayer player)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);

            Console.Write("{0} is next: ", player.Name);
            var command = Console.ReadLine().Trim();

            //Clear console row
            Console.SetCursorPosition(0, 1);
            Console.Write(new string(' ', Console.WindowWidth));

            var positionAsStringParts = command.Split('-');
            if (positionAsStringParts.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPosition = Position.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }
    }
}
