using System;
using System.IO;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Engine.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine.Game
{
    public class WorldDirectory
    {
        public WorldDirectory(string directory)
        {
            directory.ThrowIfNull(nameof(directory));

            // ReSharper disable once AssignNullToNotNullAttribute
            directory = Path.IsPathRooted(directory) ? directory : Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), directory);

            if (!Directory.Exists(directory))
            {
                throw new ArgumentException("Directory does not exist.", nameof(directory));
            }

            string configPath = Path.Combine(directory, "config.json");

            if (!File.Exists(configPath))
            {
                throw new ApplicationException("config.json not found.");
            }

            var configJsonObject = JsonConvert.DeserializeObject<JToken>(File.ReadAllText(configPath));

            WorldVersion = configJsonObject.Value<int>("worldVersion");
            WorldPath = Path.Combine(directory, configJsonObject.Value<string>("worldFilename"));
            IconPath = Path.Combine(directory, configJsonObject.Value<string>("iconFilename"));
            Characterset = configJsonObject.Value<string>("characterset");

            if (WorldPath == null || !File.Exists(WorldPath))
            {
                throw new ApplicationException("Invalid world path.");
            }
            if (IconPath != null && !File.Exists(IconPath))
            {
                throw new ApplicationException("Invalid icon path.");
            }
        }

        public int WorldVersion { get; }
        public string WorldPath { get; }
        public string IconPath { get; }
        public string Characterset { get; }

        public World CreateWorld()
        {
            var jsonObject = JsonConvert.DeserializeObject<JToken>(File.ReadAllText(WorldPath));

            return World.FromJson(jsonObject);
        }

        public Stream OpenIconStream()
        {
            return IconPath.IfNotNull(File.OpenRead);
        }
    }
}