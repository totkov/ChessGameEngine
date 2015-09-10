namespace Chess.Source.Movements
{
    using System;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class NormalQueenMovement : IMovement
    {
        // TODO: Reuse bishop and rook logik, non repeat in queen

        public void VlidateMove(IFigure figure, IBoard board, Move move)
        {
            Position from = move.From;
            Position to = move.To;

            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if ((from.Row != to.Row) && (from.Col != to.Col) && (rowDistance != colDistance))
            {
                throw new InvalidOperationException("Queen cannot move this way!");
            }

            if (to.Col > from.Col)
            {
                this.RightChecker(board, from, to);
                return;
            }
            else if (to.Col < from.Col)
            {
                this.LeftChecker(board, from, to);
                return;
            }
            else if (to.Row > from.Row)
            {
                this.TopChecker(board, from, to);
                return;
            }
            else if (to.Row < from.Row)
            {
                this.DownChecker(board, from, to);
                return;
            }
            else if (to.Row > from.Row)
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
            else if (to.Row < from.Row)
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
            else
            {
                throw new InvalidOperationException("Queen cannot move this way!");
            }

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
                    throw new InvalidOperationException("Queen cannot move this way!");
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
                    throw new InvalidOperationException("Queen cannot move this way!");
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
                    throw new InvalidOperationException("Queen cannot move this way!");
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
                    throw new InvalidOperationException("Queen cannot move this way!");
                }
            }
        }

        private void TopChecker(IBoard board, Position from, Position to)
        {
            for (int i = from.Row; i < to.Row - 1; i++)
            {
                Position curentPosition = new Position(i + 1, from.Col);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Queen cannot move this way!");
                }
            }
        }

        private void DownChecker(IBoard board, Position from, Position to)
        {
            for (int i = from.Row; i > to.Row + 1; i--)
            {
                Position curentPosition = new Position(i - 1, from.Col);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Queen cannot move this way!");
                }
            }
        }

        private void LeftChecker(IBoard board, Position from, Position to)
        {
            var currentCol = from.Col - 1;
            for (int i = from.Col; i > to.Col + 1; i--)
            {
                Position curentPosition = new Position(from.Row, (char)currentCol);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Queen cannot move this way!");
                }
                currentCol--;
            }
        }

        private void RightChecker(IBoard board, Position from, Position to)
        {
            var currentCol = from.Col + 1;
            for (int i = from.Col; i < to.Col - 1; i++)
            {
                Position curentPosition = new Position(from.Row, (char)currentCol);
                var figureAtPosition = board.GetFigureAtPosition(curentPosition);
                if (figureAtPosition != null)
                {
                    throw new InvalidOperationException("Queen cannot move this way!");
                }
                currentCol++;
            }
        }
    }
}
