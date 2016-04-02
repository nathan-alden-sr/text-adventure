using System;
using System.Diagnostics;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.Commands;

namespace NathanAlden.TextAdventure.Editor.Commands
{
    public class OpenGitHubUrlCommand : Command<Uri>
    {
        protected override void OnExecute(Uri data)
        {
            this.ThrowIfDisposed(Disposed);

            data.ThrowIfNull(nameof(data));

            Process.Start(data.ToString());
        }
    }
}