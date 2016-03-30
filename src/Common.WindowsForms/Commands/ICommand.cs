using System;
using System.Drawing;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public interface ICommand
    {
        bool CanExecute(object data = null);
        void Execute(object data = null);

        event EventHandler CanExecuteChanged;

        void AttachToMenuItem(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null);
    }
}