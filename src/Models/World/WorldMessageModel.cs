using System;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldMessageModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public Guid IdAsGuid
        {
            get { return Guid.Parse(Id); }
            set { Id = value.ToString("D"); }
        }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}