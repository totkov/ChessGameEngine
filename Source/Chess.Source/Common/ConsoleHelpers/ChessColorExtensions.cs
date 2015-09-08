namespace Chess.Source.Common.ConsoleHelpers
{
    using System;

    public static class ChessColorExtensions
    {
        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Black:
                    return ConsoleColor.Black;
                default:
                    throw new InvalidOperationException("Cannot convert chess color");
            }
        }
    }
}
