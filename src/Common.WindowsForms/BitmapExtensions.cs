using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common.WindowsForms
{
    public static class BitmapExtensions
    {
        public static string AsBase64Png(this Bitmap bitmap)
        {
            bitmap.ThrowIfNull(nameof(bitmap));

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);

                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}