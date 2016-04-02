using Junior.Common.Net35;
using NathanAlden.TextAdventure.Editor.Forms;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class AboutCommand : EditorCommand
    {
        public AboutCommand(IEditor editor)
            : base(editor)
        {
        }

        protected override void OnExecute()
        {
            this.ThrowIfDisposed(Disposed);

            using (var form = Editor.FormFactory.Create<AboutForm>())
            {
                form.ShowDialog();
            }
        }
    }
}