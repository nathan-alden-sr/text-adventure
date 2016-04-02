using System;
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

        public void SubscribeToMessageThatAffectsCanExecute<TMessage>()
            where TMessage : class, IMessage
        {
            this.ThrowIfDisposed(Disposed);

            AddSubscriptions(Editor.MessageBus.Subscribe<TMessage>(message => { CanExecute(); }));
        }
    }

    public abstract class EditorCommand<T> : Command<T>
        where T : class
    {
        protected EditorCommand(IEditor editor)
        {
            editor.ThrowIfNull(nameof(editor));

            Editor = editor;
        }

        public IEditor Editor { get; }

        public void SubscribeToMessageThatAffectsCanExecute<TMessage>(Func<T> dataDelegate)
            where TMessage : class, IMessage
        {
            this.ThrowIfDisposed(Disposed);

            AddSubscriptions(Editor.MessageBus.Subscribe<TMessage>(message => { CanExecute(dataDelegate()); }));
        }
    }
}