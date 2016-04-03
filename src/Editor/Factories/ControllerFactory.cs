using System;
using Autofac;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public class ControllerFactory : IControllerFactory
    {
        private readonly IComponentContext _componentContext;

        public ControllerFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext.EnsureNotNull(nameof(componentContext));
        }

        public TController Create<TController>()
            where TController : IDisposable
        {
            return _componentContext.Resolve<TController>();
        }
    }
}