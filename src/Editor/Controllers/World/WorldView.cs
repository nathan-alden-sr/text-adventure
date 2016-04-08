using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    public partial class WorldView : FormView, IWorldView
    {
        private readonly Subject<Unit> _fileCloseWorldRequested = new Subject<Unit>();
        private readonly Subject<Unit> _fileExitRequested = new Subject<Unit>();
        private readonly Subject<Unit> _fileNewWorldRequested = new Subject<Unit>();
        private readonly Subject<Unit> _fileOpenWorldRequested = new Subject<Unit>();
        private readonly Subject<Unit> _fileSaveWorldAsRequested = new Subject<Unit>();
        private readonly Subject<Unit> _fileSaveWorldRequested = new Subject<Unit>();
        private readonly Subject<Unit> _helpAboutRequested = new Subject<Unit>();
        private readonly Subject<Unit> _toolsOptionsRequested = new Subject<Unit>();
        private readonly Subject<FormClosingEventArgs> _viewClosing = new Subject<FormClosingEventArgs>();
        private readonly Subject<Unit> _worldVariablesRequested = new Subject<Unit>();

        public WorldView()
        {
            InitializeComponent();
        }

        public IObservable<Unit> FileCloseWorldRequested => _fileCloseWorldRequested.AsObservable();
        public IObservable<Unit> FileExitRequested => _fileExitRequested.AsObservable();
        public IObservable<Unit> FileNewWorldRequested => _fileNewWorldRequested.AsObservable();
        public IObservable<Unit> FileOpenWorldRequested => _fileOpenWorldRequested.AsObservable();
        public IObservable<Unit> FileSaveWorldAsRequested => _fileSaveWorldAsRequested.AsObservable();
        public IObservable<Unit> FileSaveWorldRequested => _fileSaveWorldRequested.AsObservable();
        public IObservable<Unit> HelpAboutRequested => _helpAboutRequested.AsObservable();
        public IObservable<Unit> ToolsOptionsRequested => _toolsOptionsRequested.AsObservable();
        public IObservable<FormClosingEventArgs> ViewClosing => _viewClosing.AsObservable();
        public IObservable<Unit> WorldVariablesRequested => _worldVariablesRequested.AsObservable();

        public void ShowView()
        {
            Application.Run(this);
        }

        public void CloseView()
        {
            Close();
        }

        public void SetTitle(string title)
        {
            Text = title;
        }

        public void ShowWorldToolStrips()
        {
            toolStripMenuItemWorld.Visible = true;
            toolStripWorld.Visible = true;
        }

        public void HideWorldToolStrips()
        {
            toolStripMenuItemWorld.Visible = false;
            toolStripWorld.Visible = false;
        }

        public void EnableCloseWorldToolStripItems()
        {
            toolStripMenuItemCloseWorld.Enabled = true;
        }

        public void DisableCloseWorldToolStripItems()
        {
            toolStripMenuItemCloseWorld.Enabled = false;
        }

        public void EnableSaveWorldToolStripItems()
        {
            toolStripButtonSaveWorld.Enabled = true;
            toolStripMenuItemSaveWorld.Enabled = true;
        }

        public void DisableSaveWorldToolStripItems()
        {
            toolStripButtonSaveWorld.Enabled = false;
            toolStripMenuItemSaveWorld.Enabled = false;
        }

        public void EnableSaveWorldAsToolStripItems()
        {
            toolStripMenuItemSaveWorldAs.Enabled = true;
        }

        public void DisableSaveWorldAsToolStripItems()
        {
            toolStripMenuItemSaveWorldAs.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _viewClosing.OnNext(e);

            base.OnFormClosing(e);
        }

        private void toolStripMenuItemNewWorld_Click(object sender, EventArgs e)
        {
            _fileNewWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemOpenWorld_Click(object sender, EventArgs e)
        {
            _fileOpenWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemCloseWorld_Click(object sender, EventArgs e)
        {
            _fileCloseWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemSaveWorld_Click(object sender, EventArgs e)
        {
            _fileSaveWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemSaveWorldAs_Click(object sender, EventArgs e)
        {
            _fileSaveWorldAsRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            _fileExitRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemVariables_Click(object sender, EventArgs e)
        {
            _worldVariablesRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemOptions_Click(object sender, EventArgs e)
        {
            _toolsOptionsRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            _helpAboutRequested.OnNext(Unit.Default);
        }

        private void toolStripButtonNewWorld_Click(object sender, EventArgs e)
        {
            _fileNewWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripButtonOpenWorld_Click(object sender, EventArgs e)
        {
            _fileOpenWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripButtonSaveWorld_Click(object sender, EventArgs e)
        {
            _fileSaveWorldRequested.OnNext(Unit.Default);
        }

        private void toolStripButtonWorldVariables_Click(object sender, EventArgs e)
        {
            _worldVariablesRequested.OnNext(Unit.Default);
        }
    }
}