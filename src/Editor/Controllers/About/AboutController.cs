using System;
using System.Diagnostics;
using System.Windows.Forms;
using Junior.Common.Net35;

namespace NathanAlden.TextAdventure.Editor.Controllers.About
{
    public class AboutController : Controller<IAboutView>, IAboutController
    {
        public AboutController(IAboutView view)
            : base(view)
        {
            AddDisposables(View.GitHubNavigationRequested.Subscribe(x => NavigateToGitHub()));
        }

        public void ShowView(IWin32Window owner)
        {
            owner.ThrowIfNull(nameof(owner));

            View.ShowView(owner);
        }

        private static void NavigateToGitHub()
        {
            Process.Start(Constants.GitHubUrl.ToString());
        }
    }
}