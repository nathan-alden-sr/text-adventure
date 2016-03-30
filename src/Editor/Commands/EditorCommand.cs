using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Common.WindowsForms.Commands;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public abstract class EditorCommand : Command
    {
        protected EditorCommand(IEditor editor)
        {
            editor.ThrowIfNull(nameof(editor));

            Editor = editor;
        }

        public IEditor Editor { get; }

        public void SubscribeToMessageThatAffectsCanExecute<TMessage>(MessageReceiverDelegate<TMessage> receiverDelegate = null)
            where TMessage : class, IMessage
        {
            Editor.MessageBus.Subscribe<TMessage>(message =>
                                                  {
                                                      CanExecute();

                                                      receiverDelegate?.Invoke(message);

                                                      return ReceiveMessageResult.Continue;
                                                  });
        }
    }
}