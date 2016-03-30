using System.Drawing;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators
{
    public class TextBoxDecorator : ControlDecorator<TextBox>
    {
        public override void Decorate(TextBox control, bool isValid)
        {
            control.ThrowIfNull(nameof(control));

            control.BackColor = isValid ? SystemColors.Window : Color.FromArgb(255, 230, 230);
        }
    }
}