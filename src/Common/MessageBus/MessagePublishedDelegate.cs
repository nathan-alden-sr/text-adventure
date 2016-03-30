using System;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public delegate void MessagePublishedDelegate(Type messageType, IMessage message);
}