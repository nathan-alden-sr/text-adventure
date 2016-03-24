using NathanAlden.TextAdventure.Engine;
using NSubstitute;
using NUnit.Framework;

namespace NathanAlden.TextAdventure.UnitTests.Engine
{
    [TestFixture]
    public class MessageBusTests
    {
        [Test]
        public void MustHonorUnsubscribeRequestsForMessageReceiversWithData()
        {
            var messageBus = new MessageBus();
            var subscriber = Substitute.For<IMessageReceiver<IMessage<object>, object>>();

            messageBus.Subscribe(subscriber);
            messageBus.Unsubscribe(subscriber);

            var message = Substitute.For<IMessage<object>>();

            messageBus.Publish<IMessage<object>, object>(message);

            subscriber.DidNotReceive().ReceiveMessage(message);
        }

        [Test]
        public void MustHonorUnsubscribeRequestsForMessageReceiversWithoutData()
        {
            var messageBus = new MessageBus();
            var subscriber = Substitute.For<IMessageReceiver<IMessage>>();

            messageBus.Subscribe(subscriber);
            messageBus.Unsubscribe(subscriber);

            var message = Substitute.For<IMessage>();

            messageBus.Publish(message);

            subscriber.DidNotReceive().ReceiveMessage(message);
        }

        [Test]
        public void MustInvokeEvents()
        {
            var messageBus = new MessageBus();
            var messageReceiverSubscribedInvoked = false;
            var messageReceiverUnsubscribedInvoked = false;
            var messageWithDataPublishingInvoked = false;
            var messageWithDataPublishedInvoked = false;
            var messageWithoutDataPublishingInvoked = false;
            var messageWithoutDataPublishedInvoked = false;

            messageBus.MessageReceiverSubscribed += (receiver, messageType, priority) => { messageReceiverSubscribedInvoked = true; };
            messageBus.MessageReceiverUnsubscribed += (receiver, messageType) => { messageReceiverUnsubscribedInvoked = true; };
            messageBus.MessageWithDataPublishing += (messageType, message, data) => { messageWithDataPublishingInvoked = true; };
            messageBus.MessageWithDataPublished += (messageType, message, data) => { messageWithDataPublishedInvoked = true; };
            messageBus.MessageWithoutDataPublishing += (messageType, message) => { messageWithoutDataPublishingInvoked = true; };
            messageBus.MessageWithoutDataPublished += (messageType, message) => { messageWithoutDataPublishedInvoked = true; };

            messageBus.Subscribe(Substitute.For<IMessageReceiver<IMessage>>());
            messageBus.Subscribe(Substitute.For<IMessageReceiver<IMessage<object>, object>>());
            messageBus.Unsubscribe(Substitute.For<IMessageReceiver<IMessage>>());
            messageBus.Unsubscribe(Substitute.For<IMessageReceiver<IMessage<object>, object>>());
            messageBus.Publish(Substitute.For<IMessage>());
            messageBus.Publish<IMessage<object>, object>(Substitute.For<IMessage<object>, object>());

            Assert.That(messageReceiverSubscribedInvoked, Is.True);
            Assert.That(messageReceiverUnsubscribedInvoked, Is.True);
            Assert.That(messageWithDataPublishingInvoked, Is.True);
            Assert.That(messageWithDataPublishedInvoked, Is.True);
            Assert.That(messageWithoutDataPublishingInvoked, Is.True);
            Assert.That(messageWithoutDataPublishedInvoked, Is.True);
        }

        [Test]
        public void MustPublishToCorrectSubscribersForMessageReceiversWithData()
        {
            var messageBus = new MessageBus();
            var subscriber1 = Substitute.For<IMessageReceiver<IMessage<object>, object>>();
            var subscriber2 = Substitute.For<IMessageReceiver<IMessage<object>, object>>();

            messageBus.Subscribe(subscriber1);
            messageBus.Subscribe(subscriber2);

            var message = Substitute.For<IMessage<object>>();

            messageBus.Publish<IMessage<object>, object>(message);

            subscriber1.Received().ReceiveMessage(message);
            subscriber2.DidNotReceive().ReceiveMessage(Arg.Any<IMessage<object>>());
        }

        [Test]
        public void MustPublishToCorrectSubscribersForMessageReceiversWithoutData()
        {
            var messageBus = new MessageBus();
            var subscriber1 = Substitute.For<IMessageReceiver<IMessage>>();
            var subscriber2 = Substitute.For<IMessageReceiver<IMessage>>();

            messageBus.Subscribe(subscriber1);
            messageBus.Subscribe(subscriber2);

            var message = Substitute.For<IMessage>();

            messageBus.Publish(message);

            subscriber1.Received().ReceiveMessage(message);
            subscriber2.DidNotReceive().ReceiveMessage(Arg.Any<IMessage>());
        }

        [Test]
        public void MustPublishToSubscribersInPriorityOrderForMessageReceiversWithData()
        {
            var messageBus = new MessageBus();
            var subscriber1 = Substitute.For<IMessageReceiver<IMessage<object>, object>>();
            var subscriber2 = Substitute.For<IMessageReceiver<IMessage<object>, object>>();
            var message = Substitute.For<IMessage<object>>();

            subscriber1.ReceiveMessage(message).Returns(ReceiveMessageResult.Continue);
            subscriber2.ReceiveMessage(message).Returns(ReceiveMessageResult.Continue);

            messageBus.Subscribe(subscriber1, 100);
            messageBus.Subscribe(subscriber2, 200);

            messageBus.Publish<IMessage<object>, object>(message);

            Received.InOrder(
                () =>
                {
                    subscriber2.ReceiveMessage(message);
                    subscriber1.ReceiveMessage(message);
                });
        }

        [Test]
        public void MustPublishToSubscribersInPriorityOrderForMessageReceiversWithoutData()
        {
            var messageBus = new MessageBus();
            var subscriber1 = Substitute.For<IMessageReceiver<IMessage>>();
            var subscriber2 = Substitute.For<IMessageReceiver<IMessage>>();
            var message = Substitute.For<IMessage>();

            subscriber1.ReceiveMessage(message).Returns(ReceiveMessageResult.Continue);
            subscriber2.ReceiveMessage(message).Returns(ReceiveMessageResult.Continue);

            messageBus.Subscribe(subscriber1, 100);
            messageBus.Subscribe(subscriber2, 200);

            messageBus.Publish(message);

            Received.InOrder(
                () =>
                {
                    subscriber2.ReceiveMessage(message);
                    subscriber1.ReceiveMessage(message);
                });
        }
    }
}