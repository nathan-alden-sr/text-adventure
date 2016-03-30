using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class BoardAddedMessage : Message<IBoard>
    {
        public BoardAddedMessage(IBoard data)
            : base(data)
        {
        }
    }
}