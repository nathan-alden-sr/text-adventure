using Autofac;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Editor.Controllers;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly IComponentContext _componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext.EnsureNotNull(nameof(componentContext));
        }

        public TView Create<TView>()
            where TView : IView
        {
            return _componentContext.Resolve<TView>();
        }
    }
}