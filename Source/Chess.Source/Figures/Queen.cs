namespace Chess.Source.Figures
{
    using System.Collections.Generic;

    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            throw new System.NotImplementedException();
        }
    }
}