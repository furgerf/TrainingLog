using System;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class NonSportEntryForm : Form
    {
        #region Fields

        public static NonSportEntryForm Instance
        {
            get { return _instance ?? (_instance = new NonSportEntryForm()); }
        }

        private static NonSportEntryForm _instance;

        #endregion

        #region Constructor

        private NonSportEntryForm()
        {
            InitializeComponent();

            foreach (var e in Model.Instance.NonSportEntries)
                AddEntry(e);
        }

        #endregion

        #region Methods

        private void AddEntry(NonSportEntry entry)
        {
            if (entry.DrawColor == null || entry.Date == null)
                throw new Exception();

            var index = 0;
            for (var i = 0; i < lisEntries.Items.Count; i++)
                if (DateTime.Parse(lisEntries.Items[i].SubItems[2].Text) > entry.Date.Value)
                {
                    index = i;
                    break;
                }

                lisEntries.Items.Insert(index, new ListViewItem(new[] { entry.Note ?? "ERROR: NOTE NOT SET", entry.DrawColor.Value.Name, entry.Date.Value.ToShortDateString(), entry.GetEndDate.ToShortDateString() }) { BackColor = entry.DrawColor.Value });
        }

        #endregion

        #region Event Handling

        private void NonSportEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.Instance.Show();
            MainForm.Instance.BringToFront();

            e.Cancel = !MainForm.Instance.CloseForms;
        }

        private void NonSportEntryFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private static NonSportEntry FindEntry(ListViewItem item)
        {
            var entries =
                Model.Instance.NonSportEntries.Where(e =>
                    (item.SubItems[0].Text == e.Note) && 
                    (item.SubItems[1].Text == e.DrawColor.Value.Name) &&
                    (DateTime.Parse(item.SubItems[2].Text) == e.Date) &&
                    (item.SubItems[3].Text == ""
                        ? e.EndDate.Value == e.Date
                        : item.SubItems[3].Text == e.GetEndDate.ToShortDateString())).ToArray();
            
            if (entries.Count() != 1)
                throw new Exception("should find exactly one entry");

            return entries[0];
        }

        private void ShowNewEntryDialog(NonSportEntry entry = null)
        {
            var form = entry == null ? new NewNonSportEntryForm() : new NewNonSportEntryForm(entry);
            form.FormClosing += (ss, ee) =>
            {
                if (form.Entry == null) return;
                AddEntry(form.Entry);
                Model.Instance.AddEntry(form.Entry);
            };
            form.Show();
        }

        private void ButAddClick(object sender, EventArgs e)
        {
            ShowNewEntryDialog();
        }

        private void ButEditClick(object sender, EventArgs e)
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

        private void ButDeleteClick(object sender, EventArgs e)
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

        private void ButExitClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
