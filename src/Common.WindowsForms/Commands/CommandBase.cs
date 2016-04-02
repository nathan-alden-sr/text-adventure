using System;
using System.Collections.Generic;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public abstract class CommandBase
    {
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

        protected bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(false);
        }

        ~CommandBase()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void AddSubscriptions(IEnumerable<IDisposable> subscriptions)
        {
            subscriptions.ThrowIfNull(nameof(subscriptions));

            _subscriptions.AddRange(subscriptions);
        }

        protected void AddSubscriptions(params IDisposable[] subscriptions)
        {
            AddSubscriptions((IEnumerable<IDisposable>)subscriptions);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }
            if (disposing)
            {
                _subscriptions.Dispose();
            }

            Disposed = true;
        }

        protected abstract void ToolStripItemOnClick(object sender, EventArgs eventArgs);
    }
}