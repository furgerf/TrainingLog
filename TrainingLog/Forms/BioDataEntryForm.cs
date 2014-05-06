using System;
using System.IO;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class BioDataEntryForm : Form
    {
        public static BioDataEntryForm GetInstance
        {
            get { return _instance ?? (_instance = new BioDataEntryForm()); }
        }

        private static BioDataEntryForm _instance;

        public BioDataEntryForm()
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

        private void ResetForm()
        {
            numSleepDuration.Value = 8;
            comSleepQuality.SelectedIndex = (int)Common.Index.Okay;
            numRestingHeartRate.Value = 0;
            numOwnIndex.Value = 0;
            numWeight.Value = 0;
            comFeeling.SelectedIndex = 0;
            txtNibbles.Text = "";
            txtNotes.Text = "";
        }

        private void BioDataEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void ButOkClick(object sender, EventArgs e)
        {
            var entry = new BioDataEntry
                            {
                                DateTime = DateTime.Today,
                                SleepDuration = new TimeSpan(0, (int) (60*numSleepDuration.Value), 0),
                                SleepQuality = (Common.Index) (int) Common.Index.Count - comSleepQuality.SelectedIndex - 1,
                                RestingHeartRate = (int) numRestingHeartRate.Value,
                                Weight = (int) numWeight.Value,
                                Nibbles = txtNibbles.Text,
                                Feeling =
                                    comFeeling.Text != ""
                                        ? (Common.Index) (int) Common.Index.Count - comFeeling.SelectedIndex
                                        : Common.Index.None,
                                Note = txtNotes.Text
                            };

            File.AppendAllText(Common.DataFilePath, entry.LogString + '\n');

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
    }
}
