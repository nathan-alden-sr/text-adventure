using System;
using System.Windows.Forms;

namespace NathanAlden.TextAdventure.Common.WindowsForms.Controls
{
    public class BindingComboBox : ComboBox
    {
        public event EventHandler SelectedItemChanged
        {
            add { SelectedIndexChanged += value; }
            remove { SelectedIndexChanged -= value; }
        }
    }
}