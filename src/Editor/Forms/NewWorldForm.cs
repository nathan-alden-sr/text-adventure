using System;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators;
using NathanAlden.TextAdventure.Editor.ViewModels.NewWorld;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Forms
{
    public partial class NewWorldForm : Form
    {
        private readonly IGuidFactory _guidFactory;
        private readonly NewWorldViewModel _viewModel = new NewWorldViewModel();

        public NewWorldForm(IGuidFactory guidFactory)
        {
            guidFactory.ThrowIfNull(nameof(guidFactory));

            _guidFactory = guidFactory;

            InitializeComponent();
        }

        public WorldModel Display(IWin32Window owner)
        {
            owner.ThrowIfNull(nameof(owner));

            return ShowDialog(owner) == DialogResult.OK
                ? new WorldModel
                  {
                      Author = _viewModel.Author,
                      Id = _viewModel.IdAsGuid,
                      Name = _viewModel.WorldName,
                      Resources =
                      {
                          Charactersets =
                          {
                              new WorldResourceCharactersetModel
                              {
                                  Id = _guidFactory.Random(),
                                  Name = "standard",
                                  PngBase64 = CharactersetResources.standard.AsBase64Png()
                              }
                          }
                      },
                      Versions =
                      {
                          World = _viewModel.Version
                      }
                  }
                : null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bindingSource.DataSource = _viewModel;

            ViewModelValidator.AttachControlDecoratorsRecursive<NewWorldViewModel, TextBox, TextBoxDecorator>(_viewModel, this);
            ViewModelValidator.AttachToolTipRecursive<NewWorldViewModel, TextBox>(_viewModel, this, toolTip);
            ViewModelValidator.AttachToolTip(_viewModel, pictureBoxValidationError, toolTip);

            _viewModel.IdAsGuid = _guidFactory.Random();
            _viewModel.Version = "1.0";
            _viewModel.Validate();

            ActiveControl = promptTextBoxWorldName;
        }

        private void buttonGenerateId_Click(object sender, EventArgs e)
        {
            _viewModel.IdAsGuid = _guidFactory.Random();
        }
    }
}