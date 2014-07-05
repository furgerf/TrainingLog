using System;
using System.Drawing;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class BiodataEntryForm : Form
    {
        #region Fields

        public static BiodataEntryForm Instance
        {
            get { return _instance ?? (_instance = new BiodataEntryForm()); }
        }

        public BiodataEntry NewEntry { get; private set; }

        private static BiodataEntryForm _instance;

        private DateTime _dateOverride = DateTime.MinValue;

        private readonly Size _formSize;

        #endregion

        #region Constructor

        public BiodataEntryForm(BiodataEntry entry)
            : this()
        {
            if (entry.DateSpecified)
                _dateOverride = entry.Date ?? DateTime.MinValue;
            if (entry.FeelingSpecified)
                comFeeling.Text = Enum.GetName(typeof (Common.Index), entry.Feeling ?? Common.Index.Count);
            if (entry.NigglesSpecified)
                comNiggles.Text = entry.Niggles;
            if (entry.NoteSpecified)
                comNotes.Text = entry.Note;
            if (entry.OwnIndexSpecified)
                numOwnIndex.Value = entry.OwnIndex ?? decimal.MinValue;
            if (entry.RestingHeartRateSpecified)
                numRestingHeartRate.Value = entry.RestingHeartRate ?? decimal.MinValue;
            if (entry.SleepDurationStringSpecified)
                numSleepDuration.Value = (decimal) (entry.SleepDuration ?? TimeSpan.MaxValue).TotalHours;
            if (entry.SleepQualitySpecified)
                comSleepQuality.Text = Enum.GetName(typeof (Common.Index), entry.SleepQuality ?? Common.Index.Count);
            if (entry.WeightSpecified)
                numWeight.Value = entry.Weight ?? decimal.MinValue;
        }

        private BiodataEntryForm()
        {
            InitializeComponent();

            // fill combobox lists
            foreach (var e in Model.Instance.BiodataEntries)
            {
                if (e.NoteSpecified && !comNotes.Items.Contains(e.Note))
                    comNotes.Items.Add(e.Note);
                if (e.NigglesSpecified && !comNiggles.Items.Contains(e.Niggles))
                    comNiggles.Items.Add(e.Niggles);
            }
            comNiggles.Sorted = true;
            comNotes.Sorted = true;

            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comSleepQuality.Items.Add(Enum.GetName(typeof (Common.Index), i) ?? "ENUM NAME NOT FOUND");
            comSleepQuality.SelectedIndex = (int)Common.Index.Okay;

            comFeeling.Items.Add("");
            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comFeeling.Items.Add(Enum.GetName(typeof(Common.Index), i) ?? "ENUM NAME NOT FOUND");

            _formSize = Size;
        }

        #endregion

        #region Main Methods

        private void ResetForm()
        {
            numSleepDuration.Value = 8;
            comSleepQuality.SelectedIndex = (int)Common.Index.Okay;
            numRestingHeartRate.Value = 0;
            numOwnIndex.Value = 0;
            numWeight.Value = 0;
            comFeeling.SelectedIndex = 0;
            comNiggles.Text = "";
            comNotes.Text = "";
        }

        #endregion

        #region Event Handling

        private void BioDataEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.Instance.Show();
            MainForm.Instance.BringToFront();

            e.Cancel = !MainForm.Instance.CloseForms;
        }

        private void ButOkClick(object sender, EventArgs e)
        {
            var entry = new BiodataEntry
                            {
                                Date = _dateOverride.Equals(DateTime.MinValue) ? DateTime.Today : _dateOverride,
                                SleepDuration = new TimeSpan(0, (int) (60*numSleepDuration.Value), 0),
                                SleepQuality = (Common.Index) (int) Common.Index.Count - comSleepQuality.SelectedIndex - 1,
                                RestingHeartRate = (int) numRestingHeartRate.Value,
                                OwnIndex = (int) numOwnIndex.Value,
                                Weight = numWeight.Value,
                                Niggles = comNiggles.Text,
                                Feeling =
                                    comFeeling.Text != ""
                                        ? (Common.Index) (int) Common.Index.Count - comFeeling.SelectedIndex
                                        : Common.Index.None,
                                Note = comNotes.Text
                            };

            NewEntry = entry;

            Model.Instance.AddEntry(entry);

            ResetForm();
            Close();
        }

        private void ButCancelClick(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private void NumericEnter(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void BioDataEntryFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void BiodataEntryFormResize(object sender, EventArgs e)
        {
            Size = _formSize;
        }

        private void BiodataEntryFormResizeBegin(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
