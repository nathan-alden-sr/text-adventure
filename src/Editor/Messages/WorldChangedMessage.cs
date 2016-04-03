using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Controllers.World;

namespace NathanAlden.TextAdventure.Editor.Messages
{
    public class WorldChangedMessage : Message<IWorld>
    {
        public WorldChangedMessage(IWorld data)
            : base(data)
        {
        }
    }
}