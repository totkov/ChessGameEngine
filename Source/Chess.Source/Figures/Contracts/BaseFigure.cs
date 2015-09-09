namespace Chess.Source.Figures.Contracts
{
    using System.Collections.Generic;

    using Chess.Source.Common;
    using Chess.Source.Movements.Contracts;

    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public abstract ICollection<IMovemant> Move();
    }
}
