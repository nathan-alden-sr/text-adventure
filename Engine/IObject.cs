using System;

namespace NathanAlden.TextAdventure.Engine
{
    public interface IObject : IJsonSerializable
    {
        Guid Id { get; }
        string Description { get; }
    }
}