using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Engine
{
    public class HandlerCollection<T> : IEnumerable<T>
        where T : class, IHandler
    {
        private readonly HashSet<T> _handlers = new HashSet<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return _handlers.OrderBy(x => x.Priority).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T handler)
        {
            handler.ThrowIfNull(nameof(handler));

            if (_handlers.Contains(handler))
            {
                throw new ArgumentException("Handler already added.", nameof(handler));
            }

            _handlers.Add(handler);
        }

        public bool Remove(T handler)
        {
            handler.ThrowIfNull(nameof(handler));

            return _handlers.Remove(handler);
        }
    }
}