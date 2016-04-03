using System;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public interface IWorldVariablesController : IDisposable
    {
        void ShowView(IWin32Window owner);
    }
}