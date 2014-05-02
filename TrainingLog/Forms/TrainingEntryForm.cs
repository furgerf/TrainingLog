using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class TrainingEntryForm : Form
    {
        public static TrainingEntryForm GetInstance
        {
            get { return _instance ?? (_instance = new TrainingEntryForm()); }
        }

        private static TrainingEntryForm _instance;

        public TrainingEntryForm()
        {
            InitializeComponent();

            // fill combobox list
            foreach (var foo in Enum.GetNames(typeof (Utils.Sport)))
                if (foo.Equals("Count"))
                    break;
                else
                    comSport.Items.Add(foo);
            comSport.Text = Enum.GetNames(typeof (Utils.Sport))[0];

            // fill date
            txtDate.Text = DateTime.Today.ToShortDateString();

            // add event handles
            txtDuration.TextChanged += DurationChanged;
            txtZone1.TextChanged += DurationChanged;
            txtZone2.TextChanged += DurationChanged;
            txtZone3.TextChanged += DurationChanged;
            txtZone4.TextChanged += DurationChanged;
            txtZone5.TextChanged += DurationChanged;
        }

        private void TrainingEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void ButOkClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButCancelClick(object sender, EventArgs e)
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
            comTrainingType.Items.Clear();

            var count = -1;
            var type = GetType();
            switch ((Utils.Sport) comSport.SelectedIndex)
            {
                case Utils.Sport.Running:
                case Utils.Sport.Biking:
                    count = (int) Utils.EnduranceType.Count;
                    type = typeof (Utils.EnduranceType);
                    break;
                case Utils.Sport.Squash:
                    count = (int) Utils.SquashType.Count;
                    type = typeof (Utils.SquashType);
                    break;
            }

            for (var i = 0; i < count; i++)
                comTrainingType.Items.Add(Enum.GetName(type, i));
            if (count > 0)
                comTrainingType.SelectedIndex = 0;

            // en-/disable distance
            grpDistance.Enabled = comSport.SelectedIndex == (int) Utils.Sport.Running ||
                                  comSport.SelectedIndex == (int) Utils.Sport.Biking;
        }

        private void DistanceTimeChanged(object sender, EventArgs e)
        {
            if (txtDistance.Text == "" || txtDuration.Text == "")
                return;

            var split = txtDuration.Text.Split(':');
            TimeSpan ts;
            try
            {
                if (split.Length == 2)
                    ts = new TimeSpan(0, int.Parse(split[0]), int.Parse(split[1]));
                else if (split.Length == 3)
                    ts = new TimeSpan(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                else
                    return;
            }
            catch (FormatException)
            {
                return;
            }

            var pace = Math.Round(ts.TotalMinutes/int.Parse(txtDistance.Text)*1000, 2);
            var speed = Math.Round(int.Parse(txtDistance.Text)/ts.TotalHours/1000, 2);

            // recalculate pace
            labPace.Text = "Pace:   " + pace + " min/km";

            // recalculate speed
            labSpeed.Text = "Speed: " + speed + " km/h";
        }

        private void DurationChanged(object sender, EventArgs e)
        {
            var valid = true;
            var txt = (TextBox) sender;
            var split = txt.Text.Split(':');
            int foo;

            switch (split.Length)
            {
                case 2:
                    if (!int.TryParse(split[0], out foo))
                        valid = false;
                    if (foo >= 60 || foo < 0)
                        valid = false;
                    if (!int.TryParse(split[1], out foo))
                        valid = false;
                    if (foo >= 60 || foo < 0)
                        valid = false;
                    if (split[0] == "0" && split[1] == "0")
                        valid = false;
                    break;
                case 3:
                    if (!int.TryParse(split[0], out foo))
                        valid = false;
                    if (foo >= 24 || foo < 0)
                        valid = false;
                    if (!int.TryParse(split[1], out foo))
                        valid = false;
                    if (foo >= 60 || foo < 0)
                        valid = false;
                    if (!int.TryParse(split[2], out foo))
                        valid = false;
                    if (foo >= 60 || foo < 0)
                        valid = false;
                    if (split[0] == "0" && split[1] == "0" && split[2] == "0")
                        valid = false;
                    break;
                default:
                    valid = false;
                    break;
            }

            txt.BackColor = valid ? Color.White : Color.Red;
        }
    }
}
