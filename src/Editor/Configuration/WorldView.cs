using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class WorldView
    {
        [JsonProperty("bounds")]
        public ViewBounds Bounds { get; } = new ViewBounds();
    }
}