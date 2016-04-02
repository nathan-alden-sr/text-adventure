using Junior.Common.Net35;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class SaveWorldCommand : EditorCommand
    {
        public SaveWorldCommand(IEditor editor)
            : base(editor)
        {
            SubscribeToMessageThatAffectsCanExecute<WorldLoadedMessage>();
            SubscribeToMessageThatAffectsCanExecute<WorldClosedMessage>();
            SubscribeToMessageThatAffectsCanExecute<WorldSavedMessage>();
        }

        protected override bool OnCanExecute()
        {
            this.ThrowIfDisposed(Disposed);

            return Editor.World?.Status == WorldStatus.Changed;
        }

        protected override void OnExecute()
        {
            this.ThrowIfDisposed(Disposed);

            Editor.MessageBus.Publish(new WorldSavingMessage(false));
        }
    }
}