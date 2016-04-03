using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.About
{
    public partial class AboutView : FormView, IAboutView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public IObservable<Unit> GitHubNavigationRequested => Observable.FromEvent(
            x =>
            {
                linkLabel.LinkClicked += LinkLabelOnLinkClicked(x);
                pictureBox.Click += PictureBoxOnClick(x);
            },
            x =>
            {
                linkLabel.LinkClicked -= LinkLabelOnLinkClicked(x);
                pictureBox.Click -= PictureBoxOnClick(x);
            });

        public void ShowView(IWin32Window owner)
        {
            ShowDialog(owner);
        }

        public void CloseView()
        {
            Close();
        }

        private static LinkLabelLinkClickedEventHandler LinkLabelOnLinkClicked(Action action)
        {
            return (sender, args) => action();
        }

        private static EventHandler PictureBoxOnClick(Action action)
        {
            return (sender, args) => action();
        }
    }
}