using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.About
{
    public partial class AboutView : FormView, IAboutView
    {
        private readonly Subject<Unit> _gitHubNavigationRequested = new Subject<Unit>();

        public AboutView()
        {
            InitializeComponent();
        }

        public IObservable<Unit> GitHubNavigationRequested => _gitHubNavigationRequested.AsObservable();

        public void ShowView(IWin32Window owner)
        {
            ShowDialog(owner);
        }

        public void CloseView()
        {
            Close();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            _gitHubNavigationRequested.OnNext(Unit.Default);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _gitHubNavigationRequested.OnNext(Unit.Default);
        }
    }
}