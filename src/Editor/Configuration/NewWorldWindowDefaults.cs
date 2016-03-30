using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class NewWorldWindowDefaults
    {
        [JsonProperty("author")]
        public string Author { get; set; } = null;
    }
}