using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    public partial class WorldVariablesView : FormView, IWorldVariablesView
    {
        public WorldVariablesView()
        {
            InitializeComponent();
        }

        IObservable<EventPattern<KeyEventArgs>> IWorldVariablesView.KeyDown => Observable.FromEventPattern<KeyEventHandler, KeyEventArgs>(x => KeyDown += x, x => KeyDown -= x);
        public IEnumerable<int> VariablesListColumnWidths => listViewVariables.Columns.Cast<ColumnHeader>().Select(x => x.Width);

        public void ShowView(IWin32Window owner)
        {
            ShowDialog(owner);
        }

        public void CloseView()
        {
            Close();
        }

        public void ViewAllCategories()
        {
            comboBoxCategories.SelectedIndex = 0;
        }

        public void RestoreVariablesListColumnWidths(IEnumerable<int> columnWidths)
        {
            RestoreColumnWidths(columnWidths, listViewVariables);
        }

        private void listViewVariables_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTestInfo = listViewVariables.HitTest(e.Location);

            if (hitTestInfo.Item != null)
            {
                return;
            }

            listViewVariables.SelectedItems.Clear();
            if (hitTestInfo.Item != null)
            {
                hitTestInfo.Item.Selected = true;
            }
        }
    }
}