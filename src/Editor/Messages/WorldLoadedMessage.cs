using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Controllers.World;

namespace NathanAlden.TextAdventure.Editor.Messages
{
    public class WorldLoadedMessage : Message<IWorld>
    {
        public WorldLoadedMessage(IWorld data)
            : base(data)
        {
        }
    }
}