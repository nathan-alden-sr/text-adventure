namespace NathanAlden.TextAdventure.Engine
{
    public interface IBoardLayerCollection<out T>
        where T : IBoardLayer
    {
        T Floor { get; }
        T Player { get; }
        T Ceiling { get; }
    }
}