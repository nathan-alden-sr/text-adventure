using NathanAlden.TextAdventure.Common.MessageBus;

namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class BoardAddingMessage : Message<IBoard>
    {
        public BoardAddingMessage(IBoard data)
            : base(data)
        {
        }
    }
}