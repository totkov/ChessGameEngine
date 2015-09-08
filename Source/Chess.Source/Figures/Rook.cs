namespace Chess.Source.Figures
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public class Rook : BaseFigure, IFigure
    {
        public Rook(ChessColor color)
            : base(color)
        {
        }
    }
}