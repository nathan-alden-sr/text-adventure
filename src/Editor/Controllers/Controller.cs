using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor.Controllers
{
    public abstract class Controller<TView> : IDisposable
        where TView : class, IView
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        protected Controller(TView view)
        {
            View = view.EnsureNotNull(nameof(view));
        }

        protected bool Disposed { get; private set; }

        public TView View { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Controller()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }
            if (disposing)
            {
                _disposables.Dispose();
                _disposables.Clear();
            }

            Disposed = true;
        }

        protected void AddDisposables(IEnumerable<IDisposable> disposables)
        {
            disposables = disposables ?? Enumerable.Empty<IDisposable>();

            foreach (IDisposable disposable in disposables)
            {
                _disposables.Add(disposable);
            }
        }

        protected void AddDisposables(params IDisposable[] disposables)
        {
            AddDisposables((IEnumerable<IDisposable>)disposables);
        }

        protected void SaveViewBounds(ViewBounds bounds, bool writeLocation = true, bool writeSize = true)
        {
            bounds.ThrowIfNull(nameof(bounds));

            bounds.Location = writeLocation ? View.PersistentBounds.Location : (Point?)null;
            bounds.Size = writeSize ? View.PersistentBounds.Size : (Size?)null;
            bounds.Maximized = View.Maximized;
        }
    }
}