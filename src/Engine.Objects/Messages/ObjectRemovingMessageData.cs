namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class ObjectRemovingMessageData
    {
        public ObjectRemovingMessageData(IObject @object, IObject parentObject)
        {
            Object = @object;
            ParentObject = parentObject;
        }

        public IObject Object { get; }
        public IObject ParentObject { get; }
    }
}