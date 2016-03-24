using System;
using System.Collections.Generic;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Engine.Objects.Messages;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine.Objects
{
    public class World : IWorld
    {
        private readonly HandlerCollection<IInputHandler> _inputHandlers = new HandlerCollection<IInputHandler>();
        private BoardCollection<Board> _boards;

        public World(IGuidFactory guidFactory, string description, Size<int> maximumBoardSize)
        {
            guidFactory.ThrowIfNull(nameof(guidFactory));
            description.ThrowIfNullOrEmpty(nameof(description));

            Id = guidFactory.Random();
            Description = description;
            _boards = new BoardCollection<Board>(maximumBoardSize);
        }

        private World()
        {
        }

        public Player Player { get; private set; }
        public MessageBus MessageBus { get; } = new MessageBus();
        public IEnumerable<IBoard> Boards => _boards;
        public IEnumerable<IInputHandler> InputHandlers => _inputHandlers;
        public Guid Id { get; private set; }
        public string Description { get; }
        IPlayer IWorld.Player => Player;

        public void Prepare()
        {
        }

        public object SerializeToJsonObject()
        {
            return new
                   {
                       id = Id,
                       boards = _boards.SerializeToJsonObject(),
                       player = Player?.SerializeToJsonObject()
                   };
        }

        public void RemoveBoard(Board board)
        {
            MessageBus.Execute<BoardRemovingMessage, IBoard, BoardRemovedMessage, IBoard>(
                () => _boards.Remove(board),
                () => new BoardRemovingMessage(board),
                () => new BoardRemovedMessage(board));
        }

        public void AddBoard(Board board)
        {
            MessageBus.Execute<BoardAddingMessage, IBoard, BoardAddedMessage, IBoard>(
                () => _boards.Add(board),
                () => new BoardAddingMessage(board),
                () => new BoardAddedMessage(board));
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
            var world = new World { Id = (Guid)jsonObject["id"] };

            world._boards = BoardCollection<Board>.FromJson(x => Board.FromJson(world, x), jsonObject["boards"]);
            world.Player = jsonObject["player"].HasValues ? Player.FromJson(jsonObject["player"]) : null;

            return world;
        }
    }
}