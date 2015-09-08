namespace Chess.Source.Renderers
{
    using System;
    using System.Threading;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Renderers.Contracts;
    using Chess.Source.Common.ConsoleHelpers;
    using Chess.Source.Common;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "CHESS";
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

        public void RenderMainMenu()
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - Logo.Length / 2;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(centerCol, centerRow);

            // TODO: add main menu
            
            Console.WriteLine(Logo);

            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            // TODO: Validate console dimensions

            Console.Clear();

            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            int counter = 0;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentColPrint = startRowPrint + left * ConsoleConstants.CharactersPerColPerBoardSquare;
                    currentRowPrint = startColPrint + top * ConsoleConstants.CharactersPerRowPerBoardSquare;

                    ConsoleColor background;
                    if (counter % 2 == 0)
                    {
                        background = DarkSquareConsoleColor;
                        Console.BackgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        background = LightSquareConsoleColor;
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }
                    
                    var position = new Position(board.TotalRows - top, (char)(left + 'a'));

                    var figure = board.GetFigureAtPosition(position);

                    ConsolePrintFigure.Print(figure, background, currentRowPrint, currentColPrint);

                    counter++;
                }
                counter++;
            }
            Console.ReadLine();
        }
    }
}
