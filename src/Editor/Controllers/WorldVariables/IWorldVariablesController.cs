using System;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public interface IWorldVariablesController : IDisposable
    {
        void ShowView(IWin32Window owner, WorldModel model);
    }
}