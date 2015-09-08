namespace Chess.Source.Figures.Contracts
{
    using Chess.Source.Common;

    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }
    }
}
