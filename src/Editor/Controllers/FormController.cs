using System.Drawing;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor.Controllers
{
    public abstract class FormController<TFormView> : Controller<TFormView>
        where TFormView : class, IFormView
    {
        protected FormController(TFormView view)
            : base(view)
        {
        }

        protected void SaveViewBounds(ViewBounds bounds, bool writeLocation = true, bool writeSize = true)
        {
            bounds.ThrowIfNull(nameof(bounds));

            bounds.Location = writeLocation ? View.PersistentBounds.Location : (Point?)null;
            bounds.Size = writeSize ? View.PersistentBounds.Size : (Size?)null;
            bounds.Maximized = View.Maximized;
        }
    }
}