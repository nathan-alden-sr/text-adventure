using System;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Editor.Controllers.WorldVariables;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariable
{
    public class WorldVariableController : FormController<IWorldVariableView>, IWorldVariableController
    {
        private readonly IConfigFile<Config> _configFile;

        public WorldVariableController(IWorldVariableView view, IConfigFile<Config> configFile)
            : base(view)
        {
            _configFile = configFile.EnsureNotNull(nameof(configFile));

            AddDisposables(View.ViewClosing.Subscribe(x => ViewClosing()));

            View.RestoreBounds(_configFile.Config.Views.WorldVariable.Bounds);
        }

        public WorldVariableViewModel ShowNewView(IWin32Window owner, WorldVariableViewModel viewModel = null, string category = null)
        {
            owner.ThrowIfNull(nameof(owner));

            viewModel = viewModel ?? new WorldVariableViewModel
                                     {
                                         Category = category,
                                         Type = WorldVariableType.String
                                     };

            return View.ShowView(owner, viewModel, EditMode.New) == DialogResult.OK ? viewModel : null;
        }

        public WorldVariableViewModel ShowEditView(IWin32Window owner, WorldVariableViewModel viewModel)
        {
            owner.ThrowIfNull(nameof(owner));
            viewModel.ThrowIfNull(nameof(viewModel));

            return View.ShowView(owner, viewModel, EditMode.Edit) == DialogResult.OK ? viewModel : null;
        }

        private void ViewClosing()
        {
            SaveViewBounds(_configFile.Config.Views.WorldVariable.Bounds);
            _configFile.Save();
        }
    }
}