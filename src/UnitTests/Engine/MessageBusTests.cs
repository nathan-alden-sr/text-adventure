using System;
using NathanAlden.TextAdventure.Common.MessageBus;
using NSubstitute;
using NUnit.Framework;

namespace NathanAlden.TextAdventure.UnitTests.Engine
{
    [TestFixture]
    public class MessageBusTests
    {
        [Test]
        public void MustPublishToCorrectSubscribers()
        {
            var messageBus = new MessageBus();
            var receiverDelegate1 = Substitute.For<Action<IMessage>>();
            var receiverDelegate2 = Substitute.For<Action<IMessage<object>>>();

            messageBus.Subscribe(receiverDelegate1);
            messageBus.Subscribe(receiverDelegate2);

            var message = Substitute.For<IMessage>();

            messageBus.Publish(message);

            receiverDelegate1.Received()(message);
            receiverDelegate2.DidNotReceive()(Arg.Any<IMessage<object>>());
        }

        [Test]
        public void MustUnsubscribeDisposedSubscriptions()
        {
            var messageBus = new MessageBus();
            var receiverDelegate = Substitute.For<Action<IMessage>>();

            messageBus.Subscribe(receiverDelegate).Dispose();

            var message = Substitute.For<IMessage>();

            messageBus.Publish(message);

            receiverDelegate.DidNotReceive()(message);
        }
    }
}