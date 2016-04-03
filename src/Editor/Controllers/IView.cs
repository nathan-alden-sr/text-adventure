using System.Drawing;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor.Controllers
{
    public interface IView : IWin32Window
    {
        Rectangle PersistentBounds { get; }
        bool Maximized { get; }

        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options);
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons);
        DialogResult ShowMessageBox(string text);
        void RestoreBounds(ViewBounds bounds, bool restoreLocation = true, bool restoreSize = true);
    }
}