using System.Collections.Generic;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators
{
    public abstract class ControlDecorator<T> : IControlDecorator<T>
        where T : Control
    {
        public abstract void Decorate(T control, bool isValid);

        public void Decorate(IEnumerable<T> controls, bool isValid)
        {
            foreach (T control in controls)
            {
                Decorate(control, isValid);
            }
        }

        public void Decorate(bool isValid, params T[] controls)
        {
            Decorate(controls, isValid);
        }
    }
}