using System;
using System.Collections.Generic;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common
{
    public static class EnumerableExtensions
    {
        public static void Dispose(this IEnumerable<IDisposable> enumerable)
        {
            enumerable.ThrowIfNull(nameof(enumerable));

            foreach (IDisposable disposable in enumerable)
            {
                disposable.Dispose();
            }
        }
    }
}