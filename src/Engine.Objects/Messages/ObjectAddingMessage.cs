using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectAddingMessage : Message<ObjectAddingMessageData>
    {
        public ObjectAddingMessage(ObjectAddingMessageData data)
            : base(data)
        {
        }
    }
}