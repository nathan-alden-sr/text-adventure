using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class WindowLocations
    {
        [JsonProperty("worldEditor")]
        public WindowLocation WorldEditor { get; } = new WindowLocation();
    }
}