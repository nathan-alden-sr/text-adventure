using System.Drawing;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class Config
    {
        public Config()
        {
            Views.World.Bounds.Size = new Size(800, 600);
        }

        [JsonProperty("views")]
        public Views Views { get; } = new Views();

        [JsonProperty("fileSystem")]
        public FileSystem FileSystem { get; } = new FileSystem();
    }
}