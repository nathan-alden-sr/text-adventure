using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    public interface IWorld
    {
        WorldModel Model { get; }
        WorldStatus Status { get; }
        string Path { get; }
    }
}