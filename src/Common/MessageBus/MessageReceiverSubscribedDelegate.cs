using System;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public delegate void MessageReceiverSubscribedDelegate(object receiver, Type messageType, int priority = 0);
}