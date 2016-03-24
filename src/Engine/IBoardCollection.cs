namespace NathanAlden.TextAdventure.Engine
{
    public interface IBoardCollection<T> : IObjectCollection<T>
        where T : IBoard
    {
        Size<int> MaximumBoardSize { get; }

        T Find(Coordinate<int> coordinate);
    }
}