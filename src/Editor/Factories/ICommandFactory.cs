using System.Drawing;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Common.WindowsForms.Commands;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public interface ICommandFactory
    {
        T Create<T>()
            where T : ICommand;

        T CreateAndAttachToMenuItem<T>(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null)
            where T : ICommand;
    }
}