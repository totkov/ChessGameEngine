namespace Chess.Source.Movements
{
    using System;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class NormalRookMovement : IMovement
    {
        public void VlidateMove(IFigure figure, IBoard board, Move move)
        {
            Position from = move.From;
            Position to = move.To;

            if (from.Row != to.Row && from.Col != to.Col)
            {
                throw new InvalidOperationException("Rook cannot move this way!");
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
            else
            {
                throw new InvalidOperationException("Rook cannot move this way!");
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
                    throw new InvalidOperationException("Rook cannot move this way!");
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
                    throw new InvalidOperationException("Rook cannot move this way!");
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
                    throw new InvalidOperationException("Rook cannot move this way!");
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
                    throw new InvalidOperationException("Rook cannot move this way!");
                }
                currentCol++;
            }
        }
    }
}
