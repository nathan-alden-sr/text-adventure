using System;
using System.Reactive;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    public interface INewWorldView : IView
    {
        IObservable<EventPattern<object>> GenerateId { get; }

        DialogResult ShowView(IWin32Window owner, NewWorldViewModel viewModel);
    }
}