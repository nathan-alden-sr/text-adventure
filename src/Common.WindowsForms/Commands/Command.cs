using System;
using System.Drawing;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public abstract class Command : ICommand
    {
        private bool _canExecute = true;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object data = null)
        {
            bool canExecute = OnCanExecute(data);

            if (canExecute == _canExecute)
            {
                return canExecute;
            }

            _canExecute = canExecute;

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            return canExecute;
        }

        public void Execute(object data = null)
        {
            if (CanExecute(data))
            {
                OnExecute(data);
            }
        }

        public void AttachToMenuItem(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null)
        {
            menuItem.ThrowIfNull(nameof(menuItem));

            menuItem.Click += (sender, args) => { Execute(); };
            menuItem.Image = image;
            menuItem.ShortcutKeys = shortcutKeys ?? Keys.None;
            menuItem.ShortcutKeyDisplayString = shortcutKeyDisplayString;
            menuItem.Enabled = CanExecute();

            CanExecuteChanged += (sender, args) => { menuItem.Enabled = CanExecute(); };
        }

        protected virtual bool OnCanExecute(object data = null)
        {
            return true;
        }

        protected virtual void OnExecute(object data = null)
        {
        }
    }
}