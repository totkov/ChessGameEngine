namespace Chess.Source.Figures
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }
    }
}