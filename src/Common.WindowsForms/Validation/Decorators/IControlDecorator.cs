using System.Collections.Generic;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators
{
    public interface IControlDecorator<in T>
        where T : Control
    {
        void Decorate(T control, bool isValid);
        void Decorate(IEnumerable<T> controls, bool isValid);
        void Decorate(bool isValid, params T[] controls);
    }
}