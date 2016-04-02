using System.Collections.Generic;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common
{
    public static class ListExtensions
    {
        public static void AddRange<T>(this List<T> list, params T[] objects)
        {
            list.ThrowIfNull(nameof(list));

            list.AddRange(objects ?? new T[0]);
        }
    }
}