namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public class BoardRemovingMessage : Message<IBoard>
    {
        public BoardRemovingMessage(IBoard data)
            : base(data)
        {
        }
    }
}