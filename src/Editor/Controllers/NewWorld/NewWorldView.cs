using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation;
using NathanAlden.TextAdventure.Common.WindowsForms.Validation.Decorators;

namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    public partial class NewWorldView : FormView, INewWorldView
    {
        private NewWorldViewModel _viewModel;

        public NewWorldView()
        {
            InitializeComponent();
        }

        public IObservable<EventPattern<object>> GenerateId => Observable.FromEventPattern(x => buttonGenerateId.Click += x, x => buttonGenerateId.Click -= x);

        public DialogResult ShowView(IWin32Window owner, NewWorldViewModel viewModel)
        {
            owner.ThrowIfNull(nameof(owner));
            viewModel.ThrowIfNull(nameof(viewModel));

            _viewModel = viewModel;

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
    }
}