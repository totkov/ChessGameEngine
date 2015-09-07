namespace Chess.Source.Players
{
    using System;
    using System.Collections.Generic;

    using Chess.Source.Figures.Contracts;
    using Chess.Source.Common;

    public class Player
    {
        private readonly ICollection<IFigure> figures;

        public Player(ChessColor color)
        {
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessages);
            // TODO: check figure and player color
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessages);
            // TODO: check figure and player color
            this.CheckIfFigureDoesNotExists(figure);
            this.figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExists(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player does not own this figure!");
            }
        }
    }
}
