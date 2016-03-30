using System;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldResourceCharactersetModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public Guid IdAsGuid
        {
            get { return Guid.Parse(Id); }
            set { Id = value.ToString("D"); }
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pngBase64")]
        public string PngBase64 { get; set; }
    }
}