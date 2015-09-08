namespace Chess.Source.Figures
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color)
            : base(color)
        {
        }
    }
}