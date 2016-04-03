using System;
using System.Reactive;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    public interface IWorldView : IView
    {
        IObservable<EventPattern<FormClosingEventArgs>> ViewClosing { get; }
        IObservable<EventPattern<object>> NewWorld { get; }
        IObservable<EventPattern<object>> OpenWorld { get; }
        IObservable<EventPattern<object>> CloseWorld { get; }
        IObservable<EventPattern<object>> SaveWorld { get; }
        IObservable<EventPattern<object>> SaveWorldAs { get; }
        IObservable<EventPattern<object>> Exit { get; }
        IObservable<EventPattern<object>> Variables { get; }
        IObservable<EventPattern<object>> Options { get; }
        IObservable<EventPattern<object>> About { get; }

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