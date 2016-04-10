using System;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Editor.Controllers.WorldVariables;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariable
{
    public interface IWorldVariableView : IFormView
    {
        IObservable<FormClosingEventArgs> ViewClosing { get; }

        DialogResult ShowView(IWin32Window owner, WorldVariableViewModel viewModel, EditMode editMode);
    }
}