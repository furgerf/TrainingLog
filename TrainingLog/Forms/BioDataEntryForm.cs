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
            for (var i = Utils.Index.Count - 1; i >= 0; i--)
                comSleepQuality.Items.Add(Enum.GetName(typeof (Utils.Index), i));
            comSleepQuality.SelectedIndex = (int)Utils.Index.Okay;

            comFeeling.Items.Add("");
            for (var i = Utils.Index.Count - 1; i >= 0; i--)
                comFeeling.Items.Add(Enum.GetName(typeof (Utils.Index), i));
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
            File.AppendAllText(Utils.DataFilePath,
                               new BioDataEntry
                                   {
                                       DateTime = DateTime.Today,
                                       SleepDuration = new TimeSpan(0, (int) (60*numSleepDuration.Value), 0),
                                       SleepQuality = (Utils.Index) comSleepQuality.SelectedIndex,
                                       RestingHeartRate = (int) numRestingHeartRate.Value,
                                       Weight = (int) numWeight.Value,
                                       Nibbles = txtNibbles.Text,
                                       Feeling =
                                           comFeeling.Text != ""
                                               ? (Utils.Index) comFeeling.SelectedIndex
                                               : Utils.Index.None,
                                       Note = txtNotes.Text
                                   }.LogString + '\n');

            Close();
        }

        private void ButCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void NumSleepDurationEnter(object sender, EventArgs e)
        {
            numSleepDuration.Select(0, numSleepDuration.Text.Length);
        }

        private void NumRestingHeartRateEnter(object sender, EventArgs e)
        {
            numRestingHeartRate.Select(0, numRestingHeartRate.Text.Length);
        }

        private void NumWeightEnter(object sender, EventArgs e)
        {
            numWeight.Select(0, numWeight.Text.Length);
        }
    }
}
