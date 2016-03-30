using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldVersionsModel
    {
        [JsonProperty("fileFormat")]
        public string FileFormat { get; set; }

        [JsonProperty("world")]
        public string World { get; set; }
    }
}