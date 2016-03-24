namespace NathanAlden.TextAdventure.Engine
{
    public interface IMessageReceiver<in TMessage>
        where TMessage : class, IMessage
    {
        ReceiveMessageResult ReceiveMessage(TMessage message);
    }

    public interface IMessageReceiver<in TMessage, TData>
        where TMessage : class, IMessage<TData>
    {
        ReceiveMessageResult ReceiveMessage(TMessage message);
    }
}