using System;
using System.IO;
using Junior.Common.Net35;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Common.Config
{
    public class ConfigFile<T> : IConfigFile<T>
        where T : class, new()
    {
        private readonly Lazy<T> _config;
        private readonly string _path;

        public ConfigFile(string path)
        {
            path.ThrowIfNull(nameof(path));

            _path = path;
            _config = new Lazy<T>(() => File.Exists(_path) ? JsonConvert.DeserializeObject<T>(File.ReadAllText(_path)) : new T());
        }

        public T Config => _config.Value;

        public void Save()
        {
            JsonUtility.Save(_path, Config);
        }
    }
}