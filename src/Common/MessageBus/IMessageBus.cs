using System;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        IDisposable Subscribe<TMessage>(Action<TMessage> messageDelegate)
            where TMessage : IMessage;

        void Publish<TMessage>(TMessage message)
            where TMessage : IMessage;

        void Publish<TMessage>()
            where TMessage : IMessage, new();

        IObservable<TMessage> GetObservable<TMessage>()
            where TMessage : IMessage;
    }
}