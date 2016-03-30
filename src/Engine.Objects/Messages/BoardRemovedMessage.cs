using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class BoardRemovedMessage : Message<IBoard>
    {
        public BoardRemovedMessage(IBoard data)
            : base(data)
        {
        }
    }
}