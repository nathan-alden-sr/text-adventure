namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectAddedMessageData
    {
        public ObjectAddedMessageData(IObject @object, IObject parentObject)
        {
            Object = @object;
            ParentObject = parentObject;
        }

        public IObject Object { get; }
        public IObject ParentObject { get; }
    }
}