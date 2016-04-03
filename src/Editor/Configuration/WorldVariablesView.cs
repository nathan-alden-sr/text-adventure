using System.Collections.Generic;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class WorldVariablesView
    {
        [JsonProperty("bounds")]
        public ViewBounds Bounds { get; } = new ViewBounds();

        [JsonProperty("categoryFilter")]
        public string CategoryFilter { get; set; }

        [JsonProperty("columnWidths")]
        public List<int> ColumnWidths { get; } = new List<int>();
    }
}