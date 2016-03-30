using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class WindowDefaults
    {
        [JsonProperty("newWorld")]
        public NewWorldWindowDefaults NewWorld { get; } = new NewWorldWindowDefaults();
    }
}