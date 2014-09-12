using System;
using System.Linq;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class EquipmentForm : Form
    {
        public static EquipmentForm Instance
        {
            get { return _instance ?? (_instance = new EquipmentForm()); }
        }

        private static EquipmentForm _instance;

        public EquipmentForm()
        {
            InitializeComponent();

            foreach (var e in Model.Instance.Equipment)
                AddEntry(e);
        }

        private void AddEntry(Equipment entry)
        {
            lisEntries.Items.Add(new ListViewItem(new[] { entry.Name, entry.ImageName, entry.Sport.ToString() }));
        }

        private static Equipment FindEntry(ListViewItem item)
        {
            var entries =
                Model.Instance.Equipment.Where(e =>
                    (item.SubItems[0].Text == e.Name) &&
                    (item.SubItems[1].Text == e.ImageName) &&
                    (item.SubItems[2].Text == e.Sport.ToString())).ToArray();

            if (entries.Count() != 1)
                throw new Exception("should find exactly one entry");

            return entries[0];
        }

        private void ShowNewEntryDialog(Equipment equipment = null)
        {
            var form = equipment == null ? new NewEquipmentForm() : new NewEquipmentForm(equipment);
            form.FormClosing += (ss, ee) =>
            {
                if (form.Equipment == null) return;
                AddEntry(form.Equipment);
                Model.Instance.AddEntry(form.Equipment);
            };

            form.Show();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            ShowNewEntryDialog();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (lisEntries.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select only one entry to edit.", "Too many selections", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
                return;
            }

            var item = lisEntries.SelectedItems[0];
            var entry = FindEntry(item);

            // delete old entry
            Model.Instance.RemoveEntry(entry);
            lisEntries.Items.Remove(item);

            // add new (edited) entry
            ShowNewEntryDialog(entry);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (lisEntries.SelectedItems.Count == 0)
                return;

            if (MessageBox.Show("Are you sure you want to delete " + lisEntries.SelectedItems.Count + (lisEntries.SelectedItems.Count > 1 ? " entries?" : " entry?"),
                                "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            while (lisEntries.SelectedItems.Count > 0)
            {
                Model.Instance.RemoveEntry(FindEntry(lisEntries.SelectedItems[0]));
                lisEntries.Items.Remove(lisEntries.SelectedItems[0]);
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EquipmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.Instance.Show();
            MainForm.Instance.BringToFront();

            e.Cancel = !MainForm.Instance.CloseForms;
        }

        private void EquipmentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
