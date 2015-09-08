namespace Chess.Source.Players.Contracts
{
    using Chess.Source.Common;
    using Chess.Source.Figures.Contracts;

    public interface IPlayer
    {
        string Name { get; }
        ChessColor Color { get; }
        void AddFigure(IFigure figure);
        void RemoveFigure(IFigure figure);
    }
}
