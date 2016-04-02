using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public abstract class Command : CommandBase, ICommand
    {
        private readonly HashSet<ToolStripItem> _toolStripItems = new HashSet<ToolStripItem>();
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

        public ICommand AttachToToolStripItems(IEnumerable<ToolStripItem> toolStripItems)
        {
            toolStripItems = toolStripItems ?? Enumerable.Empty<ToolStripItem>();

            foreach (ToolStripItem toolStripItem in toolStripItems)
            {
                toolStripItem.Click += ToolStripItemOnClick;
                toolStripItem.Enabled = CanExecute();

                _toolStripItems.Add(toolStripItem);

                AddSubscriptions(CanExecuteChangedSubject.Subscribe(x => toolStripItem.Enabled = CanExecute()));
            }

            return this;
        }

        public ICommand AttachToToolStripItems(params ToolStripItem[] toolStripItems)
        {
            return AttachToToolStripItems((IEnumerable<ToolStripItem>)toolStripItems);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (ToolStripItem toolStripItem in _toolStripItems)
                {
                    toolStripItem.Click -= ToolStripItemOnClick;
                }
                _toolStripItems.Clear();
            }

            base.Dispose(disposing);
        }

        protected override void ToolStripItemOnClick(object sender, EventArgs eventArgs)
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

    public abstract class Command<TData> : CommandBase, ICommand<TData>
    {
        private readonly HashSet<ToolStripItem> _toolStripItems = new HashSet<ToolStripItem>();
        private bool _canExecute = true;
        private Subject<object> CanExecuteChangedSubject { get; } = new Subject<object>();
        public IObservable<object> CanExecuteChanged => CanExecuteChangedSubject.AsObservable();

        public bool CanExecute(TData data)
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

        public void Execute(TData data)
        {
            this.ThrowIfDisposed(Disposed);

            if (CanExecute(data))
            {
                OnExecute(data);
            }
        }

        public ICommand<TData> AttachToToolStripItems(IEnumerable<ToolStripItem> toolStripItems, TData data)
        {
            toolStripItems = toolStripItems ?? Enumerable.Empty<ToolStripItem>();

            foreach (ToolStripItem toolStripItem in toolStripItems)
            {
                toolStripItem.Click += ToolStripItemOnClick;
                toolStripItem.Enabled = CanExecute(data);

                _toolStripItems.Add(toolStripItem);

                AddSubscriptions(CanExecuteChangedSubject.Subscribe(x => toolStripItem.Enabled = CanExecute((TData)toolStripItem.Tag)));
            }

            return this;
        }

        public ICommand<TData> AttachToToolStripItems(TData data, params ToolStripItem[] toolStripItems)
        {
            return AttachToToolStripItems(toolStripItems, data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (ToolStripItem toolStripItem in _toolStripItems)
                {
                    toolStripItem.Click -= ToolStripItemOnClick;
                }
                _toolStripItems.Clear();
            }

            base.Dispose(disposing);
        }

        protected override void ToolStripItemOnClick(object sender, EventArgs eventArgs)
        {
            Execute((TData)((ToolStripItem)sender).Tag);
        }

        protected virtual bool OnCanExecute(TData data)
        {
            this.ThrowIfDisposed(Disposed);

            return true;
        }

        protected virtual void OnExecute(TData data)
        {
            this.ThrowIfDisposed(Disposed);
        }
    }
}