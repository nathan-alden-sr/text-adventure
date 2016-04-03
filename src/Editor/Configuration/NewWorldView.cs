using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class NewWorldView
    {
        [JsonProperty("defaultAuthor")]
        public string DefaultAuthor { get; set; } = null;
    }
}