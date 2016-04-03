using System;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.About
{
    public interface IAboutController : IDisposable
    {
        void ShowView(IWin32Window owner);
    }
}