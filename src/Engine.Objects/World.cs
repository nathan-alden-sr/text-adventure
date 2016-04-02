using System;
using System.Collections.Generic;
using NathanAlden.TextAdventure.Common.MessageBus;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine.Objects
{
    public class World : IWorld
    {
        private readonly HandlerCollection<IInputHandler> _inputHandlers = new HandlerCollection<IInputHandler>();
        private BoardCollection<Board> _boards;

        public World(Guid id, string name, uint engineVersion)
        {
            Id = id;
            Name = name;
            EngineVersion = engineVersion;
        }

        public Player Player { get; private set; }
        public Size<int> MaximumBoardSize => _boards.MaximumBoardSize;
        public MessageBus MessageBus { get; } = new MessageBus();
        public IEnumerable<IBoard> Boards => _boards;
        public IEnumerable<IInputHandler> InputHandlers => _inputHandlers;
        public Guid Id { get; }
        public string Description => "World";
        public string Name { get; }
        public uint EngineVersion { get; }
        IPlayer IWorld.Player => Player;

        public void Prepare()
        {
        }

        public object SerializeToJsonObject()
        {
            return new
                   {
                       id = Id,
                       engineVersion = EngineVersion,
                       name = Name,
                       boards = _boards.SerializeToJsonObject(),
                       player = Player?.SerializeToJsonObject()
                   };
        }

        public void RemoveBoard(Board board)
        {
            /*
            MessageBus.Execute<BoardRemovingMessage, IBoard, BoardRemovedMessage, IBoard>(
                () => _boards.Remove(board),
                () => new BoardRemovingMessage(board),
                () => new BoardRemovedMessage(board));
*/
        }

        public void AddBoard(Board board)
        {
            /*
            MessageBus.Execute<BoardAddingMessage, IBoard, BoardAddedMessage, IBoard>(
                () => _boards.Add(board),
                () => new BoardAddingMessage(board),
                () => new BoardAddedMessage(board));
*/
        }

        public bool ContainsBoard(Board board)
        {
            return _boards.Contains(board);
        }

        public Board FindBoard(Coordinate<int> coordinate)
        {
            return _boards.Find(coordinate);
        }

        public static World FromJson(JToken jsonObject)
        {
            var world = new World((Guid)jsonObject["id"], jsonObject.Value<string>("name"), jsonObject.Value<uint>("engineVersion"));

            world._boards = BoardCollection<Board>.FromJson(x => Board.FromJson(world, x), jsonObject["boards"]);
            world.Player = jsonObject["player"].HasValues ? Player.FromJson(jsonObject["player"]) : null;

            return world;
        }
    }
}