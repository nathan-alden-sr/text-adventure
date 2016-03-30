namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public interface IMessageBus
    {
        event MessageReceiverSubscribedDelegate MessageReceiverSubscribed;
        event MessageReceiverUnsubscribedDelegate MessageReceiverUnsubscribed;
        event MessagePublishingDelegate MessagePublishing;
        event MessagePublishedDelegate MessagePublished;

        PublishResult Publish<TMessage>(TMessage message)
            where TMessage : class, IMessage;

        PublishResult Publish<TMessage>()
            where TMessage : class, IMessage, new();

        void Subscribe<TMessage>(MessageReceiverDelegate<TMessage> receiverDelegate, int priority = 0)
            where TMessage : class, IMessage;

        void Unsubscribe<TMessage>(MessageReceiverDelegate<TMessage> receiverDelegate)
            where TMessage : class, IMessage;
    }
}