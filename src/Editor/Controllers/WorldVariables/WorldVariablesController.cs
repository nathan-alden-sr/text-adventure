using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Common.MessageBus;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Editor.Controllers.WorldVariable;
using NathanAlden.TextAdventure.Editor.Factories;
using NathanAlden.TextAdventure.Editor.Messages;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public class WorldVariablesController : Controller<IWorldVariablesView>, IWorldVariablesController
    {
        private readonly IConfigFile<Config> _configFile;
        private readonly IControllerFactory _controllerFactory;
        private readonly IMessageBus _messageBus;

        public WorldVariablesController(IWorldVariablesView view, IControllerFactory controllerFactory, IMessageBus messageBus, IConfigFile<Config> configFile)
            : base(view)
        {
            _controllerFactory = controllerFactory.EnsureNotNull(nameof(controllerFactory));
            _messageBus = messageBus.EnsureNotNull(nameof(messageBus));
            _configFile = configFile.EnsureNotNull(nameof(configFile));

            AddDisposables(
                View.NewRequested.Subscribe(x => NewRequested()),
                View.EditRequested.Subscribe(EditRequested),
                View.DeleteRequested.Subscribe(DeleteRequested));

            View.RestoreBounds(configFile.Config.Views.WorldVariables.Bounds, false);
            View.RestoreVariablesListColumnWidths(configFile.Config.Views.WorldVariables.ColumnWidths);
        }

        public void ShowView(IWin32Window owner, WorldModel model)
        {
            owner.ThrowIfNull(nameof(owner));
            model.ThrowIfNull(nameof(model));

            IEnumerable<WorldVariableViewModel> viewModels = model.Variables.Select(
                x => new WorldVariableViewModel
                     {
                         Category = x.Category,
                         Name = x.Name,
                         Type = x.Type,
                         Value = x.Value?.ToString()
                     });

            if (View.ShowView(owner, viewModels) == DialogResult.OK)
            {
                model.Variables.Clear();
                model.Variables.AddRange(View.Variables.Select(x => new WorldVariableModel
                                                                    {
                                                                        Category = x.Category,
                                                                        Name = x.Name,
                                                                        Type = x.Type,
                                                                        Value = x.TypedValue
                                                                    }));

                _messageBus.Publish<WorldChangedMessage>();
            }

            SaveViewBounds(_configFile.Config.Views.WorldVariables.Bounds, false);
            _configFile.Config.Views.WorldVariables.ColumnWidths.Clear();
            _configFile.Config.Views.WorldVariables.ColumnWidths.AddRange(View.VariablesListColumnWidths);
        }

        private void NewRequested()
        {
            using (var worldVariableController = _controllerFactory.Create<IWorldVariableController>())
            {
                WorldVariableViewModel viewModel = null;

                while (true)
                {
                    viewModel = worldVariableController.ShowNewView(View, viewModel, View.CategoryFilter);

                    if (viewModel == null)
                    {
                        return;
                    }
                    if (!IsVariableNameUnique(viewModel.Name))
                    {
                        continue;
                    }

                    View.AddVariable(viewModel);
                    return;
                }
            }
        }

        private void EditRequested(WorldVariableViewModel viewModel)
        {
            using (var worldVariableController = _controllerFactory.Create<IWorldVariableController>())
            {
                WorldVariableViewModel currentViewModel = View.SelectedVariables.Single();
                WorldVariableViewModel editedViewModel = currentViewModel.Clone();

                while (true)
                {
                    editedViewModel = worldVariableController.ShowEditView(View, editedViewModel);

                    if (editedViewModel == null)
                    {
                        return;
                    }
                    if (!currentViewModel.Name.Equals(editedViewModel.Name) && !IsVariableNameUnique(editedViewModel.Name))
                    {
                        continue;
                    }

                    View.ReplaceVariable(currentViewModel, editedViewModel);
                    return;
                }
            }
        }

        private void DeleteRequested(IEnumerable<WorldVariableViewModel> viewModels)
        {
            int count = viewModels.Count();

            if (count == 1 || (count > 1 && View.ShowMessageBox($"Delete {count} selected item{(count == 1 ? "" : "s")}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                View.DeleteSelectedVariables();
            }
        }

        private bool IsVariableNameUnique(string name)
        {
            if (!View.Variables.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            View.ShowMessageBox($"A variable named '{name}' already exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }
    }
}