using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    public partial class WorldView : FormView, IWorldView
    {
        public WorldView()
        {
            InitializeComponent();
        }

        public IObservable<EventPattern<FormClosingEventArgs>> ViewClosing => Observable.FromEventPattern<FormClosingEventHandler, FormClosingEventArgs>(x => FormClosing += x, x => FormClosing -= x);
        public IObservable<EventPattern<object>> CloseWorld => Observable.FromEventPattern(x => toolStripMenuItemCloseWorld.Click += x, x => toolStripMenuItemCloseWorld.Click -= x);
        public IObservable<EventPattern<object>> SaveWorldAs => Observable.FromEventPattern(x => toolStripMenuItemSaveWorldAs.Click += x, x => toolStripMenuItemSaveWorldAs.Click -= x);
        public IObservable<EventPattern<object>> Exit => Observable.FromEventPattern(x => toolStripMenuItemExit.Click += x, x => toolStripMenuItemExit.Click -= x);
        public IObservable<EventPattern<object>> Options => Observable.FromEventPattern(x => toolStripMenuItemOptions.Click += x, x => toolStripMenuItemOptions.Click -= x);
        public IObservable<EventPattern<object>> About => Observable.FromEventPattern(x => toolStripMenuItemAbout.Click += x, x => toolStripMenuItemAbout.Click -= x);

        public IObservable<EventPattern<object>> NewWorld => Observable.FromEventPattern(
            x =>
            {
                toolStripMenuItemNewWorld.Click += x;
                toolStripButtonNewWorld.Click += x;
            },
            x =>
            {
                toolStripMenuItemNewWorld.Click -= x;
                toolStripButtonNewWorld.Click -= x;
            });

        public IObservable<EventPattern<object>> OpenWorld => Observable.FromEventPattern(
            x =>
            {
                toolStripMenuItemOpenWorld.Click += x;
                toolStripButtonOpenWorld.Click += x;
            },
            x =>
            {
                toolStripMenuItemOpenWorld.Click -= x;
                toolStripButtonOpenWorld.Click -= x;
            });

        public IObservable<EventPattern<object>> SaveWorld => Observable.FromEventPattern(
            x =>
            {
                toolStripMenuItemSaveWorld.Click += x;
                toolStripButtonSaveWorld.Click += x;
            },
            x =>
            {
                toolStripMenuItemSaveWorld.Click -= x;
                toolStripButtonSaveWorld.Click -= x;
            });

        public IObservable<EventPattern<object>> Variables => Observable.FromEventPattern(
            x =>
            {
                toolStripButtonWorldVariables.Click += x;
                toolStripMenuItemVariables.Click += x;
            },
            x =>
            {
                toolStripButtonWorldVariables.Click -= x;
                toolStripMenuItemVariables.Click -= x;
            });

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
    }
}