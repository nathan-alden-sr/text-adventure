namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public interface IMessage
    {
        ulong Id { get; }
    }

    public interface IMessage<out TData> : IMessage
    {
        TData Data { get; }
    }
}