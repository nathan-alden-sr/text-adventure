using System;
using System.IO;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Editor.Controllers.About;
using NathanAlden.TextAdventure.Editor.Controllers.NewWorld;
using NathanAlden.TextAdventure.Editor.Controllers.WorldVariables;
using NathanAlden.TextAdventure.Editor.Factories;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Models.World;
using Newtonsoft.Json;

namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    public class WorldController : Controller<IWorldView>, IWorldController
    {
        private static readonly string _dialogFilter = $"Text Adventure Worlds (*.{Constants.WorldFileExtension})|*.{Constants.WorldFileExtension}|All Files (*.*)|*.*";
        private readonly IConfigFile<Config> _configFile;
        private readonly IControllerFactory _controllerFactory;
        private readonly IFileSystem _fileSystem;
        private WorldClass _world;

        public WorldController(IWorldView view, IControllerFactory controllerFactory, IMessageBus messageBus, IConfigFile<Config> configFile, IFileSystem fileSystem)
            : base(view)
        {
            messageBus.ThrowIfNull(nameof(messageBus));

            _controllerFactory = controllerFactory.EnsureNotNull(nameof(controllerFactory));
            _configFile = configFile.EnsureNotNull(nameof(configFile));
            _fileSystem = fileSystem.EnsureNotNull(nameof(fileSystem));

            AddDisposables(
                messageBus.GetObservable<WorldChangedMessage>().Subscribe(ReceiveMessage),
                View.FileCloseWorldRequested.Subscribe(x => CloseWorld()),
                View.FileExitRequested.Subscribe(x => Exit()),
                View.FileNewWorldRequested.Subscribe(x => NewWorld()),
                View.FileOpenWorldRequested.Subscribe(x => OpenWorld()),
                View.FileSaveWorldAsRequested.Subscribe(x => SaveWorldAs()),
                View.FileSaveWorldRequested.Subscribe(x => SaveWorld()),
                View.HelpAboutRequested.Subscribe(x => About()),
                View.ToolsOptionsRequested.Subscribe(x => Options()),
                View.ViewClosing.Subscribe(x => x.Cancel = !ViewClosing(x.CloseReason == CloseReason.UserClosing)),
                View.WorldVariablesRequested.Subscribe(x => Variables()));

            View.RestoreBounds(_configFile.Config.Views.World.Bounds);
            View.SetTitle(ViewTitle);
            View.HideWorldToolStrips();
            View.DisableCloseWorldToolStripItems();
            View.DisableSaveWorldToolStripItems();
            View.DisableSaveWorldAsToolStripItems();
        }

        public IWorld World => _world;
        private string ViewTitle => World != null ? $"{World.Model.Name}{(World.Status == WorldStatus.Changed ? " (modified)" : "")} - {Constants.ApplicationName}" : Constants.ApplicationName;

        public void ShowView()
        {
            View.ShowView();
        }

        private void ReceiveMessage(WorldChangedMessage message)
        {
            _world.Status = WorldStatus.Changed;
            View.EnableSaveWorldToolStripItems();
            View.SetTitle(ViewTitle);
        }

        private bool ViewClosing(bool userClosing)
        {
            if (userClosing && !CloseWorld())
            {
                return false;
            }

            SaveViewBounds(_configFile.Config.Views.World.Bounds);
            _configFile.Save();

            return true;
        }

        private void NewWorld()
        {
            WorldModel model;

            using (var newWorldController = _controllerFactory.Create<INewWorldController>())
            {
                model = newWorldController.ShowView(View);
            }

            if (model == null || !CloseWorld())
            {
                return;
            }

            _world = new WorldClass
                     {
                         Model = model,
                         Status = WorldStatus.Changed
                     };

            View.EnableCloseWorldToolStripItems();
            View.EnableSaveWorldToolStripItems();
            View.EnableSaveWorldAsToolStripItems();
            View.ShowWorldToolStrips();
            View.SetTitle(ViewTitle);
        }

        private void OpenWorld()
        {
            using (var openFileDialog = new OpenFileDialog
                                        {
                                            CheckFileExists = true,
                                            CheckPathExists = true,
                                            DefaultExt = Constants.WorldFileExtension,
                                            FileName = Path.GetFileName(_configFile.Config.FileSystem.MostRecentWorldPath),
                                            Filter = _dialogFilter,
                                            InitialDirectory = _configFile.Config.FileSystem.MostRecentWorldPath.IfNotNull(Path.GetDirectoryName),
                                            Multiselect = false,
                                            ShowHelp = false,
                                            Title = Constants.OpenFileDialogTitle
                                        })
            {
                DialogResult result = openFileDialog.ShowDialog(View);

                if (result != DialogResult.OK)
                {
                    return;
                }

                _configFile.Config.FileSystem.MostRecentWorldPath = openFileDialog.FileName;
                _configFile.Save();

                if (!CloseWorld())
                {
                    return;
                }

                _world = new WorldClass
                         {
                             Model = JsonConvert.DeserializeObject<WorldModel>(File.ReadAllText(openFileDialog.FileName)),
                             Path = openFileDialog.FileName,
                             Status = WorldStatus.Unchanged
                         };

                View.EnableCloseWorldToolStripItems();
                View.EnableSaveWorldAsToolStripItems();
                View.ShowWorldToolStrips();
                View.SetTitle(ViewTitle);
            }
        }

        private bool CloseWorld()
        {
            if (World?.Status == WorldStatus.Changed)
            {
                DialogResult result = View.ShowMessageBox("Your world has unsaved changes. Save now?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        if (!SaveWorld())
                        {
                            return false;
                        }
                        break;
                }
            }

            _world = null;

            View.DisableCloseWorldToolStripItems();
            View.DisableSaveWorldToolStripItems();
            View.DisableSaveWorldAsToolStripItems();
            View.HideWorldToolStrips();
            View.SetTitle(ViewTitle);

            return true;
        }

        private bool SaveWorld()
        {
            if (_world.Path == null)
            {
                return SaveWorldAs();
            }

            SaveWorldModel(_world.Path);

            return true;
        }

        private bool SaveWorldAs()
        {
            string directory = World.Path != null ? Path.GetDirectoryName(World.Path) : _fileSystem.WorldDirectory;
            string filename = World.Path != null ? Path.GetFileName(World.Path) : PathUtility.StripIllegalCharacters(World.Model.Name);

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
                DialogResult result = saveFileDialog.ShowDialog(View);

                if (result != DialogResult.OK)
                {
                    return false;
                }

                _configFile.Config.FileSystem.MostRecentWorldPath = saveFileDialog.FileName;
                _configFile.Save();

                SaveWorldModel(saveFileDialog.FileName);
            }

            return true;
        }

        private void SaveWorldModel(string path)
        {
            JsonUtility.Save(path, World.Model);

            _world.Path = path;
            _world.Status = WorldStatus.Unchanged;

            View.DisableSaveWorldToolStripItems();
            View.SetTitle(ViewTitle);
        }

        private void Exit()
        {
            if (!ViewClosing(true))
            {
                return;
            }

            View.CloseView();
        }

        private void Variables()
        {
            using (var worldVariablesController = _controllerFactory.Create<IWorldVariablesController>())
            {
                worldVariablesController.ShowView(View, _world.Model);
            }
        }

        private void Options()
        {
        }

        private void About()
        {
            using (var aboutController = _controllerFactory.Create<IAboutController>())
            {
                aboutController.ShowView(View);
            }
        }

        private class WorldClass : IWorld
        {
            public WorldModel Model { get; set; }
            public WorldStatus Status { get; set; }
            public string Path { get; set; }
        }
    }
}