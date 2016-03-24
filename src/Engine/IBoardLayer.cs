namespace NathanAlden.TextAdventure.Engine
{
    public interface IBoardLayer : IJsonSerializable
    {
        Size<int> Size { get; }

        byte GetCharacter(Coordinate<int> coordinate);
        void SetCharacter(Coordinate<int> coordinate, byte character);
        void ClearCharacter(Coordinate<int> coordinate);
        byte[,] GetCharacters();
    }
}