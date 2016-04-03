using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("createdTimestamp")]
        public DateTimeOffset CreatedTimestamp { get; set; }

        [JsonProperty("versions")]
        public WorldVersionsModel Versions { get; } = new WorldVersionsModel();

        [JsonProperty("messages")]
        public List<WorldMessageModel> Messages { get; } = new List<WorldMessageModel>();

        [JsonProperty("variables")]
        public List<WorldVariableModel> Variables { get; } = new List<WorldVariableModel>();

        [JsonProperty("resources")]
        public WorldResourcesModel Resources { get; } = new WorldResourcesModel();
    }
}