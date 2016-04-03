using System;
using System.IO;

namespace NathanAlden.TextAdventure.Editor
{
    public static class Constants
    {
        public const string ApplicationName = "Text Adventure";
        public const string MessageBoxCaption = ApplicationName;
        public const string MyDocumentsFolderName = ApplicationName;
        public const string OpenFileDialogTitle = ApplicationName;
        public const string SaveFileDialogTitle = ApplicationName;
        public const string WorldFileExtension = "taw";
        public static readonly string RootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), MyDocumentsFolderName);
        public static readonly Uri GitHubUrl = new Uri("https://github.com/nathan-alden/text-adventure");
    }
}