namespace Chess.Source.Players
{
    using System;
    using System.Collections.Generic;

    using Chess.Source.Figures.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Players.Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            this.figures = new List<IFigure>();
            this.Name = name;
            this.Color = color;
        }

        public string Name { get; private set; }

        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessages);
            if (this.Color != figure.Color)
            {
                throw new InvalidOperationException("The figure you want to add, is not your color!");
            }
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessages);
            if (this.Color != figure.Color)
            {
                throw new InvalidOperationException("The figure that you want to delete is not your color!");
            }
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
