using System.Drawing;
using System.Windows.Forms;
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

        public T CreateAndAttachToMenuItem<T>(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null)
            where T : ICommand
        {
            var command = Create<T>();

            command.AttachToMenuItem(menuItem, shortcutKeys, shortcutKeyDisplayString, image);

            return command;
        }
    }
}