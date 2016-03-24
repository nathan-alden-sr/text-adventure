using System;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Engine.Objects
{
    public static class MessageBusExtensions
    {
        public static void Execute<TBeforeMessage, TBeforeData, TAfterMessage, TAfterData>(this MessageBus messageBus, Action @delegate, Func<TBeforeMessage> publishBeforeDelegate = null, Func<TAfterMessage> publishAfterDelegate = null)
            where TBeforeMessage : class, IMessage<TBeforeData>
            where TAfterMessage : class, IMessage<TAfterData>
        {
            messageBus.ThrowIfNull(nameof(messageBus));
            @delegate.ThrowIfNull(nameof(@delegate));

            if (publishBeforeDelegate != null && messageBus.Publish(publishBeforeDelegate()) == PublishResult.Cancel)
            {
                return;
            }

            @delegate();

            if (publishAfterDelegate != null)
            {
                messageBus.Publish(publishAfterDelegate());
            }
        }

        public static void Execute<TBeforeMessage, TAfterMessage>(this MessageBus messageBus, Action @delegate, Func<TBeforeMessage> publishBeforeDelegate = null, Func<TAfterMessage> publishAfterDelegate = null)
            where TBeforeMessage : class, IMessage
            where TAfterMessage : class, IMessage
        {
            messageBus.ThrowIfNull(nameof(messageBus));
            @delegate.ThrowIfNull(nameof(@delegate));

            if (publishBeforeDelegate != null && messageBus.Publish(publishBeforeDelegate()) == PublishResult.Cancel)
            {
                return;
            }

            @delegate();

            if (publishAfterDelegate != null)
            {
                messageBus.Publish(publishAfterDelegate());
            }
        }
    }
}