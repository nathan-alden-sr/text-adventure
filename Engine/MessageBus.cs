using System;
using System.Collections.Generic;
using System.Linq;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Engine
{
    public class MessageBus
    {
        public delegate void MessageReceiverSubscribedDelegate(object receiver, Type messageType, int priority = 0);

        public delegate void MessageReceiverUnsubscribedDelegate(object receiver, Type messageType);

        public delegate void MessageWithDataPublishedDelegate(Type messageType, IMessage message, object data);

        public delegate void MessageWithDataPublishingDelegate(Type messageType, IMessage message, object data);

        public delegate void MessageWithoutDataPublishedDelegate(Type messageType, IMessage message);

        public delegate void MessageWithoutDataPublishingDelegate(Type messageType, IMessage message);

        private readonly Dictionary<Type, SortedSet<IMessageReceiver>> _subscribersByMessageType = new Dictionary<Type, SortedSet<IMessageReceiver>>();

        public event MessageReceiverSubscribedDelegate MessageReceiverSubscribed;
        public event MessageReceiverUnsubscribedDelegate MessageReceiverUnsubscribed;
        public event MessageWithDataPublishingDelegate MessageWithDataPublishing;
        public event MessageWithDataPublishedDelegate MessageWithDataPublished;
        public event MessageWithoutDataPublishingDelegate MessageWithoutDataPublishing;
        public event MessageWithoutDataPublishedDelegate MessageWithoutDataPublished;

        public PublishResult Publish<TMessage, TData>(TMessage message)
            where TMessage : class, IMessage<TData>
        {
            message.ThrowIfNull(nameof(message));

            SortedSet<IMessageReceiver> subscribers;
            Type messageType = typeof(TMessage);
            var result = ReceiveMessageResult.Continue;

            MessageWithDataPublishing?.Invoke(messageType, message, message.Data);

            if (_subscribersByMessageType.TryGetValue(typeof(TMessage), out subscribers) && subscribers.Any())
            {
                foreach (IMessageReceiver<TMessage, TData> receiver in subscribers.Select(x => (IMessageReceiver<TMessage, TData>)x.Receiver))
                {
                    result = receiver.ReceiveMessage(message);

                    if (result == ReceiveMessageResult.Cancel)
                    {
                        break;
                    }
                }
            }

            MessageWithDataPublished?.Invoke(messageType, message, message.Data);

            return result == ReceiveMessageResult.Cancel ? Engine.PublishResult.Cancel : Engine.PublishResult.Continue;
        }

        public PublishResult Publish<TMessage>(TMessage message) where TMessage : class, IMessage
        {
            message.ThrowIfNull(nameof(message));

            SortedSet<IMessageReceiver> subscribers;
            Type messageType = typeof(TMessage);
            var result = ReceiveMessageResult.Continue;

            MessageWithoutDataPublishing?.Invoke(messageType, message);

            if (_subscribersByMessageType.TryGetValue(typeof(TMessage), out subscribers))
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (IMessageReceiver<TMessage> receiver in subscribers.Select(x => (IMessageReceiver<TMessage>)x.Receiver))
                {
                    result = receiver.ReceiveMessage(message);

                    if (result == ReceiveMessageResult.Cancel)
                    {
                        break;
                    }
                }
            }

            MessageWithoutDataPublished?.Invoke(messageType, message);

            return result == ReceiveMessageResult.Cancel ? Engine.PublishResult.Cancel : Engine.PublishResult.Continue;
        }

        public void Subscribe<TMessage>(IMessageReceiver<TMessage> receiver, int priority = 0) where TMessage : class, IMessage
        {
            receiver.ThrowIfNull(nameof(receiver));

            Type messageType = typeof(TMessage);

            Subscribe(receiver, messageType, priority);

            MessageReceiverSubscribed?.Invoke(receiver, messageType, priority);
        }

        public void Subscribe<TMessage, TData>(IMessageReceiver<TMessage, TData> receiver, int priority = 0) where TMessage : class, IMessage<TData>
        {
            receiver.ThrowIfNull(nameof(receiver));

            Subscribe(receiver, typeof(TMessage), priority);
        }

        public void Unsubscribe<TMessage>(IMessageReceiver<TMessage> receiver) where TMessage : class, IMessage
        {
            receiver.ThrowIfNull(nameof(receiver));

            Type messageType = typeof(TMessage);

            Unsubscribe(receiver, typeof(TMessage));

            MessageReceiverUnsubscribed?.Invoke(receiver, messageType);
        }

        public void Unsubscribe<TMessage, TData>(IMessageReceiver<TMessage, TData> receiver) where TMessage : class, IMessage<TData>
        {
            receiver.ThrowIfNull(nameof(receiver));

            Unsubscribe(receiver, typeof(TMessage));
        }

        private void Subscribe(object receiver, Type messageType, int priority)
        {
            SortedSet<IMessageReceiver> subscribers;

            if (!_subscribersByMessageType.TryGetValue(messageType, out subscribers))
            {
                subscribers = new SortedSet<IMessageReceiver>(new MessageSubscriberComparer());
                _subscribersByMessageType.Add(messageType, subscribers);
            }
            else if (subscribers.Any(x => x.Receiver == receiver))
            {
                throw new ArgumentException($"Subscriber is already subscribed to message type {messageType.FullName}.", nameof(messageType));
            }

            subscribers.Add(new MessageReceiver(receiver, priority));
        }

        private void Unsubscribe(object receiver, Type messageType)
        {
            SortedSet<IMessageReceiver> receivers;

            if (_subscribersByMessageType.TryGetValue(messageType, out receivers))
            {
                receivers.RemoveWhere(x => x.Receiver == receiver);
            }
        }

        private interface IMessageReceiver
        {
            object Receiver { get; }
            int Priority { get; }
        }

        private class MessageReceiver : IMessageReceiver
        {
            public MessageReceiver(object receiver, int priority)
            {
                Receiver = receiver;
                Priority = priority;
            }

            public object Receiver { get; }
            public int Priority { get; }
        }

        private class MessageSubscriberComparer : IComparer<IMessageReceiver>
        {
            public int Compare(IMessageReceiver x, IMessageReceiver y)
            {
                return y.Priority.CompareTo(x.Priority);
            }
        }
    }
}