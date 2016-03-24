using System.Collections.Generic;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IWorld : IObject
    {
        MessageBus MessageBus { get; }
        IEnumerable<IBoard> Boards { get; }
        IEnumerable<IInputHandler> InputHandlers { get; }
        IPlayer Player { get; }

        void Prepare();
    }
}