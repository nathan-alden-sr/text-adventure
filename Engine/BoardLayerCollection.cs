using System;
using Junior.Common.Net35;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine
{
    public class BoardLayerCollection<T> : IBoardLayerCollection<T>, IJsonSerializable
        where T : IBoardLayer
    {
        public BoardLayerCollection(Func<T> boardLayerFactoryDelegate)
        {
            boardLayerFactoryDelegate.ThrowIfNull(nameof(boardLayerFactoryDelegate));

            Floor = boardLayerFactoryDelegate();
            Player = boardLayerFactoryDelegate();
            Ceiling = boardLayerFactoryDelegate();
        }

        private BoardLayerCollection()
        {
        }

        public T Floor { get; private set; }
        public T Player { get; private set; }
        public T Ceiling { get; private set; }

        public object SerializeToJsonObject()
        {
            return new
                   {
                       floor = Floor.SerializeToJsonObject(),
                       player = Player.SerializeToJsonObject(),
                       ceiling = Ceiling.SerializeToJsonObject()
                   };
        }

        public static BoardLayerCollection<T> FromJson(Func<JToken, T> boardLayerFactoryDelegate, JToken jsonObject)
        {
            boardLayerFactoryDelegate.ThrowIfNull(nameof(boardLayerFactoryDelegate));

            return new BoardLayerCollection<T>
                   {
                       Floor = boardLayerFactoryDelegate(jsonObject["floor"]),
                       Player = boardLayerFactoryDelegate(jsonObject["player"]),
                       Ceiling = boardLayerFactoryDelegate(jsonObject["ceiling"])
                   };
        }
    }
}