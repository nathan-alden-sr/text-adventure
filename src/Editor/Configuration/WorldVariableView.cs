using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class WorldVariableView
    {
        [JsonProperty("bounds")]
        public ViewBounds Bounds { get; } = new ViewBounds();
    }
}