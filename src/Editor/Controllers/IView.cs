using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers
{
    public interface IView : IWin32Window
    {
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options);
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon);
        DialogResult ShowMessageBox(string text, MessageBoxButtons buttons);
        DialogResult ShowMessageBox(string text);
    }
}