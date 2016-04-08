using System;
using Junior.Common.Net40;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.PairMappers
{
    public class WorldVariableTypePairMapper : PairMapper<WorldVariableType, string>
    {
        public static readonly WorldVariableTypePairMapper Instance = new WorldVariableTypePairMapper();

        private WorldVariableTypePairMapper()
            : base(
                new Tuple<WorldVariableType, string>(WorldVariableType.Boolean, "Boolean"),
                new Tuple<WorldVariableType, string>(WorldVariableType.Character, "Character"),
                new Tuple<WorldVariableType, string>(WorldVariableType.FixedPoint, "Fixed-point"),
                new Tuple<WorldVariableType, string>(WorldVariableType.Integer, "Integer"),
                new Tuple<WorldVariableType, string>(WorldVariableType.String, "String"))
        {
        }
    }
}