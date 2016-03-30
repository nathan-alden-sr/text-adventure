using System;
using System.IO;
using System.Windows.Forms;
using Autofac;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Editor.Factories;
using NathanAlden.TextAdventure.Editor.Forms;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Models.World;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Models.Editor
{
    public class Editor : IEditor
    {
        private static readonly string _rootDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Constants.MyDocumentsFolderName);
        private static readonly string _dialogFilter = $"Text Adventure Worlds (*.{Constants.WorldFileExtension})|*.{Constants.WorldFileExtension}|All Files (*.*)|*.*";
        private WorldClass _world;

        public Editor(IComponentContext componentContext)
        {
            componentContext.ThrowIfNull(nameof(componentContext));

            Directory.CreateDirectory(_rootDirectory);

            MessageBus = new MessageBus();
            FormFactory = new FormFactory(componentContext);
            CommandFactory = new CommandFactory(componentContext);
            ConfigFile = new ConfigFile<Config>(Path.Combine(_rootDirectory, "config.json"));
            FileSystem = new FileSystemClass(ConfigFile);
            WorldEditorForm = new WorldEditorForm(this);

            MessageBus.Subscribe<WorldCreatingMessage>(ReceiveMessage);
            MessageBus.Subscribe<WorldCreatedMessage>(ReceiveMessage);
            MessageBus.Subscribe<WorldOpeningMessage>(ReceiveMessage);
            MessageBus.Subscribe<WorldSavingMessage>(ReceiveMessage);
            MessageBus.Subscribe<WorldClosingMessage>(ReceiveMessage);
            MessageBus.Subscribe<WorldChangedMessage>(ReceiveMessage);
            MessageBus.Subscribe<ExitingMessage>(ReceiveMessage);
        }

        public IMessageBus MessageBus { get; }
        public IFormFactory FormFactory { get; }
        public ICommandFactory CommandFactory { get; }
        public IFileSystem FileSystem { get; }
        public IConfigFile<Config> ConfigFile { get; }
        public IWorld World => _world;
        public WorldEditorForm WorldEditorForm { get; }
        public bool Exiting { get; private set; }

        private ReceiveMessageResult ReceiveMessage(WorldCreatingMessage message)
        {
            if (MessageBus.Publish<WorldClosingMessage>() == PublishResult.Canceled)
            {
                return ReceiveMessageResult.Stop;
            }

            WorldModel model;

            using (var form = FormFactory.Create<NewWorldForm>())
            {
                model = form.Display(WorldEditorForm);

                if (model == null)
                {
                    return ReceiveMessageResult.Stop;
                }
            }

            MessageBus.Publish(new WorldCreatedMessage(model));

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldCreatedMessage message)
        {
            _world = new WorldClass
                     {
                         Model = message.Data,
                         Status = WorldStatus.Changed
                     };

            MessageBus.Publish(new WorldLoadedMessage(World));

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldOpeningMessage message)
        {
            if (MessageBus.Publish<WorldClosingMessage>() == PublishResult.Canceled)
            {
                return ReceiveMessageResult.Stop;
            }

            string path = PromptToOpen();

            if (path == null)
            {
                return ReceiveMessageResult.Stop;
            }

            _world = new WorldClass
                     {
                         Model = JsonConvert.DeserializeObject<WorldModel>(File.ReadAllText(path)),
                         Path = path,
                         Status = WorldStatus.Unchanged
                     };

            MessageBus.Publish(new WorldLoadedMessage(World));

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldSavingMessage message)
        {
            if (World == null)
            {
                return ReceiveMessageResult.Stop;
            }
            if (World.Status == WorldStatus.Unchanged && !message.SavingAs)
            {
                return ReceiveMessageResult.Continue;
            }

            string directory = World.Path != null ? Path.GetDirectoryName(World.Path) : FileSystem.WorldDirectory;
            string filename = World.Path != null ? Path.GetFileName(World.Path) : PathUtility.StripIllegalCharacters(World.Model.Name);
            string path = PromptToSave(directory, filename);

            if (path == null)
            {
                return ReceiveMessageResult.Stop;
            }

            JsonUtility.Save(path, World.Model);

            _world.Path = path;
            _world.Status = WorldStatus.Unchanged;

            MessageBus.Publish(new WorldSavedMessage(World));

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldClosingMessage message)
        {
            if (World == null)
            {
                return ReceiveMessageResult.Continue;
            }
            if (PromptToSaveChanges() == SaveChangesResult.Stop)
            {
                return ReceiveMessageResult.Stop;
            }

            _world = null;

            MessageBus.Publish<WorldClosedMessage>();

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldChangedMessage message)
        {
            if (World == null)
            {
                return ReceiveMessageResult.Stop;
            }

            _world.Status = WorldStatus.Changed;

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(ExitingMessage message)
        {
            if (MessageBus.Publish<WorldClosingMessage>() == PublishResult.Canceled)
            {
                return ReceiveMessageResult.Stop;
            }

            Exiting = true;

            WorldEditorForm.Close();

            return ReceiveMessageResult.Continue;
        }

        private SaveChangesResult PromptToSaveChanges()
        {
            if (World.Status == WorldStatus.Unchanged)
            {
                return SaveChangesResult.Continue;
            }

            DialogResult dialogResult = MessageBox.Show(WorldEditorForm, "Your world has unsaved changes. Save now?", Constants.MessageBoxTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (dialogResult)
            {
                case DialogResult.Cancel:
                    return SaveChangesResult.Stop;
                case DialogResult.Yes:
                    PublishResult publishResult = MessageBus.Publish(new WorldSavingMessage(false));

                    return publishResult == PublishResult.Success ? SaveChangesResult.Continue : SaveChangesResult.Stop;
                default:
                    return SaveChangesResult.Continue;
            }
        }

        private string PromptToOpen()
        {
            using (var openFileDialog = new OpenFileDialog
                                        {
                                            CheckFileExists = true,
                                            CheckPathExists = true,
                                            DefaultExt = Constants.WorldFileExtension,
                                            FileName = Path.GetFileName(ConfigFile.Config.FileSystem.MostRecentWorldPath),
                                            Filter = _dialogFilter,
                                            InitialDirectory = ConfigFile.Config.FileSystem.MostRecentWorldPath.IfNotNull(Path.GetDirectoryName),
                                            Multiselect = false,
                                            ShowHelp = false,
                                            Title = Constants.OpenFileDialogTitle
                                        })
            {
                DialogResult result = openFileDialog.ShowDialog(WorldEditorForm);

                if (result != DialogResult.OK)
                {
                    return null;
                }

                ConfigFile.Config.FileSystem.MostRecentWorldPath = openFileDialog.FileName;
                ConfigFile.Save();

                return openFileDialog.FileName;
            }
        }

        private string PromptToSave(string directory, string filename)
        {
            using (var saveFileDialog = new SaveFileDialog
                                        {
                                            CheckFileExists = false,
                                            CheckPathExists = false,
                                            DefaultExt = Constants.WorldFileExtension,
                                            FileName = filename,
                                            Filter = _dialogFilter,
                                            InitialDirectory = directory,
                                            OverwritePrompt = true,
                                            ShowHelp = false,
                                            Title = Constants.SaveFileDialogTitle,
                                            ValidateNames = false
                                        })
            {
                DialogResult result = saveFileDialog.ShowDialog(WorldEditorForm);

                if (result != DialogResult.OK)
                {
                    return null;
                }

                ConfigFile.Config.FileSystem.MostRecentWorldPath = saveFileDialog.FileName;
                ConfigFile.Save();

                return saveFileDialog.FileName;
            }
        }

        private class WorldClass : IWorld
        {
            public WorldModel Model { get; set; }
            public WorldStatus Status { get; set; }
            public string Path { get; set; }
        }

        private class FileSystemClass : IFileSystem
        {
            private readonly IConfigFile<Config> _configFile;

            public FileSystemClass(IConfigFile<Config> configFile)
            {
                _configFile = configFile;
            }

            public string WorldDirectory => Directory.CreateDirectory(Path.GetDirectoryName(_configFile.Config.FileSystem.MostRecentWorldPath) ?? _rootDirectory).FullName;
        }

        private enum SaveChangesResult
        {
            Continue,
            Stop
        }
    }
}