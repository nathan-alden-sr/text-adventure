namespace NathanAlden.TextAdventure.Engine
{
    public interface IMessage
    {
        long Id { get; }
    }

    public interface IMessage<out TData> : IMessage
    {
        TData Data { get; }
    }
}