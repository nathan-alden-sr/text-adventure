using System;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Common.WindowsForms.Commands;
using NathanAlden.TextAdventure.Editor.Commands;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Forms
{
    public partial class WorldEditorForm : EditorForm
    {
        private ICommand _exitCommand;

        public WorldEditorForm(IEditor editor)
            : base(editor)
        {
            InitializeComponent();
        }

        private WorldEditorForm()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            AddDisposables(
                Editor.CommandFactory.Create<NewWorldCommand>().AttachToToolStripItems(toolStripMenuItemNewWorld, toolStripButtonNewWorld),
                Editor.CommandFactory.Create<OpenWorldCommand>().AttachToToolStripItems(toolStripMenuItemOpenWorld, toolStripButtonOpenWorld),
                Editor.CommandFactory.Create<CloseWorldCommand>().AttachToToolStripItems(toolStripMenuItemCloseWorld),
                Editor.CommandFactory.Create<SaveWorldCommand>().AttachToToolStripItems(toolStripMenuItemSaveWorld, toolStripButtonSaveWorld),
                Editor.CommandFactory.Create<SaveWorldAsCommand>().AttachToToolStripItems(toolStripMenuItemSaveWorldAs),
                _exitCommand = Editor.CommandFactory.Create<ExitCommand>().AttachToToolStripItems(toolStripMenuItemExit),
                Editor.CommandFactory.Create<OptionsCommand>().AttachToToolStripItems(toolStripMenuItemOptions),
                Editor.CommandFactory.Create<AboutCommand>().AttachToToolStripItems(toolStripMenuItemAbout),
                Editor.MessageBus.Subscribe<WorldLoadedMessage>(ReceiveMessage),
                Editor.MessageBus.Subscribe<WorldClosedMessage>(ReceiveMessage),
                Editor.MessageBus.Subscribe<WorldSavedMessage>(ReceiveMessage),
                Editor.MessageBus.Subscribe<WorldChangedMessage>(ReceiveMessage));

            Bounds = Editor.ConfigFile.Config.WindowLocations.WorldEditor.Bounds;
            WindowState = Editor.ConfigFile.Config.WindowLocations.WorldEditor.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            Text = Constants.ApplicationName;

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!Editor.Exiting)
            {
                _exitCommand.Execute();

                e.Cancel = true;
            }
            else
            {
                Editor.ConfigFile.Config.WindowLocations.WorldEditor.Bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
                Editor.ConfigFile.Config.WindowLocations.WorldEditor.Maximized = WindowState == FormWindowState.Maximized;
                Editor.ConfigFile.Save();
            }

            base.OnFormClosing(e);
        }

        private void ReceiveMessage(WorldLoadedMessage message)
        {
            SetTitle(message.Data);
        }

        private void ReceiveMessage(WorldClosedMessage message)
        {
            SetTitle();
        }

        private void ReceiveMessage(WorldSavedMessage message)
        {
            SetTitle(message.Data);
        }

        private void ReceiveMessage(WorldChangedMessage message)
        {
            SetTitle(message.Data);
        }

        private void SetTitle(IWorld world = null)
        {
            Text = world != null ? $"{world.Model.Name}{(world.Status == WorldStatus.Changed ? " (modified)" : "")} - {Constants.ApplicationName}" : Constants.ApplicationName;
        }
    }
}