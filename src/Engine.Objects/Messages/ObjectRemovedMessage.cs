using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectRemovedMessage : Message<ObjectRemovedMessageData>
    {
        public ObjectRemovedMessage(ObjectRemovedMessageData data)
            : base(data)
        {
        }
    }
}