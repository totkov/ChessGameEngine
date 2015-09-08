namespace Chess.Source.Renderers.Contracts
{
    using Chess.Source.Board.Contracts;

    public interface IRenderer
    {
        void RenderMainMenu();
        void RenderBoard(IBoard board);
    }
}
