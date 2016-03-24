namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectAddingMessageData
    {
        public ObjectAddingMessageData(IObject @object, IObject parentObject)
        {
            Object = @object;
            ParentObject = parentObject;
        }

        public IObject Object { get; }
        public IObject ParentObject { get; }
    }
}