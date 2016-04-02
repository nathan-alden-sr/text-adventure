using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Forms
{
    public class EditorForm : Form
    {
        private readonly HashSet<IDisposable> _disposables = new HashSet<IDisposable>();

        protected EditorForm(IEditor editor)
        {
            editor.ThrowIfNull(nameof(editor));

            Editor = editor;
        }

        protected EditorForm()
        {
        }

        protected IEditor Editor { get; }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _disposables.Dispose();

            base.OnFormClosed(e);
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
    }
}