using Autofac;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.Commands;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext _componentContext;

        public CommandFactory(IComponentContext componentContext)
        {
            componentContext.ThrowIfNull(nameof(componentContext));

            _componentContext = componentContext;
        }

        public T Create<T>()
            where T : ICommand
        {
            return _componentContext.Resolve<T>();
        }
    }
}