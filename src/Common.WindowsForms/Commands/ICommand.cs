using System;
using System.Drawing;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Commands
{
    public interface ICommand : IDisposable
    {
        IObservable<object> CanExecuteChanged { get; }

        bool CanExecute();
        void Execute();
        void AttachToMenuItem(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null);
    }

    public interface ICommand<in T> : IDisposable
        where T : class
    {
        IObservable<object> CanExecuteChanged { get; }

        bool CanExecute(T data);
        void Execute(T data);
        void AttachToMenuItem(ToolStripMenuItem menuItem, Keys? shortcutKeys = null, string shortcutKeyDisplayString = null, Image image = null, T data = null);
    }
}