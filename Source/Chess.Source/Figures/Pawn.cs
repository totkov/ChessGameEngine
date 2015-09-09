namespace Chess.Source.Figures
{
    using System.Collections.Generic;

    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;
    using Chess.Source.Movements;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        { 
        }

        public override ICollection<IMovement> Move()
        {
            return new List<IMovement>
            {
                new NormalPawnMovement()
            };
        }
    }
}
