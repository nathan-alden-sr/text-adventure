using System.Collections.Generic;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Engine
{
    public class KeyHelper
    {
        public KeyHelper(IEnumerable<Key> keys, IEnumerable<ModifierKey> modifierKeys)
        {
            keys.ThrowIfNull(nameof(keys));
            modifierKeys.ThrowIfNull(nameof(modifierKeys));

            Keys = keys;
            ModifierKeys = modifierKeys;
        }

        public IEnumerable<Key> Keys { get; }
        public IEnumerable<ModifierKey> ModifierKeys { get; }
    }
}