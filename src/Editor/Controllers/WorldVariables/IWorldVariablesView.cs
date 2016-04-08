using System;
using System.Collections.Generic;
using System.Reactive;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public interface IWorldVariablesView : IView
    {
        IObservable<Unit> NewRequested { get; }
        IObservable<WorldVariableViewModel> EditRequested { get; }
        IObservable<IEnumerable<WorldVariableViewModel>> DeleteRequested { get; }
        string CategoryFilter { get; }
        IEnumerable<WorldVariableViewModel> Variables { get; }
        IEnumerable<WorldVariableViewModel> SelectedVariables { get; }
        IEnumerable<int> VariablesListColumnWidths { get; }

        DialogResult ShowView(IWin32Window owner, IEnumerable<WorldVariableViewModel> worldVariableViewModels);
        void CloseView();
        void AddVariable(WorldVariableViewModel viewModel);
        void ReplaceVariable(WorldVariableViewModel currentViewModel, WorldVariableViewModel editedViewModel);
        void DeleteSelectedVariables();
        void RestoreVariablesListColumnWidths(IEnumerable<int> columnWidths);
    }
}