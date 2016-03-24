using System.Collections.Generic;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IObjectCollection<T> : IEnumerable<T>
        where T : IObject
    {
        bool Contains(T @object);
    }
}