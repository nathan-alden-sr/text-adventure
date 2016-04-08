using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators;

namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    public partial class NewWorldView : FormView, INewWorldView
    {
        private readonly Subject<Unit> _idGenerationRequested = new Subject<Unit>();
        private NewWorldViewModel _viewModel;

        public NewWorldView()
        {
            InitializeComponent();
        }

        public IObservable<Unit> IdGenerationRequested => _idGenerationRequested.AsObservable();

        public DialogResult ShowView(IWin32Window owner, NewWorldViewModel viewModel)
        {
            owner.ThrowIfNull(nameof(owner));
            _viewModel = viewModel.EnsureNotNull(nameof(viewModel));

            return ShowDialog(owner);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            bindingSource.DataSource = _viewModel;

            ViewModelValidator.AttachControlDecoratorsRecursive<NewWorldViewModel, TextBox, TextBoxDecorator>(_viewModel, this);
            ViewModelValidator.AttachToolTipRecursive<NewWorldViewModel, TextBox>(_viewModel, this, toolTip);
            ViewModelValidator.AttachToolTip(_viewModel, pictureBoxValidationError, toolTip);

            _viewModel.Validate();

            ActiveControl = promptTextBoxWorldName;
        }

        private void buttonGenerateId_Click(object sender, EventArgs e)
        {
            _idGenerationRequested.OnNext(Unit.Default);
        }

        private void promptTextBoxId_Leave(object sender, EventArgs e)
        {
            promptTextBoxId.Text = _viewModel.Id;
        }

        private void promptTextBoxWorldName_Leave(object sender, EventArgs e)
        {
            promptTextBoxWorldName.Text = _viewModel.WorldName;
        }

        private void promptTextBoxAuthor_Leave(object sender, EventArgs e)
        {
            promptTextBoxAuthor.Text = _viewModel.Author;
        }

        private void promptTextBoxVersion_Leave(object sender, EventArgs e)
        {
            promptTextBoxVersion.Text = _viewModel.Version;
        }
    }
}