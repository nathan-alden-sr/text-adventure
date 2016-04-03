using System.Collections.Generic;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Engine
{
    public class KeyHelper
    {
        public KeyHelper(IEnumerable<Key> keys, IEnumerable<ModifierKey> modifierKeys)
        {
            Keys = keys.EnsureNotNull(nameof(keys));
            ModifierKeys = modifierKeys.EnsureNotNull(nameof(modifierKeys));
        }

        public IEnumerable<Key> Keys { get; }
        public IEnumerable<ModifierKey> ModifierKeys { get; }
    }
}