using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectRemovingMessage : Message<ObjectRemovingMessageData>
    {
        public ObjectRemovingMessage(ObjectRemovingMessageData data)
            : base(data)
        {
        }
    }
}