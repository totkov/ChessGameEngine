namespace Chess.Source.Figures.Contracts
{
    using System.Collections.Generic;

    using Chess.Source.Common;
    using Chess.Source.Movements.Contracts;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovemant> Move();
    }
}
