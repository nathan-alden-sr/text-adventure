namespace NathanAlden.TextAdventure.Common.Config
{
    public interface IConfigFile<out T>
        where T : class, new()
    {
        T Config { get; }
        void Save();
    }
}