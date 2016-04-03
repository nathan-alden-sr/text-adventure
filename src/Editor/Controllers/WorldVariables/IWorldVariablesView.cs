using System;
using System.Collections.Generic;
using System.Reactive;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public interface IWorldVariablesView : IView
    {
        IObservable<EventPattern<KeyEventArgs>> KeyDown { get; }
        IEnumerable<int> VariablesListColumnWidths { get; }

        void ShowView(IWin32Window owner);
        void CloseView();
        void ViewAllCategories();
        void RestoreVariablesListColumnWidths(IEnumerable<int> columnWidths);
    }
}