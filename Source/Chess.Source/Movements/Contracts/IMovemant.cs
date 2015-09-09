namespace Chess.Source.Movements.Contracts
{
    using Chess.Source.Board.Contracts;
    using Chess.Source.Figures.Contracts;

    public interface IMovemant
    {
        void VlidateMove(IFigure figure, IBoard board);
    }
}