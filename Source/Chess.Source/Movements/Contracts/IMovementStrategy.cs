namespace Chess.Source.Movements.Contracts
{
    using System.Collections.Generic;

    public interface IMovementStrategy
    {
        IList<IMovement> GetMovements(string figure);
    }
}
