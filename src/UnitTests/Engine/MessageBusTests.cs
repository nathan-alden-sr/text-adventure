using NathanAlden.TextAdventure.Common.MessageBus;
using NSubstitute;
using NUnit.Framework;

namespace NathanAlden.TextAdventure.UnitTests.Engine
{
    [TestFixture]
    public class MessageBusTests
    {
        [Test]
        public void MustHonorUnsubscribeRequests()
        {
            var messageBus = new MessageBus();
            var receiverDelegate = Substitute.For<MessageReceiverDelegate<IMessage>>();

            messageBus.Subscribe(receiverDelegate);
            messageBus.Unsubscribe(receiverDelegate);

            var message = Substitute.For<IMessage>();

            messageBus.Publish(message);

            receiverDelegate.DidNotReceive()(message);
        }

        [Test]
        public void MustInvokeEvents()
        {
            var messageBus = new MessageBus();
            var messageReceiverSubscribedInvoked = false;
            var messageReceiverUnsubscribedInvoked = false;
            var messagePublishingInvoked = false;
            var messagePublishedInvoked = false;

            messageBus.MessageReceiverSubscribed += (receiver, messageType, priority) => { messageReceiverSubscribedInvoked = true; };
            messageBus.MessageReceiverUnsubscribed += (receiver, messageType) => { messageReceiverUnsubscribedInvoked = true; };
            messageBus.MessagePublishing += (messageType, message) => { messagePublishingInvoked = true; };
            messageBus.MessagePublished += (messageType, message) => { messagePublishedInvoked = true; };

            messageBus.Subscribe(Substitute.For<MessageReceiverDelegate<IMessage>>());
            messageBus.Unsubscribe(Substitute.For<MessageReceiverDelegate<IMessage>>());
            messageBus.Publish(Substitute.For<IMessage>());

            Assert.That(messageReceiverSubscribedInvoked, Is.True);
            Assert.That(messageReceiverUnsubscribedInvoked, Is.True);
            Assert.That(messagePublishingInvoked, Is.True);
            Assert.That(messagePublishedInvoked, Is.True);
        }

        [Test]
        public void MustPublishToCorrectSubscribers()
        {
            var messageBus = new MessageBus();
            var receiverDelegate1 = Substitute.For<MessageReceiverDelegate<IMessage>>();
            var receiverDelegate2 = Substitute.For<MessageReceiverDelegate<IMessage<object>>>();

            messageBus.Subscribe(receiverDelegate1);
            messageBus.Subscribe(receiverDelegate2);

            var message = Substitute.For<IMessage>();

            messageBus.Publish(message);

            receiverDelegate1.Received()(message);
            receiverDelegate2.DidNotReceive()(Arg.Any<IMessage<object>>());
        }

        [Test]
        public void MustPublishToSubscribersInPriorityOrder()
        {
            var messageBus = new MessageBus();
            var receiverDelegate1 = Substitute.For<MessageReceiverDelegate<IMessage>>();
            var receiverDelegate2 = Substitute.For<MessageReceiverDelegate<IMessage>>();
            var message = Substitute.For<IMessage>();

            receiverDelegate1(message).Returns(ReceiveMessageResult.Continue);
            receiverDelegate2(message).Returns(ReceiveMessageResult.Continue);

            messageBus.Subscribe(receiverDelegate1, 100);
            messageBus.Subscribe(receiverDelegate2, 200);

            messageBus.Publish(message);

            Received.InOrder(
                () =>
                {
                    receiverDelegate2(message);
                    receiverDelegate1(message);
                });
        }
    }
}