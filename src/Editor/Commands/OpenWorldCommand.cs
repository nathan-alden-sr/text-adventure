using Junior.Common.Net35;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class OpenWorldCommand : EditorCommand
    {
        public OpenWorldCommand(IEditor editor)
            : base(editor)
        {
        }

        protected override void OnExecute()
        {
            this.ThrowIfDisposed(Disposed);

            Editor.MessageBus.Publish<WorldOpeningMessage>();
        }
    }
}