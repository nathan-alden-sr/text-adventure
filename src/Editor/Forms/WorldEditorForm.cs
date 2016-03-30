using System;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Commands;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Forms
{
    public partial class WorldEditorForm : Form
    {
        private readonly IEditor _editor;
        private ExitCommand _exitCommand;

        public WorldEditorForm(IEditor editor)
        {
            editor.ThrowIfNull(nameof(editor));

            _editor = editor;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _editor.CommandFactory.CreateAndAttachToMenuItem<NewWorldCommand>(newWorldToolStripMenuItem, Keys.Control | Keys.N, image:IconResources.Create_16x);
            _editor.CommandFactory.CreateAndAttachToMenuItem<OpenWorldCommand>(openWorldToolStripMenuItem, Keys.Control | Keys.O, image:IconResources.Open_16x);
            _editor.CommandFactory.CreateAndAttachToMenuItem<CloseWorldCommand>(closeWorldToolStripMenuItem);
            _editor.CommandFactory.CreateAndAttachToMenuItem<SaveWorldCommand>(saveWorldToolStripMenuItem, Keys.Control | Keys.S, image:IconResources.Save_16x);
            _editor.CommandFactory.CreateAndAttachToMenuItem<SaveWorldAsCommand>(saveWorldAsToolStripMenuItem);
            _exitCommand = _editor.CommandFactory.CreateAndAttachToMenuItem<ExitCommand>(exitToolStripMenuItem, shortcutKeyDisplayString:"Alt+F4");
            _editor.CommandFactory.CreateAndAttachToMenuItem<OptionsCommand>(optionsToolStripMenuItem);
            _editor.CommandFactory.CreateAndAttachToMenuItem<AboutCommand>(aboutToolStripMenuItem);

            _editor.MessageBus.Subscribe<WorldLoadedMessage>(ReceiveMessage);
            _editor.MessageBus.Subscribe<WorldClosedMessage>(ReceiveMessage);
            _editor.MessageBus.Subscribe<WorldSavedMessage>(ReceiveMessage);
            _editor.MessageBus.Subscribe<WorldChangedMessage>(ReceiveMessage);

            Bounds = _editor.ConfigFile.Config.WindowLocations.WorldEditor.Bounds;
            WindowState = _editor.ConfigFile.Config.WindowLocations.WorldEditor.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            Text = Constants.ApplicationName;

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_editor.Exiting)
            {
                _exitCommand.Execute();

                e.Cancel = true;
            }
            else
            {
                _editor.ConfigFile.Config.WindowLocations.WorldEditor.Bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
                _editor.ConfigFile.Config.WindowLocations.WorldEditor.Maximized = WindowState == FormWindowState.Maximized;
                _editor.ConfigFile.Save();
            }

            base.OnFormClosing(e);
        }

        private ReceiveMessageResult ReceiveMessage(WorldLoadedMessage message)
        {
            SetTitle(message.Data);

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldClosedMessage message)
        {
            SetTitle();

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldSavedMessage message)
        {
            SetTitle(message.Data);

            return ReceiveMessageResult.Continue;
        }

        private ReceiveMessageResult ReceiveMessage(WorldChangedMessage message)
        {
            SetTitle(message.Data);

            return ReceiveMessageResult.Continue;
        }

        private void SetTitle(IWorld world = null)
        {
            Text = world != null ? $"{world.Model.Name}{(world.Status == WorldStatus.Changed ? " (modified)" : "")} - {Constants.ApplicationName}" : Constants.ApplicationName;
        }
    }
}