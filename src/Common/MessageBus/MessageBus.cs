using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly Dictionary<Type, object> _subjectsByMessageType = new Dictionary<Type, object>();

        protected bool Disposed { get; private set; }

        public IDisposable Subscribe<TMessage>(Action<TMessage> messageDelegate)
            where TMessage : IMessage
        {
            return GetObservable<TMessage>().Subscribe(messageDelegate);
        }

        public void Publish<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            this.ThrowIfDisposed(Disposed);

            GetSubject<TMessage>().OnNext(message);
        }

        public void Publish<TMessage>()
            where TMessage : IMessage, new()
        {
            this.ThrowIfDisposed(Disposed);

            Publish(new TMessage());
        }

        public IObservable<TMessage> GetObservable<TMessage>()
            where TMessage : IMessage
        {
            this.ThrowIfDisposed(Disposed);

            return GetSubject<TMessage>().AsObservable();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MessageBus()
        {
            Dispose(false);
        }

        private Subject<TMessage> GetSubject<TMessage>()
            where TMessage : IMessage
        {
            this.ThrowIfDisposed(Disposed);

            Type messageType = typeof(TMessage);
            object subject;
            Subject<TMessage> genericSubject;

            if (_subjectsByMessageType.TryGetValue(messageType, out subject))
            {
                genericSubject = (Subject<TMessage>)subject;
            }
            else
            {
                genericSubject = new Subject<TMessage>();
                _subjectsByMessageType.Add(messageType, genericSubject);
            }

            return genericSubject;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }
            if (disposing)
            {
                foreach (IDisposable subject in _subjectsByMessageType.Values)
                {
                    subject.Dispose();
                }

                _subjectsByMessageType.Clear();
            }

            Disposed = true;
        }
    }
}