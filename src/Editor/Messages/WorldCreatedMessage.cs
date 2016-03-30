using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Messages
{
    public class WorldCreatedMessage : Message<WorldModel>
    {
        public WorldCreatedMessage(WorldModel data)
            : base(data)
        {
        }
    }
}