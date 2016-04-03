using System;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public interface IControllerFactory
    {
        TController Create<TController>()
            where TController : IDisposable;
    }
}