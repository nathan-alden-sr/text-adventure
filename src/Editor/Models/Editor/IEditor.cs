using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Editor.Factories;
using NathanAlden.TextAdventure.Editor.Forms;

namespace NathanAlden.TextAdventure.Editor.Models.Editor
{
    public interface IEditor
    {
        IMessageBus MessageBus { get; }
        IFormFactory FormFactory { get; }
        ICommandFactory CommandFactory { get; }
        IConfigFile<Config> ConfigFile { get; }
        IFileSystem FileSystem { get; }
        IWorld World { get; }
        WorldEditorForm WorldEditorForm { get; }
        bool Exiting { get; }

        void WorldChanged();
    }
}