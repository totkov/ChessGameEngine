namespace Chess.Source.Movements
{
    using System;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class NormalKnightMovement : IMovement
    {
        public void VlidateMove(IFigure figure, IBoard board, Move move)
        {
            Position from = move.From;
            Position to = move.To;

            if ((from.Row + 2) == to.Row && (from.Col - 1) == to.Col)
            {
                return;
            }
            else if ((from.Row + 2) == to.Row && (from.Col + 1) == to.Col)
            {
                return;
            }
            else if ((from.Row + 1) == to.Row && (from.Col + 2) == to.Col)
            {
                return;
            }
            else if ((from.Row - 1) == to.Row && (from.Col + 2) == to.Col)
            {
                return;
            }
            else if ((from.Row - 2) == to.Row && (from.Col + 1) == to.Col)
            {
                return;
            }
            else if ((from.Row - 2) == to.Row && (from.Col - 1) == to.Col)
            {
                return;
            }
            else if ((from.Row - 1) == to.Row && (from.Col - 2) == to.Col)
            {
                return;
            }
            else if ((from.Row + 1) == to.Row && (from.Col - 2) == to.Col)
            {
                return;
            }
            else
            {
                throw new InvalidOperationException("Knight cannot move this way!");
            }
        }
    }
}
