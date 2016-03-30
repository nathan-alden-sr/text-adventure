using System.Drawing;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class WindowLocation
    {
        [JsonProperty("bounds")]
        public Rectangle Bounds { get; set; }

        [JsonProperty("maximized")]
        public bool Maximized { get; set; }
    }
}