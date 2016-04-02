using System;
using System.Windows.Forms;
using NathanAlden.TextAdventure.Editor.Commands;
using NathanAlden.TextAdventure.Editor.Models.Editor;

namespace NathanAlden.TextAdventure.Editor.Forms
{
    public partial class AboutForm : EditorForm
    {
        private OpenGitHubUrlCommand _openGitHubUrlCommand;

        public AboutForm(IEditor editor)
            : base(editor)
        {
            InitializeComponent();
        }

        private AboutForm()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            AddDisposables(_openGitHubUrlCommand = new OpenGitHubUrlCommand());

            base.OnLoad(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            base.OnKeyDown(e);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _openGitHubUrlCommand.Execute(Constants.GitHubUrl);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            _openGitHubUrlCommand.Execute(Constants.GitHubUrl);
        }
    }
}