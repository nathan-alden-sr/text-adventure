using System;
using System.Reactive;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Editor.Configuration;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public class WorldVariablesController : Controller<IWorldVariablesView>, IWorldVariablesController
    {
        private readonly IConfigFile<Config> _configFile;

        public WorldVariablesController(IWorldVariablesView worldVariablesView, IConfigFile<Config> configFile)
            : base(worldVariablesView)
        {
            _configFile = configFile.EnsureNotNull(nameof(configFile));

            AddDisposables(View.KeyDown.Subscribe(KeyDown));

            View.RestoreBounds(configFile.Config.Views.WorldVariables.Bounds, false);
            View.RestoreVariablesListColumnWidths(configFile.Config.Views.WorldVariables.ColumnWidths);
            View.ViewAllCategories();
        }

        public void ShowView(IWin32Window owner)
        {
            owner.ThrowIfNull(nameof(owner));

            View.ShowView(owner);

            SaveViewBounds(_configFile.Config.Views.WorldVariables.Bounds, false);
            _configFile.Config.Views.WorldVariables.ColumnWidths.Clear();
            _configFile.Config.Views.WorldVariables.ColumnWidths.AddRange(View.VariablesListColumnWidths);
        }

        private void KeyDown(EventPattern<KeyEventArgs> eventPattern)
        {
            if (eventPattern.EventArgs.KeyCode == Keys.Escape)
            {
                View.CloseView();
            }
        }
    }
}