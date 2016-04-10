using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor.Controllers
{
    public class FormView : Form, IFormView
    {
        [Browsable(false)]
        public Rectangle PersistentBounds => WindowState != FormWindowState.Normal ? RestoreBounds : Bounds;

        [Browsable(false)]
        public bool Maximized => WindowState == FormWindowState.Maximized;

        public DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return MessageBox.Show(this, text, Constants.MessageBoxCaption, buttons, icon, defaultButton, options);
        }

        public DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return MessageBox.Show(this, text, Constants.MessageBoxCaption, buttons, icon, defaultButton);
        }

        public DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(this, text, Constants.MessageBoxCaption, buttons, icon);
        }

        public DialogResult ShowMessageBox(string text, MessageBoxButtons buttons)
        {
            return MessageBox.Show(this, text, Constants.MessageBoxCaption, buttons);
        }

        public DialogResult ShowMessageBox(string text)
        {
            return MessageBox.Show(this, text, Constants.MessageBoxCaption);
        }

        void IFormView.RestoreBounds(ViewBounds bounds, bool restoreLocation, bool restoreSize)
        {
            bounds.ThrowIfNull(nameof(bounds));

            if (restoreLocation && bounds.Location != null)
            {
                Location = bounds.Location.Value;
            }
            if (restoreSize && bounds.Size != null)
            {
                Size = bounds.Size.Value;
            }
            WindowState = bounds.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        protected void RestoreColumnWidths(IEnumerable<int> columnWidths, DataGridView dataGridView)
        {
            columnWidths.ThrowIfNull(nameof(columnWidths));

            int[] widths = (columnWidths ?? Enumerable.Empty<int>()).ToArray();

            for (var i = 0; i < widths.Length && i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Width = widths[i];
            }
        }
    }
}