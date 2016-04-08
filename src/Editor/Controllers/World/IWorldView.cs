using System;
using System.Reactive;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    public interface IWorldView : IView
    {
        IObservable<Unit> FileCloseWorldRequested { get; }
        IObservable<Unit> FileExitRequested { get; }
        IObservable<Unit> FileNewWorldRequested { get; }
        IObservable<Unit> FileOpenWorldRequested { get; }
        IObservable<Unit> FileSaveWorldAsRequested { get; }
        IObservable<Unit> FileSaveWorldRequested { get; }
        IObservable<Unit> HelpAboutRequested { get; }
        IObservable<Unit> ToolsOptionsRequested { get; }
        IObservable<FormClosingEventArgs> ViewClosing { get; }
        IObservable<Unit> WorldVariablesRequested { get; }

        void ShowView();
        void CloseView();
        void SetTitle(string title);
        void ShowWorldToolStrips();
        void HideWorldToolStrips();
        void EnableCloseWorldToolStripItems();
        void DisableCloseWorldToolStripItems();
        void EnableSaveWorldToolStripItems();
        void DisableSaveWorldToolStripItems();
        void EnableSaveWorldAsToolStripItems();
        void DisableSaveWorldAsToolStripItems();
    }
}