using System;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Editor.Controllers.WorldVariables;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariable
{
    public interface IWorldVariableController : IDisposable
    {
        WorldVariableViewModel ShowNewView(IWin32Window owner, WorldVariableViewModel viewModel = null, string category = null);
        WorldVariableViewModel ShowEditView(IWin32Window owner, WorldVariableViewModel viewModel);
    }
}