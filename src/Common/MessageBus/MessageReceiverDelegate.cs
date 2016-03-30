namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public delegate ReceiveMessageResult MessageReceiverDelegate<in TMessage>(TMessage message)
        where TMessage : class, IMessage;
}