using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TabularDBMS
{
    public partial class ReorderColumnsForm : Form
    {
        public List<string> NewOrder { get; private set; }

        public ReorderColumnsForm(List<string> currentOrder)
        {
            InitializeComponent();
            listBoxColumns.Items.AddRange(currentOrder.ToArray());
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(-1);
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(1);
        }

        private void MoveSelectedItem(int direction)
        {
            if (listBoxColumns.SelectedItem == null)
                return;

            int newIndex = listBoxColumns.SelectedIndex + direction;

            if (newIndex < 0 || newIndex >= listBoxColumns.Items.Count)
                return;

            object selected = listBoxColumns.SelectedItem;
            listBoxColumns.Items.Remove(selected);
            listBoxColumns.Items.Insert(newIndex, selected);
            listBoxColumns.SelectedIndex = newIndex;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            NewOrder = new List<string>();
            foreach (var item in listBoxColumns.Items)
            {
                NewOrder.Add(item.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
