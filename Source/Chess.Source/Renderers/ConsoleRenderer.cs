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

        public ConsoleRenderer()
        {
            Console.SetBufferSize(100, 82);

            //if (Console.WindowWidth < 100 || Console.WindowHeight < 78)
            //{
            //    Console.BackgroundColor = ConsoleColor.Black;
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Clear();
            //    Console.WriteLine("Please, set the Console window and buffer size to 100x78. For best experience use Raster Fonts 8x8");
            //    Environment.Exit(0);
            //}
        }

        public void RenderMainMenu()
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - Logo.Length / 2;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.SetCursorPosition(centerCol, centerRow);

            // TODO: add main menu
            
            Console.WriteLine(Logo);

            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            Console.Clear();

            var startRowPrint = Console.BufferWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.BufferHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            this.PrintBorder(startRowPrint, startColPrint, board.TotalRows, board.TotalCols);

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

            Console.SetCursorPosition(Console.WindowWidth / 2, 1);
        }

        public void PrintErrorMessage(string error)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
            Console.Write(error);

            Thread.Sleep(2000);

            //Clear console row
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        private void PrintBorder(int startRowPrint, int startColPrint, int boardTotalRows, int boardTotalCols)
        {
            var start = startRowPrint + (ConsoleConstants.CharactersPerRowPerBoardSquare / 2);
            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startColPrint - 1);
                Console.Write((char)('A' + i));
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startColPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare));
                Console.Write((char)('A' + i));
            }

            start = startColPrint + (ConsoleConstants.CharactersPerColPerBoardSquare / 2);
            for (int i = 0; i < boardTotalRows; i++)
            {
                Console.SetCursorPosition(startRowPrint - 1, start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(boardTotalRows - i);
                Console.SetCursorPosition(startRowPrint + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare), start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(boardTotalRows - i);
            }

            // TODO: check this math!
            for (int i = startRowPrint - 2; i < startRowPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint - 2);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint - 2, i);
                Console.Write(" ");
            }
        }
    }
}
