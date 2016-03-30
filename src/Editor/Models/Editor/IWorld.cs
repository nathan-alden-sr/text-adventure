using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Models.Editor
{
    public interface IWorld
    {
        WorldModel Model { get; }
        WorldStatus Status { get; }
        string Path { get; }
    }
}