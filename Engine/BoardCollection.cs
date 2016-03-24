using System;
using System.Linq;
using Junior.Common.Net35;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine
{
    public class BoardCollection<T> : ObjectCollection<T>, IJsonSerializable
        where T : class, IBoard
    {
        public BoardCollection(Size<int> maximumBoardSize)
        {
            MaximumBoardSize = maximumBoardSize;
        }

        public Size<int> MaximumBoardSize { get; }

        public object SerializeToJsonObject()
        {
            return new
                   {
                       maximumBoardSize = MaximumBoardSize.SerializeToJsonObject(),
                       boards = this.Select(x => x.SerializeToJsonObject())
                   };
        }

        public override void Add(T board)
        {
            board.ThrowIfNull(nameof(board));

            if (Find(board.Coordinate) != null)
            {
                throw new ArgumentException($"A board with coordinate {board} already exists.", nameof(board));
            }

            base.Add(board);
        }

        public T Find(Coordinate<int> coordinate)
        {
            return this.SingleOrDefault(x => x.Coordinate == coordinate);
        }

        public static BoardCollection<T> FromJson(Func<JToken, T> boardFactoryDelegate, JToken jsonObject)
        {
            boardFactoryDelegate.ThrowIfNull(nameof(boardFactoryDelegate));

            var boardCollection = new BoardCollection<T>(Size<int>.FromJson(jsonObject["maximumBoardSize"]));

            foreach (JToken board in jsonObject["boards"])
            {
                boardCollection.Add(boardFactoryDelegate(board));
            }

            return boardCollection;
        }
    }
}