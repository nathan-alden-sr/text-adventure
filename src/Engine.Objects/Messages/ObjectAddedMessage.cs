namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectAddedMessage : Message<ObjectAddedMessageData>
    {
        public ObjectAddedMessage(ObjectAddedMessageData data)
            : base(data)
        {
        }
    }
}