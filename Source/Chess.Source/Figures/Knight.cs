namespace Chess.Source.Figures
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color)
            : base(color)
        { 
        }
    }
}
