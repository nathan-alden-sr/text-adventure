using System.Drawing;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class ViewBounds
    {
        [JsonProperty("location")]
        public Point? Location { get; set; }

        [JsonProperty("size")]
        public Size? Size { get; set; }

        [JsonProperty("maximized")]
        public bool Maximized { get; set; }
    }
}