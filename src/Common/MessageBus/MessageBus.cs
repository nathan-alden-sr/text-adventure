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
        private bool _disposed;

        public IDisposable Subscribe<TMessage>(Action<TMessage> messageDelegate)
            where TMessage : IMessage
        {
            return GetObservable<TMessage>().Subscribe(messageDelegate);
        }

        public void Publish<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            this.ThrowIfDisposed(_disposed);

            GetSubject<TMessage>().OnNext(message);
        }

        public void Publish<TMessage>()
            where TMessage : IMessage, new()
        {
            this.ThrowIfDisposed(_disposed);

            Publish(new TMessage());
        }

        public IObservable<TMessage> GetObservable<TMessage>()
            where TMessage : IMessage
        {
            this.ThrowIfDisposed(_disposed);

            return GetSubject<TMessage>().AsObservable();
        }

        public void Dispose()
        {
            Dispose(false);
        }

        ~MessageBus()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private Subject<TMessage> GetSubject<TMessage>()
            where TMessage : IMessage
        {
            this.ThrowIfDisposed(_disposed);

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
            if (_disposed)
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

            _disposed = true;
        }
    }
}