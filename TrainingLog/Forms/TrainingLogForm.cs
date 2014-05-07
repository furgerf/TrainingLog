using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class TrainingLogForm : Form
    {
        private readonly EntryListControl _elcTraining = new EntryListControl { EntryName = "Training", Columns = TrainingHeader };
        private readonly EntryListControl _elcBiodata = new EntryListControl { EntryName = "Bio Data", Columns = BiodataHeader };
        private readonly EntryListControl _elcRace = new EntryListControl { EntryName = "Race", Columns = RaceHeader };
        private readonly EntryListControl _elcUnified = new EntryListControl { EntryName = "All", Columns = UnifiedHeader };

        private readonly static string[] TrainingHeader = new[]
                           {
                               "Date", "Sport", "Duration", "Calories", "Avg. HR", "Zone Data", "Distance", "Feeling", "Notes"
                           };
        private readonly static string[] BiodataHeader = new[]
                           {
                               "Date", "Sleep", "Resting HR", "OwnIndex", "Weight", "Feeling", "Nibbles", "Notes"
                           };
        private readonly static string[] RaceHeader = new[]
                           {
                               "Date"
                           };
        private readonly static string[] UnifiedHeader = new[]
                           {
                               "Date"
                           };

        private Size ScreenSize
        {
            get { return WindowState == FormWindowState.Maximized ? Screen.PrimaryScreen.WorkingArea.Size : ClientSize; }
        }

        private int TopY { get { return grpMain.Location.Y + grpMain.Height + 4; } }

        private int LeftX { get { return grpMain.Location.X; } }

        public static TrainingLogForm GetInstance
        {
            get { return _instance ?? (_instance = new TrainingLogForm()); }
        }

        private static TrainingLogForm _instance;

        public TrainingLogForm()
        {
            InitializeComponent();

            Controls.AddRange(new Control[]{ _elcTraining, _elcBiodata, _elcRace, _elcUnified });
            
            EntrySelectionChanged(null, null);

            foreach (var entry in Model.Instance.TrainingEntries.Where(entry => !_elcTraining.AddEntry(new[]{
                entry.DateTime.ToShortDateString(),
                entry.Sport + (entry.HasTrainingType ? "" : " (" + entry.TrainingType + ")"),
                entry.Duration.ToString(),
                entry.Calories == 0 ? "" : entry.Calories.ToString(),
                entry.AverageHr == 0 ? "" : entry.AverageHr.ToString(),
                "<img>",
                entry.DistanceKm > 0 ? entry.DistanceKm + " km" : "",
                entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), entry.Feeling),
                entry.Note 
                                                                                                           })))
                    MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            foreach (var entry in Model.Instance.BioDataEntries.Where(entry => !_elcBiodata.AddEntry(new[]{
                entry.DateTime.ToShortDateString(),
                entry.SleepDuration + " (" + Enum.GetName(typeof (Common.Index), entry.SleepQuality) + ")",
                entry.RestingHeartRate == 0 ? "" : entry.RestingHeartRate.ToString(),
                entry.OwnIndex == 0 ? "" : entry.OwnIndex.ToString(),
                entry.Weight == 0 ? "" : entry.Weight.ToString(),
                entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), entry.Feeling),
                entry.Nibbles,
                entry.Note 
                                                                                                            })))
                    MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TrainingLogFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void TrainingLogFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void EntrySelectionChanged(object sender, EventArgs e)
        {
            if (chkUnified.Checked)
            {
                _elcUnified.Visible = true;
                _elcTraining.Visible = false;
                _elcBiodata.Visible = false;
                _elcRace.Visible = false;

                PlaceOneEntryList(_elcUnified);
                return;
            }

            _elcUnified.Visible = false;

            var visible = new List<EntryListControl>();
            var invisible = new List<EntryListControl>();


            (chkTraining.Checked ? visible : invisible).Add(_elcTraining);
            (chkBiodata.Checked ? visible : invisible).Add(_elcBiodata);
            (chkRace.Checked ? visible : invisible).Add(_elcRace);

            foreach (var c in visible)
                c.Visible = true;

            foreach (var c in invisible)
                c.Visible = false;

            switch (visible.Count)
            {
                case 0:
                    return;
                case 1:
                    PlaceOneEntryList(visible[0]);
                    return;
                case 2:
                    PlaceTwoEntryLists(visible[0], visible[1]);
                    return;
                case 3:
                    PlaceThreeEntryLists(visible[0], visible[1], visible[2]);
                    return;
            }
            throw new Exception();
        }

        private void PlaceThreeEntryLists(Control elc1, Control elc2, Control elc3)
        {
            elc1.Location = new Point(LeftX, TopY);
            var height = (ScreenSize.Height - elc1.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14) - 12) / 3;
            var width = ScreenSize.Width - 2 * elc1.Location.X;

            elc1.Size = new Size(width, height);

            elc2.Location = new Point(elc1.Location.X, elc1.Location.Y + height + 6);
            elc2.Size = new Size(width, height);

            elc3.Location = new Point(elc2.Location.X, elc2.Location.Y + height + 6);
            elc3.Size = new Size(width, height);
        }

        private void PlaceTwoEntryLists(Control elc1, Control elc2)
        {
            elc1.Location = new Point(LeftX, TopY);
            var height = (ScreenSize.Height - elc1.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14) - 6) / 2;
            var width = ScreenSize.Width - 2*elc1.Location.X;

            elc1.Size = new Size(width, height);

            elc2.Location = new Point(elc1.Location.X, elc1.Location.Y + height + 6);
            elc2.Size = new Size(width, height);
        }

        private void PlaceOneEntryList(Control elc)
        {
            elc.Location = new Point(LeftX, TopY);
            elc.Size = new Size(ScreenSize.Width - 2 * elc.Location.X, ScreenSize.Height - elc.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14));
        }

        private void ButCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TrainingLogFormSizeChanged(object sender, EventArgs e)
        {
            EntrySelectionChanged(null, null);
        }
    }
}
