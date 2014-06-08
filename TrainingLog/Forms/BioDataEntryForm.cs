using System;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class BiodataEntryForm : Form
    {
        #region Fields

        public static BiodataEntryForm GetInstance
        {
            get { return _instance ?? (_instance = new BiodataEntryForm()); }
        }

        public BiodataEntry NewEntry { get; private set; }

        private static BiodataEntryForm _instance;

        private DateTime _dateOverride = DateTime.MinValue;

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
                txtNiggles.Text = entry.Niggles;
            if (entry.NoteSpecified)
                txtNotes.Text = entry.Note;
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

        public BiodataEntryForm()
        {
            InitializeComponent();

            // fill combobox lists
            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comSleepQuality.Items.Add(Enum.GetName(typeof (Common.Index), i));
            comSleepQuality.SelectedIndex = (int)Common.Index.Okay;

            comFeeling.Items.Add("");
            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comFeeling.Items.Add(Enum.GetName(typeof (Common.Index), i));
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
            txtNiggles.Text = "";
            txtNotes.Text = "";
        }

        #endregion

        #region Event Handling

        private void BioDataEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
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
                                Niggles = txtNiggles.Text,
                                Feeling =
                                    comFeeling.Text != ""
                                        ? (Common.Index) (int) Common.Index.Count - comFeeling.SelectedIndex
                                        : Common.Index.None,
                                Note = txtNotes.Text
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

        #endregion
    }
}
