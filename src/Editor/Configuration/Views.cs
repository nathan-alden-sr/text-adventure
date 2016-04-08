using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Configuration
{
    public class Views
    {
        [JsonProperty("world")]
        public WorldView World { get; } = new WorldView();

        [JsonProperty("newWorld")]
        public NewWorldView NewWorld { get; } = new NewWorldView();

        [JsonProperty("worldVariables")]
        public WorldVariablesView WorldVariables { get; } = new WorldVariablesView();

        [JsonProperty("worldVariable")]
        public WorldVariableView WorldVariable { get; } = new WorldVariableView();
    }
}