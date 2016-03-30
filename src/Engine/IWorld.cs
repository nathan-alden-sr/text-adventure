using System.Collections.Generic;
using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IWorld : IObject
    {
        MessageBus MessageBus { get; }
        IEnumerable<IBoard> Boards { get; }
        IEnumerable<IInputHandler> InputHandlers { get; }
        IPlayer Player { get; }
        string Name { get; }
        uint EngineVersion { get; }

        void Prepare();
    }
}