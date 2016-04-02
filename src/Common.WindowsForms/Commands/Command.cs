using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public abstract class Command : CommandBase, ICommand
    {
        private readonly List<ToolStripMenuItem> _menuItems = new List<ToolStripMenuItem>();
        private bool _canExecute = true;
        private Subject<object> CanExecuteChangedSubject { get; } = new Subject<object>();
        public IObservable<object> CanExecuteChanged => CanExecuteChangedSubject.AsObservable();

        public bool CanExecute()
        {
            this.ThrowIfDisposed(Disposed);

            bool canExecute = OnCanExecute();

            if (canExecute == _canExecute)
            {
                return canExecute;
            }

            _canExecute = canExecute;
            CanExecuteChangedSubject.OnNext(null);

            return canExecute;
        }

        public void Execute()
        {
            this.ThrowIfDisposed(Disposed);

            if (CanExecute())
            {
                OnExecute();
            }
        }

        public void AttachToMenuItem(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null)
        {
            menuItem.ThrowIfNull(nameof(menuItem));

            menuItem.Click += MenuItemOnClick;
            menuItem.Image = image;
            menuItem.ShortcutKeys = shortcutKeys ?? Keys.None;
            menuItem.ShortcutKeyDisplayString = shortcutKeyDisplayString;
            menuItem.Enabled = CanExecute();

            _menuItems.Add(menuItem);

            AddSubscriptions(CanExecuteChangedSubject.Subscribe(x => menuItem.Enabled = CanExecute()));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (ToolStripMenuItem menuItem in _menuItems)
                {
                    menuItem.Click -= MenuItemOnClick;
                }
                _menuItems.Clear();
            }

            base.Dispose(disposing);
        }

        protected override void MenuItemOnClick(object sender, EventArgs eventArgs)
        {
            Execute();
        }

        protected virtual bool OnCanExecute()
        {
            this.ThrowIfDisposed(Disposed);

            return true;
        }

        protected virtual void OnExecute()
        {
            this.ThrowIfDisposed(Disposed);
        }
    }

    public abstract class Command<T> : CommandBase, ICommand<T>
        where T : class
    {
        private readonly List<ToolStripMenuItem> _menuItems = new List<ToolStripMenuItem>();
        private bool _canExecute = true;
        private Subject<object> CanExecuteChangedSubject { get; } = new Subject<object>();
        public IObservable<object> CanExecuteChanged => CanExecuteChangedSubject.AsObservable();

        public bool CanExecute(T data)
        {
            this.ThrowIfDisposed(Disposed);

            bool canExecute = OnCanExecute(data);

            if (canExecute == _canExecute)
            {
                return canExecute;
            }

            _canExecute = canExecute;
            CanExecuteChangedSubject.OnNext(null);

            return canExecute;
        }

        public void AttachToMenuItem(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null, T data = null)
        {
            menuItem.ThrowIfNull(nameof(menuItem));

            menuItem.Click += MenuItemOnClick;
            menuItem.Image = image;
            menuItem.ShortcutKeys = shortcutKeys ?? Keys.None;
            menuItem.ShortcutKeyDisplayString = shortcutKeyDisplayString;
            menuItem.Enabled = CanExecute(data);

            _menuItems.Add(menuItem);

            AddSubscriptions(CanExecuteChangedSubject.Subscribe(x => menuItem.Enabled = CanExecute((T)menuItem.Tag)));
        }

        public void Execute(T data)
        {
            this.ThrowIfDisposed(Disposed);

            if (CanExecute(data))
            {
                OnExecute(data);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (ToolStripMenuItem menuItem in _menuItems)
                {
                    menuItem.Click -= MenuItemOnClick;
                }
                _menuItems.Clear();
            }

            base.Dispose(disposing);
        }

        protected override void MenuItemOnClick(object sender, EventArgs eventArgs)
        {
            Execute((T)((ToolStripMenuItem)sender).Tag);
        }

        protected virtual bool OnCanExecute(T data)
        {
            this.ThrowIfDisposed(Disposed);

            return true;
        }

        protected virtual void OnExecute(T data)
        {
            this.ThrowIfDisposed(Disposed);
        }
    }
}