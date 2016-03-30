using System.IO;
using System.Text.RegularExpressions;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Common
{
    public static class PathUtility
    {
        public static string StripIllegalCharacters(string path)
        {
            path.ThrowIfNull(nameof(path));

            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            return Regex.Replace(path, $"[{Regex.Escape(regexSearch)}]", "");
        }
    }
}