namespace NathanAlden.TextAdventure.Engine.Objects.Messages
{
    public abstract class Message
    {
        private static long _counter;

        protected Message()
        {
            Id = IncrementCounter();
        }

        public long Id { get; }

        protected static long IncrementCounter()
        {
            return ++_counter;
        }
    }

    public abstract class Message<TData> : Message, IMessage<TData>
    {
        protected Message(TData data)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}