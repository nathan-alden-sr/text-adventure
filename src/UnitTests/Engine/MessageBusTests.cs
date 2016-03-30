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
            var messageReceiverSubscribedDelegate = Substitute.For<MessageReceiverSubscribedDelegate>();
            var messageReceiverUnsubscribedDelegate = Substitute.For<MessageReceiverUnsubscribedDelegate>();
            var messagePublishingDelegate = Substitute.For<MessagePublishingDelegate>();
            var messagePublishedDelegate = Substitute.For<MessagePublishedDelegate>();

            messageBus.MessageReceiverSubscribed += messageReceiverSubscribedDelegate;
            messageBus.MessageReceiverUnsubscribed += messageReceiverUnsubscribedDelegate;
            messageBus.MessagePublishing += messagePublishingDelegate;
            messageBus.MessagePublished += messagePublishedDelegate;

            messageBus.Subscribe(Substitute.For<MessageReceiverDelegate<IMessage>>());
            messageBus.Unsubscribe(Substitute.For<MessageReceiverDelegate<IMessage>>());
            messageBus.Publish(Substitute.For<IMessage>());

            messageReceiverSubscribedDelegate.Received()(Arg.Any<object>(), Arg.Any<Type>(), Arg.Any<int>());
            messageReceiverUnsubscribedDelegate.Received()(Arg.Any<object>(), Arg.Any<Type>());
            messagePublishingDelegate.Received()(Arg.Any<Type>(), Arg.Any<IMessage>());
            messagePublishedDelegate.Received()(Arg.Any<Type>(), Arg.Any<IMessage>());
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