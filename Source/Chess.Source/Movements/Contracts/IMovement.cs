namespace Chess.Source.Movements.Contracts
{
    using Chess.Source.Board.Contracts;
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public interface IMovement
    {
        void VlidateMove(IFigure figure, IBoard board, Move move);
    }
}