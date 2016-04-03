using System.IO;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor
{
    public class FileSystem : IFileSystem
    {
        private readonly IConfigFile<Config> _configFile;

        public FileSystem(IConfigFile<Config> configFile)
        {
            _configFile = configFile;
        }

        public string WorldDirectory => Directory.CreateDirectory(Path.GetDirectoryName(_configFile.Config.FileSystem.MostRecentWorldPath) ?? Constants.RootDirectory).FullName;
    }
}