namespace Chess.Source.Board.Contracts
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }
        void AddFigure(IFigure figure, Position position);
        void RemoveFigure(Position position);
        IFigure GetFigureAtPosition(Position position);
    }
}
