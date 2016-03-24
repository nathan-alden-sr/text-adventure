using System;
using System.Collections;
using System.Collections.Generic;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Engine
{
    public class ObjectCollection<T> : IObjectCollection<T>
        where T : class, IObject
    {
        private readonly HashSet<T> _objects = new HashSet<T>();

        bool IObjectCollection<T>.Contains(T @object)
        {
            return Contains(@object);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _objects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T @object)
        {
            return _objects.Contains(@object);
        }

        public virtual void Add(T @object)
        {
            @object.ThrowIfNull(nameof(@object));

            if (_objects.Contains(@object))
            {
                throw new ArgumentException("Object already added.", nameof(@object));
            }

            _objects.Add(@object);
        }

        public virtual bool Remove(T @object)
        {
            @object.ThrowIfNull(nameof(@object));

            return _objects.Remove(@object);
        }
    }
}