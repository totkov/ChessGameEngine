﻿namespace Chess.Source.Figures
{
    using System.Collections.Generic;

    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;
    using Chess.Source.Movements.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy movementStrategy)
        {
            return movementStrategy.GetMovements(this.GetType().Name);
        }
    }
}