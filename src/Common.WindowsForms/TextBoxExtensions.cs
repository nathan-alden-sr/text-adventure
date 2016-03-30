using System.Drawing;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms
{
    public static class TextBoxExtensions
    {
        public static int GetTextBaseline(this TextBox textBox)
        {
            textBox.ThrowIfNull(nameof(textBox));

            int textBaseline = Win32.GetTextBaseline(textBox, ContentAlignment.TopLeft);

            switch (textBox.BorderStyle)
            {
                case BorderStyle.None:
                    return textBaseline;
                case BorderStyle.FixedSingle:
                    return textBaseline + 2;
                case BorderStyle.Fixed3D:
                    return textBaseline + 3;
                default:
                    return textBaseline;
            }
        }
    }
}