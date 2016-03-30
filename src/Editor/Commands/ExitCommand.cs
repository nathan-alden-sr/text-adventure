using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class ExitCommand : EditorCommand
    {
        public ExitCommand(IEditor editor)
            : base(editor)
        {
        }

        protected override void OnExecute(object data = null)
        {
            Editor.MessageBus.Publish<ExitingMessage>();
        }
    }
}