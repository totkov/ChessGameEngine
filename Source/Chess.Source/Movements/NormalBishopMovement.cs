namespace Chess.Source.Movements
{
    using System;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class NormalBishopMovement : IMovement
    {
        public void VlidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException("Bishop cannot move this way!");
            }

            var from = move.From;
            var to = move.To;

            if (to.Row > from.Row)
            {
                if (to.Col > from.Col)
                {
                    this.TopRightChecker(board, from, to);
                    return;
                }
                if (to.Col < from.Col)
                {
                    this.TopLeftChecker(board, from, to);
                    return;
                }
            }
            if (to.Row < from.Row)
            {
                if (to.Col > from.Col)
                {
                    this.DownRightChecker(board, from, to);
                    return;
                }
                if (to.Col < from.Col)
                {
                    this.DownLeftChecker(board, from, to);
                    return;
                }
            }
            throw new InvalidOperationException("Bishop cannot move this way!");
        }

        private void TopRightChecker(IBoard board, Position from, Position to)
        {
            var fromRow = from.Row;
            var fromCol = from.Col;
            var currentRow = fromRow;
            var currentCol = fromCol;
            while (true)
            {
                currentRow++;
                currentCol++;
                if (currentRow == to.Row && currentCol == to.Col)
                {
                    return;
                }
                Position curentPosition = new Position(currentRow, currentCol);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Bishop cannot move this way!");
                }
            }
        }

        private void DownLeftChecker(IBoard board, Position from, Position to)
        {
            var fromRow = from.Row;
            var fromCol = from.Col;
            var currentRow = fromRow;
            var currentCol = fromCol;
            while (true)
            {
                currentRow--;
                currentCol--;
                if (currentRow == to.Row && currentCol == to.Col)
                {
                    return;
                }
                Position curentPosition = new Position(currentRow, currentCol);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Bishop cannot move this way!");
                }
            }
        }

        private void DownRightChecker(IBoard board, Position from, Position to)
        {
            var fromRow = from.Row;
            var fromCol = from.Col;
            var currentRow = fromRow;
            var currentCol = fromCol;
            while (true)
            {
                currentRow--;
                currentCol++;
                if (currentRow == to.Row && currentCol == to.Col)
                {
                    return;
                }
                Position curentPosition = new Position(currentRow, currentCol);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Bishop cannot move this way!");
                }
            }
        }

        private void TopLeftChecker(IBoard board, Position from, Position to)
        {
            var fromRow = from.Row;
            var fromCol = from.Col;
            var currentRow = fromRow;
            var currentCol = fromCol;
            while (true)
            {
                currentRow++;
                currentCol--;
                if (currentRow == to.Row && currentCol == to.Col)
                {
                    return;
                }
                Position curentPosition = new Position(currentRow, currentCol);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Bishop cannot move this way!");
                }
            }
        }
    }
}
