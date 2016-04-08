using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.WindowsForms.DataBinding;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public partial class WorldVariablesView : FormView, IWorldVariablesView
    {
        private readonly Subject<IEnumerable<WorldVariableViewModel>> _deleteRequested = new Subject<IEnumerable<WorldVariableViewModel>>();
        private readonly Subject<WorldVariableViewModel> _editRequested = new Subject<WorldVariableViewModel>();
        private readonly Subject<Unit> _newRequested = new Subject<Unit>();
        private SortableBindingList<CategoryFilterViewModel> _categoryFilterViewModels;
        private SortableBindingList<WorldVariableViewModel> _filteredWorldVariableViewModels;
        private List<WorldVariableViewModel> _worldVariableViewModels;

        public WorldVariablesView()
        {
            InitializeComponent();

            dataGridViewVariables.AutoGenerateColumns = false;
            dataGridViewVariables.DataSource = bindingSourceVariables;
        }

        public IObservable<Unit> NewRequested => _newRequested.AsObservable();
        public IObservable<WorldVariableViewModel> EditRequested => _editRequested.AsObservable();
        public IObservable<IEnumerable<WorldVariableViewModel>> DeleteRequested => _deleteRequested.AsObservable();
        public string CategoryFilter => (string)comboBoxCategories.SelectedValue;
        public IEnumerable<WorldVariableViewModel> Variables => _worldVariableViewModels.ToArray();
        public IEnumerable<WorldVariableViewModel> SelectedVariables => dataGridViewVariables.SelectedRows.Cast<DataGridViewRow>().Select(x => (WorldVariableViewModel)x.DataBoundItem).ToArray();
        public IEnumerable<int> VariablesListColumnWidths => dataGridViewVariables.Columns.Cast<DataGridViewColumn>().Select(x => x.Width).ToArray();

        public DialogResult ShowView(IWin32Window owner, IEnumerable<WorldVariableViewModel> worldVariableViewModels)
        {
            owner.ThrowIfNull(nameof(owner));

            _worldVariableViewModels = new List<WorldVariableViewModel>(worldVariableViewModels ?? Enumerable.Empty<WorldVariableViewModel>());
            bindingSourceVariables.DataSource = _worldVariableViewModels;
            RefreshFilter(true);

            return ShowDialog(owner);
        }

        public void CloseView()
        {
            Close();
        }

        public void AddVariable(WorldVariableViewModel viewModel)
        {
            viewModel.ThrowIfNull(nameof(viewModel));

            _worldVariableViewModels.Add(viewModel);

            RefreshFilter(true);
        }

        public void ReplaceVariable(WorldVariableViewModel currentViewModel, WorldVariableViewModel editedViewModel)
        {
            currentViewModel.ThrowIfNull(nameof(currentViewModel));
            editedViewModel.ThrowIfNull(nameof(editedViewModel));

            _worldVariableViewModels.Remove(currentViewModel);
            _worldVariableViewModels.Add(editedViewModel);

            RefreshFilter(true);
        }

        public void DeleteSelectedVariables()
        {
            bindingSourceVariables.SuspendBinding();

            foreach (WorldVariableViewModel viewModel in SelectedVariables)
            {
                _worldVariableViewModels.Remove(viewModel);
                _filteredWorldVariableViewModels.Remove(viewModel);
            }

            RefreshFilter(false);

            bindingSourceVariables.ResumeBinding();
        }

        public void RestoreVariablesListColumnWidths(IEnumerable<int> columnWidths)
        {
            RestoreColumnWidths(columnWidths, dataGridViewVariables);
        }

        private void RefreshVariables()
        {
            _filteredWorldVariableViewModels = new SortableBindingList<WorldVariableViewModel>(
                _worldVariableViewModels.Where(
                    x =>
                    {
                        var categoryFilterViewModel = (CategoryFilterViewModel)comboBoxCategories.SelectedItem;

                        switch (categoryFilterViewModel.Type)
                        {
                            case CategoryFilterType.All:
                                return true;
                            case CategoryFilterType.Blank:
                                return x.Category == null;
                            case CategoryFilterType.Named:
                                return string.Equals(x.Category, categoryFilterViewModel.Category, StringComparison.OrdinalIgnoreCase);
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }));

            bindingSourceVariables.DataSource = _filteredWorldVariableViewModels;
            dataGridViewVariables.ClearSelection();
        }

        private void RefreshFilter(bool forceVariablesRefresh)
        {
            var categoryFilterViewModels = new List<CategoryFilterViewModel> { new CategoryFilterViewModel("(All Categories)", null, CategoryFilterType.All) };
            string[] categories = _worldVariableViewModels.Select(x => x.Category).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();

            if (categories.Contains(null))
            {
                categoryFilterViewModels.Add(new CategoryFilterViewModel("(Blank Categories)", null, CategoryFilterType.Blank));
            }
            categoryFilterViewModels.AddRange(categories.Where(x => x != null).Select(x => new CategoryFilterViewModel(x, x, CategoryFilterType.Named)));
            _categoryFilterViewModels = new SortableBindingList<CategoryFilterViewModel>(categoryFilterViewModels);
            bindingSourceFilter.DataSource = _categoryFilterViewModels;

            if (forceVariablesRefresh || bindingSourceVariables.Count == 0)
            {
                RefreshVariables();
            }
        }

        private void dataGridViewVariables_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = dataGridViewVariables.HitTest(e.X, e.Y);

            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            switch (hitTestInfo.Type)
            {
                case DataGridViewHitTestType.Cell:
                    if (!dataGridViewVariables.Rows[hitTestInfo.RowIndex].Selected)
                    {
                        dataGridViewVariables.ClearSelection();
                        dataGridViewVariables.Rows[hitTestInfo.RowIndex].Selected = true;
                    }
                    break;
                default:
                    dataGridViewVariables.ClearSelection();
                    break;
            }

            toolStripMenuItemEdit.Enabled = dataGridViewVariables.SelectedRows.Count == 1;
            toolStripMenuItemDelete.Enabled = dataGridViewVariables.SelectedRows.Count > 0;
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshVariables();
        }

        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            _newRequested.OnNext(Unit.Default);
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            _editRequested.OnNext(SelectedVariables.Single());
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            _deleteRequested.OnNext(SelectedVariables);
        }

        private void dataGridViewVariables_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    if (e.Control)
                    {
                        _newRequested.OnNext(Unit.Default);
                    }
                    break;
                case Keys.Delete:
                    _deleteRequested.OnNext(SelectedVariables);
                    break;
                case Keys.Enter:
                    _editRequested.OnNext(SelectedVariables.Single());
                    break;
            }
        }

        private void dataGridViewVariables_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _editRequested.OnNext(_filteredWorldVariableViewModels[e.RowIndex]);
        }
    }
}