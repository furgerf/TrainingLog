using System;
using System.Data;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class TrainingEntryForm : Form
    {
        public static TrainingEntryForm GetInstance { 
            get { return _instance ?? (_instance = new TrainingEntryForm()); }
        }

        private static TrainingEntryForm _instance;

        public TrainingEntryForm()
        {
            InitializeComponent();

            // fill combobox list
            foreach (var foo in Enum.GetNames(typeof(Utils.Sport)))
                if (foo.Equals("Count"))
                    break;
                else
                    comSport.Items.Add(foo);
            comSport.Text = Enum.GetNames(typeof (Utils.Sport))[0];
        }

        private void TrainingEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void ButOkClick(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButCancelClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void NumericTextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ChkSweatDataCheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComSportSelectedIndexChanged(object sender, EventArgs e)
        {
            // update training types

            // en-/disable distance
            grpDistance.Enabled = comSport.SelectedIndex == (int) Utils.Sport.Running ||
                                  comSport.SelectedIndex == (int) Utils.Sport.Biking;
        }

        private void DistanceTimeChanged(object sender, EventArgs e)
        {
            if (txtDistance.Text == "" || (txtDurationHours.Text == "" && txtDurationMinutes.Text == "" && txtDurationSeconds.Text == ""))
                return;

            var ts = new TimeSpan(int.Parse(txtDurationHours.Text == "" ? "0" : txtDurationHours.Text),
                                  int.Parse(txtDurationMinutes.Text == "" ? "0" : txtDurationMinutes.Text),
                                  int.Parse(txtDurationSeconds.Text == "" ? "0" : txtDurationSeconds.Text));

            var pace = Math.Round(ts.TotalMinutes/int.Parse(txtDistance.Text)*1000, 2);
            var speed = Math.Round(int.Parse(txtDistance.Text)/ts.TotalHours/1000, 2);

            // recalculate pace
            labPace.Text = "Pace:   " + pace + " min/km";

            // recalculate speed
            labSpeed.Text = "Speed: " + speed + " km/h";
        }
    }
}
