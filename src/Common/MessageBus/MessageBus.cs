using System;
using System.Collections.Generic;
using System.Linq;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly Dictionary<Type, List<IMessageReceiver>> _receiversByMessageType = new Dictionary<Type, List<IMessageReceiver>>();

        public event MessageReceiverSubscribedDelegate MessageReceiverSubscribed;
        public event MessageReceiverUnsubscribedDelegate MessageReceiverUnsubscribed;
        public event MessagePublishingDelegate MessagePublishing;
        public event MessagePublishedDelegate MessagePublished;

        public PublishResult Publish<TMessage>(TMessage message)
            where TMessage : class, IMessage
        {
            message.ThrowIfNull(nameof(message));

            List<IMessageReceiver> receivers;
            Type messageType = typeof(TMessage);
            var result = ReceiveMessageResult.Continue;

            MessagePublishing?.Invoke(messageType, message);

            if (_receiversByMessageType.TryGetValue(typeof(TMessage), out receivers))
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (MessageReceiverDelegate<TMessage> receiver in receivers.OrderByDescending(x => x.Priority).Select(x => (MessageReceiverDelegate<TMessage>)x.ReceiverDelegate))
                {
                    result = receiver(message);

                    if (result == ReceiveMessageResult.Stop)
                    {
                        break;
                    }
                }
            }

            MessagePublished?.Invoke(messageType, message);

            return result == ReceiveMessageResult.Stop ? PublishResult.Canceled : PublishResult.Success;
        }

        public PublishResult Publish<TMessage>()
            where TMessage : class, IMessage, new()
        {
            return Publish(new TMessage());
        }

        public void Subscribe<TMessage>(MessageReceiverDelegate<TMessage> receiverDelegate, int priority = 0)
            where TMessage : class, IMessage
        {
            receiverDelegate.ThrowIfNull(nameof(receiverDelegate));

            Type messageType = typeof(TMessage);
            List<IMessageReceiver> receivers;

            if (!_receiversByMessageType.TryGetValue(messageType, out receivers))
            {
                receivers = new List<IMessageReceiver>();
                _receiversByMessageType.Add(messageType, receivers);
            }
            else if (receivers.Any(x => x.ReceiverDelegate == (Delegate)receiverDelegate))
            {
                throw new ArgumentException($"Subscriber is already subscribed to message type {messageType.FullName}.", nameof(messageType));
            }

            receivers.Add(new MessageReceiver(receiverDelegate, priority));

            MessageReceiverSubscribed?.Invoke(receiverDelegate, messageType, priority);
        }

        public void Unsubscribe<TMessage>(MessageReceiverDelegate<TMessage> receiverDelegate)
            where TMessage : class, IMessage
        {
            receiverDelegate.ThrowIfNull(nameof(receiverDelegate));

            Type messageType = typeof(TMessage);
            List<IMessageReceiver> receivers;

            if (_receiversByMessageType.TryGetValue(typeof(TMessage), out receivers))
            {
                receivers.RemoveAll(x => x.ReceiverDelegate == (Delegate)receiverDelegate);
            }

            MessageReceiverUnsubscribed?.Invoke(receiverDelegate, messageType);
        }

        private interface IMessageReceiver
        {
            Delegate ReceiverDelegate { get; }
            int Priority { get; }
        }

        private class MessageReceiver : IMessageReceiver
        {
            public MessageReceiver(Delegate receiverDelegate, int priority)
            {
                ReceiverDelegate = receiverDelegate;
                Priority = priority;
            }

            public Delegate ReceiverDelegate { get; }
            public int Priority { get; }
        }
    }
}