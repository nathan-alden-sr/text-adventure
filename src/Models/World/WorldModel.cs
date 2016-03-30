using System;
using System.Collections.Generic;
using NathanAlden.TextAdventure.Common.Models;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldModel : Model
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

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("versions")]
        public WorldVersionsModel Versions { get; } = new WorldVersionsModel();

        [JsonProperty("messages")]
        public List<WorldMessageModel> Messages { get; } = new List<WorldMessageModel>();

        [JsonProperty("resources")]
        public WorldResourcesModel Resources { get; } = new WorldResourcesModel();
    }
}