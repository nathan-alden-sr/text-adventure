using System;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public delegate void MessagePublishingDelegate(Type messageType, IMessage message);
}