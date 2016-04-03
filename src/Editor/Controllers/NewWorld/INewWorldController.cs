using System;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    public interface INewWorldController : IDisposable
    {
        WorldModel ShowView(IWin32Window owner);
    }
}