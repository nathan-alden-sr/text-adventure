using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public abstract class Message : IMessage
    {
        private static ulong _counter;

        protected Message()
        {
            Id = IncrementCounter();
        }

        public ulong Id { get; }

        protected static ulong IncrementCounter()
        {
            return ++_counter;
        }
    }

    public abstract class Message<TData> : Message, IMessage<TData>
    {
        protected Message(TData data, bool allowNull = false)
        {
            if (!allowNull)
            {
                data.ThrowIfNull(nameof(data));
            }

            Data = data;
        }

        public TData Data { get; }
    }
}