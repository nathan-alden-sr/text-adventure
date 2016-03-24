using System.Collections.Generic;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IInputHandler : IHandler
    {
        InputHandlerResult Handle(IEnumerable<Key> keys, IEnumerable<ModifierKey> modifierKeys);
    }
}