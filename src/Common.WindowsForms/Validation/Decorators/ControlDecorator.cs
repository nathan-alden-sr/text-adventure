using System.Collections.Generic;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators
{
    public abstract class ControlDecorator<TControl> : IControlDecorator<TControl>
        where TControl : Control
    {
        public abstract void Decorate(TControl control, bool isValid);

        public void Decorate(IEnumerable<TControl> controls, bool isValid)
        {
            foreach (TControl control in controls)
            {
                Decorate(control, isValid);
            }
        }

        public void Decorate(bool isValid, params TControl[] controls)
        {
            Decorate(controls, isValid);
        }
    }
}