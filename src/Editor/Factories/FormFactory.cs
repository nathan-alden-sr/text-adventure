using System.Windows.Forms;
using Autofac;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public class FormFactory : IFormFactory
    {
        private readonly IComponentContext _componentContext;

        public FormFactory(IComponentContext componentContext)
        {
            componentContext.ThrowIfNull(nameof(componentContext));

            _componentContext = componentContext;
        }

        public T Create<T>()
            where T : Form
        {
            return _componentContext.Resolve<T>();
        }
    }
}