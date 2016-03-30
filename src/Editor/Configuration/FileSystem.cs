using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class FileSystem
    {
        [JsonProperty("mostRecentWorldPath")]
        public string MostRecentWorldPath { get; set; }
    }
}