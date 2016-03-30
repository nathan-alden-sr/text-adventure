using System.Collections.Generic;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Models.World
{
    public class WorldResourcesModel
    {
        [JsonProperty("charactersets")]
        public List<WorldResourceCharactersetModel> Charactersets { get; } = new List<WorldResourceCharactersetModel>();
    }
}