using System;
using Junior.Common.Net35;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine.Objects
{
    public class Player : IPlayer
    {
        public Player(IGuidFactory guidFactory, Coordinate<int> coordinate)
        {
            guidFactory.ThrowIfNull(nameof(guidFactory));

            Id = guidFactory.Random();
            Coordinate = coordinate;
        }

        private Player()
        {
        }

        public Coordinate<int> Coordinate { get; private set; }
        public Guid Id { get; private set; }
        public string Description { get; } = "Player";

        public object SerializeToJsonObject()
        {
            return new { id = Id };
        }

        public static Player FromJson(JToken jsonObject)
        {
            return new Player
                   {
                       Id = (Guid)jsonObject["id"],
                       Coordinate = Coordinate<int>.FromJson(jsonObject["coordinate"])
                   };
        }
    }
}