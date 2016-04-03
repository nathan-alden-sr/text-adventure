using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldVariableModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}