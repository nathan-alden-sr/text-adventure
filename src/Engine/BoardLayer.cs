using System;
using Newtonsoft.Json.Linq;

namespace NathanAlden.TextAdventure.Engine
{
    public class BoardLayer : IBoardLayer
    {
        private readonly byte[,] _characters;

        public BoardLayer(Size<int> size)
        {
            Size = size;

            _characters = new byte[size.Height, size.Width];
        }

        public Size<int> Size { get; }

        public byte GetCharacter(Coordinate<int> coordinate)
        {
            return _characters[coordinate.Y, coordinate.X];
        }

        public void SetCharacter(Coordinate<int> coordinate, byte character)
        {
            _characters[coordinate.Y, coordinate.X] = character;
        }

        public void ClearCharacter(Coordinate<int> coordinate)
        {
            _characters[coordinate.Y, coordinate.X] = 0;
        }

        public byte[,] GetCharacters()
        {
            var characters = new byte[Size.Height, Size.Width];

            Array.Copy(_characters, characters, _characters.Length);

            return characters;
        }

        public object SerializeToJsonObject()
        {
            var characters = new byte[_characters.Length];

            Buffer.BlockCopy(_characters, 0, characters, 0, _characters.Length);

            return new
                   {
                       size = Size.SerializeToJsonObject(),
                       charactersBase64 = Convert.ToBase64String(characters)
                   };
        }

        public static BoardLayer FromJson(JToken jsonObject)
        {
            var boardLayer = new BoardLayer(Size<int>.FromJson(jsonObject["size"]));
            byte[] characters = Convert.FromBase64String(jsonObject.Value<string>("charactersBase64"));

            Buffer.BlockCopy(characters, 0, boardLayer._characters, 0, characters.Length);

            return boardLayer;
        }
    }
}