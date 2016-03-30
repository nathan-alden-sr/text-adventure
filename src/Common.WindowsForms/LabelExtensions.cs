using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms
{
    public static class LabelExtensions
    {
        public static int GetTextBaseline(this Label label)
        {
            label.ThrowIfNull(nameof(label));

            int textBaseline = Win32.GetTextBaseline(label, label.TextAlign);

            if (!label.AutoSize)
            {
                textBaseline += Win32.GetLabelBaselineOffset(label.TextAlign, label.BorderStyle);
            }

            return textBaseline;
        }
    }
}