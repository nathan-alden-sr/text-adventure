using NathanAlden.TextAdventure.Common.WindowsForms.Commands;

namespace NathanAlden.TextAdventure.Editor.Factories
{
    public interface ICommandFactory
    {
        T Create<T>()
            where T : ICommand;
    }
}