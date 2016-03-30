using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Models.Editor;

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