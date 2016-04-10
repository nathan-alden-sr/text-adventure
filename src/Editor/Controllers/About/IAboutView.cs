using System;
using System.Reactive;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.About
{
    public interface IAboutView : IFormView
    {
        IObservable<Unit> GitHubNavigationRequested { get; }

        void ShowView(IWin32Window owner);
        void CloseView();
    }
}