using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public interface ICommand : IDisposable
    {
        IObservable<object> CanExecuteChanged { get; }

        bool CanExecute();
        void Execute();
        ICommand AttachToToolStripItems(IEnumerable<ToolStripItem> toolStripItems);
        ICommand AttachToToolStripItems(params ToolStripItem[] toolStripItems);
    }

    public interface ICommand<in TData> : IDisposable
    {
        IObservable<object> CanExecuteChanged { get; }

        bool CanExecute(TData data);
        void Execute(TData data);
        ICommand<TData> AttachToToolStripItems(IEnumerable<ToolStripItem> toolStripItems, TData data);
        ICommand<TData> AttachToToolStripItems(TData data, params ToolStripItem[] toolStripItems);
    }
}