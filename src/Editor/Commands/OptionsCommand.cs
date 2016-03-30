using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class OptionsCommand : EditorCommand
    {
        public OptionsCommand(IEditor editor)
            : base(editor)
        {
        }

        protected override void OnExecute(object data = null)
        {
        }
    }
}