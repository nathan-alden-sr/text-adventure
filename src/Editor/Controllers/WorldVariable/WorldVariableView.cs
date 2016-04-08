using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators;
using NathanAlden.TextAdventure.Editor.Controllers.WorldVariables;
using NathanAlden.TextAdventure.Editor.PairMappers;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariable
{
    public partial class WorldVariableView : FormView, IWorldVariableView
    {
        private readonly Subject<FormClosingEventArgs> _viewClosing = new Subject<FormClosingEventArgs>();
        private WorldVariableViewModel _viewModel;

        public WorldVariableView()
        {
            InitializeComponent();

            bindingComboBoxType.DataSource = WorldVariableTypePairMapper.Instance.ToList();
            bindingComboBoxType.ValueMember = nameof(Tuple<WorldVariableType, string>.Item1);
            bindingComboBoxType.DisplayMember = nameof(Tuple<WorldVariableType, string>.Item2);
        }

        public IObservable<FormClosingEventArgs> ViewClosing => _viewClosing.AsObservable();

        public DialogResult ShowView(IWin32Window owner, WorldVariableViewModel viewModel, EditMode editMode)
        {
            owner.ThrowIfNull(nameof(owner));
            _viewModel = viewModel.EnsureNotNull(nameof(viewModel));

            Text = $"{(editMode == EditMode.New ? "New" : "Edit")} Variable";

            return ShowDialog(owner);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bindingSource.DataSource = _viewModel;

            ViewModelValidator.AttachControlDecoratorsRecursive<WorldVariableViewModel, TextBox, TextBoxDecorator>(_viewModel, this);
            ViewModelValidator.AttachToolTipRecursive<WorldVariableViewModel, TextBox>(_viewModel, this, toolTip);
            ViewModelValidator.AttachToolTip(_viewModel, pictureBoxValidationError, toolTip);

            _viewModel.Validate();

            ActiveControl = promptTextBoxName;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _viewClosing.OnNext(e);

            base.OnFormClosing(e);
        }

        private void promptTextBoxName_Leave(object sender, EventArgs e)
        {
            promptTextBoxName.Text = _viewModel.Name;
        }

        private void promptTextBoxCategory_Leave(object sender, EventArgs e)
        {
            promptTextBoxCategory.Text = _viewModel.Category;
        }
    }
}