using System;

namespace NathanAlden.TextAdventure.Common.MessageBus
{
    public delegate void MessageReceiverUnsubscribedDelegate(object receiver, Type messageType);
}