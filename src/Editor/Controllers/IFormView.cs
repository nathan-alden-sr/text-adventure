using System.Drawing;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor.Controllers
{
    public interface IFormView : IView
    {
        Rectangle PersistentBounds { get; }
        bool Maximized { get; }

        void RestoreBounds(ViewBounds bounds, bool restoreLocation = true, bool restoreSize = true);
    }
}