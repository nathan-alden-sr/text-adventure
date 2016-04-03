using System;
using System.IO;
using Junior.Common.Net35;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Common.Config
{
    public class ConfigFile<TConfig> : IConfigFile<TConfig>
        where TConfig : class, new()
    {
        private readonly Lazy<TConfig> _config;
        private readonly string _path;

        public ConfigFile(string path)
        {
            _path = path.EnsureNotNull(nameof(path));
            _config = new Lazy<TConfig>(() => File.Exists(_path) ? JsonConvert.DeserializeObject<TConfig>(File.ReadAllText(_path)) : new TConfig());
        }

        public TConfig Config => _config.Value;

        public void Save()
        {
            JsonUtility.Save(_path, Config);
        }
    }
}