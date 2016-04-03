using System;
using System.Collections.Generic;
using Junior.Common.Net35;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine.Objects
{
    public class Board : IBoard
    {
        private readonly ObjectCollection<IObject> _objects = new ObjectCollection<IObject>();
        private BoardLayerCollection<BoardLayer> _boardLayers;
        private World _world;

        public Board(IGuidFactory guidFactory, World world, Coordinate<int> coordinate, Size<int> size)
        {
            guidFactory.ThrowIfNull(nameof(guidFactory));
            _world = world.EnsureNotNull(nameof(world));

            Id = guidFactory.Random();
            Coordinate = coordinate;
            Size = size;
            _boardLayers = new BoardLayerCollection<BoardLayer>(() => new BoardLayer(size));
        }

        private Board()
        {
        }

        public Guid Id { get; private set; }
        public string Description => $"Board {Coordinate} {Size}";
        public Size<int> Size { get; private set; }
        public Coordinate<int> Coordinate { get; private set; }
        public IEnumerable<IObject> Objects => _objects;
        public IBoardLayerCollection<IBoardLayer> BoardLayers => _boardLayers;

        public object SerializeToJsonObject()
        {
            return new
                   {
                       id = Id,
                       coordinate = Coordinate.SerializeToJsonObject(),
                       size = Size.SerializeToJsonObject(),
                       layers = _boardLayers.SerializeToJsonObject()
                   };
        }

        public void Prepare()
        {
        }

        public void AddObject(IObject @object)
        {
            /*
            _world.MessageBus.Execute<ObjectAddingMessage, ObjectAddingMessageData, ObjectAddedMessage, ObjectAddedMessageData>(
                () => _objects.Add(@object),
                () => new ObjectAddingMessage(new ObjectAddingMessageData(@object, this)),
                () => new ObjectAddedMessage(new ObjectAddedMessageData(@object, this)));
*/
        }

        public void RemoveObject(IObject @object)
        {
            /*
            _world.MessageBus.Execute<ObjectRemovingMessage, ObjectRemovingMessageData, ObjectRemovedMessage, ObjectRemovedMessageData>(
                () => _objects.Add(@object),
                () => new ObjectRemovingMessage(new ObjectRemovingMessageData(@object, this)),
                () => new ObjectRemovedMessage(new ObjectRemovedMessageData(@object, this)));
*/
        }

        public bool ContainsObject(IObject @object)
        {
            return _objects.Contains(@object);
        }

        public static Board FromJson(World world, JToken jsonObject)
        {
            world.ThrowIfNull(nameof(world));

            return new Board
                   {
                       Id = (Guid)jsonObject["id"],
                       _boardLayers = BoardLayerCollection<BoardLayer>.FromJson(BoardLayer.FromJson, jsonObject["layers"]),
                       _world = world,
                       Coordinate = Coordinate<int>.FromJson(jsonObject["coordinate"]),
                       Size = Size<int>.FromJson(jsonObject["size"])
                   };
        }
    }
}