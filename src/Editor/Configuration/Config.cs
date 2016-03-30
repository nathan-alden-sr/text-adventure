using System.Drawing;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class Config
    {
        public Config()
        {
            WindowLocations.WorldEditor.Bounds = new Rectangle(0, 0, 800, 600);
        }

        [JsonProperty("windowLocations")]
        public WindowLocations WindowLocations { get; } = new WindowLocations();

        [JsonProperty("windowDefaults")]
        public WindowDefaults WindowDefaults { get; } = new WindowDefaults();

        [JsonProperty("fileSystem")]
        public FileSystem FileSystem { get; } = new FileSystem();
    }
}