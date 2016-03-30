using System.IO;
using System.Text;
using Junior.Common.Net35;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Common
{
    public static class JsonUtility
    {
        public static void Save(string path, object @object)
        {
            path.ThrowIfNull(nameof(path));
            @object.ThrowIfNull(nameof(@object));

            using (FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter))
            {
                jsonTextWriter.Formatting = Formatting.Indented;
                jsonTextWriter.Indentation = 2;
                jsonTextWriter.IndentChar = ' ';

                var jsonSerializer = new JsonSerializer();

                jsonSerializer.Serialize(jsonTextWriter, @object);
            }
        }
    }
}