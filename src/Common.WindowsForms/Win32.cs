using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms
{
    public static class Win32
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetTextMetrics(HandleRef hdc, out TEXTMETRIC tm);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DeleteObject(HandleRef hObject);

        public static int GetTextBaseline(Control control, ContentAlignment alignment)
        {
            control.ThrowIfNull(nameof(control));

            Rectangle clientRectangle = control.ClientRectangle;
            int ascent;
            int height;

            using (Graphics graphics = control.CreateGraphics())
            {
                IntPtr hdc = graphics.GetHdc();
                IntPtr hfont = control.Font.ToHfont();

                try
                {
                    IntPtr @object = SelectObject(new HandleRef(control, hdc), new HandleRef(control, hfont));
                    TEXTMETRIC textmetric;

                    GetTextMetrics(new HandleRef(control, hdc), out textmetric);
                    ascent = textmetric.tmAscent + 1;
                    height = textmetric.tmHeight;
                    SelectObject(new HandleRef(control, hdc), new HandleRef(control, @object));
                }
                finally
                {
                    DeleteObject(new HandleRef(control.Font, hfont));
                    graphics.ReleaseHdc(hdc);
                }
            }

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    return clientRectangle.Top + ascent;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    return clientRectangle.Top + clientRectangle.Height / 2 - height / 2 + ascent;
            }

            return clientRectangle.Bottom - height + ascent;
        }

        public static int GetLabelBaselineOffset(ContentAlignment alignment, BorderStyle borderStyle)
        {
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    return borderStyle == BorderStyle.None || borderStyle != BorderStyle.FixedSingle && borderStyle != BorderStyle.Fixed3D ? 0 : 1;
                default:
                    return borderStyle == BorderStyle.None ? -1 : 0;
            }
        }

        [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        private struct TEXTMETRIC
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public byte tmFirstChar;
            public byte tmLastChar;
            public byte tmDefaultChar;
            public byte tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }
    }
}