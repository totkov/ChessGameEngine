namespace Chess.Source.Movements
{
    using System;

    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class NormalKingMovement : IMovement
    {
        // TODO: Castling checking

        public void VlidateMove(IFigure figure, IBoard board, Move move)
        {
            Position from = move.From;
            Position to = move.To;

            bool condition = (
                ((from.Col + 1) == to.Col) ||
                ((from.Col - 1) == to.Col) ||
                ((from.Row + 1) == to.Row) ||
                ((from.Row - 1) == to.Row) ||
                (((from.Row + 1) == to.Row) && ((from.Col + 1) == to.Col)) ||
                (((from.Row - 1) == to.Row) && ((from.Col + 1) == to.Col)) ||
                (((from.Row - 1) == to.Row) && ((from.Col - 1) == to.Col)) ||
                (((from.Row + 1) == to.Row) && ((from.Col - 1) == to.Col))
                );

            if (condition)
            {
                return;
            }
            else
            {
                throw new InvalidOperationException("King cannot move this way!");
            }
        }
    }
}
