namespace Chess.Source.Figures
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color)
            : base(color)
        {
        }
    }
}