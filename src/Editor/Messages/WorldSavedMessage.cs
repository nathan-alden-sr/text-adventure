using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Controllers.World;

namespace NathanAlden.TextAdventure.Editor.Messages
{
    public class WorldSavedMessage : Message<IWorld>
    {
        public WorldSavedMessage(IWorld data)
            : base(data)
        {
        }
    }
}