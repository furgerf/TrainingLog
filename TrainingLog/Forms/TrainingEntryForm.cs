using System;
using System.Drawing;
using System.IO;
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
            foreach (var foo in Enum.GetNames(typeof (Common.Sport)))
                if (foo.Equals("Count"))
                    break;
                else
                    comSport.Items.Add(foo);
            comSport.SelectedIndex = 0;

            comFeeling.Items.Add("");
            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comFeeling.Items.Add(Enum.GetName(typeof(Common.Index), i));

            // add event handles
            txtDuration.TextChanged += DurationChanged;
            txtZone1.TextChanged += DurationChanged;
            txtZone2.TextChanged += DurationChanged;
            txtZone3.TextChanged += DurationChanged;
            txtZone4.TextChanged += DurationChanged;
            txtZone5.TextChanged += DurationChanged;
        }

        private void ResetForm()
        {
            datDate.Text = DateTime.Today.ToShortDateString();
            comSport.SelectedIndex = 0;
            txtDuration.Text = "";
            txtDuration.BackColor = Color.White;
            txtCalories.Text = "";
            chkSweatData.Checked = false;
            txtAvgHR.Text = "";
            txtZone1.Text = "";
            txtZone1.BackColor = Color.White;
            txtZone2.Text = "";
            txtZone2.BackColor = Color.White;
            txtZone3.Text = "";
            txtZone3.BackColor = Color.White;
            txtZone4.Text = "";
            txtZone4.BackColor = Color.White;
            txtZone5.Text = "";
            txtZone5.BackColor = Color.White;
            txtDistance.Text = "";
            txtNotes.Text = "";
            comFeeling.SelectedIndex = 0;
            labPace.Text = "Pace:   ";
            labSpeed.Text = "Speed: ";
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
            TimeSpan duration;
            ZoneData zoneData;
            if (!IsDataValid(out duration, out zoneData))
                return;

            var entry = new TrainingEntry(duration)
                            {
                                DateTime = datDate.Value.Date,
                                Sport = (Common.Sport) comSport.SelectedIndex,
                                TrainingType = GetTrainingType(),
                                Calories = txtCalories.Text == "" ? 0 : int.Parse(txtCalories.Text),
                                //TODO: save sweat data
                                AverageHr = txtAvgHR.Text == "" ? 0 : int.Parse(txtAvgHR.Text),
                                ZoneTime = zoneData,
                                DistanceKm = txtDistance.Text == "" ? 0 : double.Parse(txtDistance.Text),
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

        private bool IsDataValid(out TimeSpan duration, out ZoneData zoneData)
        {
            duration = TimeSpan.Zero;
            zoneData = new ZoneData();

            // duration
            if (txtDuration.Text.Split('.').Length == 2)
                txtDuration.Text = "0." + txtDuration.Text;
            if (txtDuration.Text.Split('.').Length == 3)
            {
                if (!TimeSpan.TryParse(txtDuration.Text.Replace('.', ':'), out duration))
                {
                    MessageBox.Show("Please enter a valid duration", "Invalid Duration", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    return false;
                }
            } else {
                MessageBox.Show("Please enter a valid duration", "Invalid Duration", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }

            // distance
            if (comSport.SelectedIndex == (int) Common.Sport.Running ||
                comSport.SelectedIndex == (int) Common.Sport.Biking)
            {
                double foo;
                if (!double.TryParse(txtDistance.Text, out foo))
                {
                    MessageBox.Show("Please enter the distance", "No distance", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return false;
                }
            }

            // zone data
            if (txtZone1.Text != "" || txtZone2.Text != "" || txtZone3.Text != "" || txtZone4.Text != "" || txtZone5.Text != "")
            {
                // ensure TS format is fine
                if (txtZone1.Text.Split('.').Length == 2)
                    txtZone1.Text = "0." + txtZone1.Text;
                if (txtZone2.Text.Split('.').Length == 2)
                    txtZone2.Text = "0." + txtZone2.Text;
                if (txtZone3.Text.Split('.').Length == 2)
                    txtZone3.Text = "0." + txtZone3.Text;
                if (txtZone4.Text.Split('.').Length == 2)
                    txtZone4.Text = "0." + txtZone4.Text;
                if (txtZone5.Text.Split('.').Length == 2)
                    txtZone5.Text = "0." + txtZone5.Text;

                if (txtZone1.Text == "")
                    txtZone1.Text = "0.0.0";
                if (txtZone2.Text == "")
                    txtZone2.Text = "0.0.0";
                if (txtZone3.Text == "")
                    txtZone3.Text = "0.0.0";
                if (txtZone4.Text == "")
                    txtZone4.Text = "0.0.0";
                if (txtZone5.Text == "")
                    txtZone5.Text = "0.0.0";

                if (!ZoneData.TryParse(txtZone5.Text.Replace('.', ':') + '_' + txtZone4.Text.Replace('.', ':') + '_' + txtZone3.Text.Replace('.', ':') + '_' +
                                                     txtZone2.Text.Replace('.', ':') + '_' + txtZone1.Text.Replace('.', ':'), out
                                                                                              zoneData))
                {
                    MessageBox.Show("Please enter valid zone data", "Invalid Zone Data", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return false;
                }

                var diff = zoneData.GetDuration().CompareTo(duration) <= 0 ? zoneData.GetDuration().TotalSeconds / duration.TotalSeconds : duration.TotalSeconds / zoneData.GetDuration().TotalSeconds;
                if (diff > 1 + Common.SignificancePercentage || diff < 1 - Common.SignificancePercentage)
                {
                    MessageBox.Show("Difference between sum of zone data and duration is too big (" + Math.Round((1 - diff) * 100, 2) + "%).", "Too big difference", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return false;
                }
                MessageBox.Show("Diff: (" + Math.Round((1 - diff) * 100, 2) + "%).", "Too big difference", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
            }

            return true;
        }

        private Enum GetTrainingType()
        {
            switch ((Common.Sport)comSport.SelectedIndex)
            {
                case Common.Sport.Running:
                case Common.Sport.Biking:
                    return (Common.EnduranceType) comTrainingType.SelectedIndex;
                case Common.Sport.Squash:
                    return (Common.SquashType) comTrainingType.SelectedIndex;
                default:
                    return Common.TrainingType.None;
            }
        }

        private void ButCancelClick(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private void NumericTextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && ((TextBox) sender).Text.IndexOf('.') > -1)
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
            switch ((Common.Sport) comSport.SelectedIndex)
            {
                case Common.Sport.Running:
                case Common.Sport.Biking:
                    count = (int) Common.EnduranceType.Count;
                    type = typeof (Common.EnduranceType);
                    break;
                case Common.Sport.Squash:
                    count = (int) Common.SquashType.Count;
                    type = typeof (Common.SquashType);
                    break;
            }

            for (var i = 0; i < count; i++)
                comTrainingType.Items.Add(Enum.GetName(type, i));
            if (count > 0)
                comTrainingType.SelectedIndex = 0;

            // en-/disable distance
            grpDistance.Enabled = comSport.SelectedIndex == (int) Common.Sport.Running ||
                                  comSport.SelectedIndex == (int) Common.Sport.Biking;
        }

        private void DistanceTimeChanged(object sender, EventArgs e)
        {
            if (txtDistance.Text == "" || txtDuration.Text == "")
                return;

            var split = txtDuration.Text.Split('.');
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

            var dist = double.Parse(txtDistance.Text.EndsWith(".") ? txtDistance.Text + "0" : txtDistance.Text);
            var pace = ts.TotalMinutes/dist;
            var paceMin = Math.Floor(pace);
            var paceSec = Math.Floor((pace%1)*100);
            var speed = Math.Round(dist/ts.TotalHours, 2);

            // recalculate pace
            labPace.Text = "Pace:   " + paceMin + ':' + paceSec + " min/km";

            // recalculate speed
            labSpeed.Text = "Speed: " + speed + " km/h";
        }

        private void DurationChanged(object sender, EventArgs e)
        {
            var valid = true;
            var txt = (TextBox) sender;
            var split = txt.Text.Split('.');
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
                    break;
                default:
                    valid = false;
                    break;
            }

            txt.BackColor = valid ? Color.White : Color.Red;
        }
    }
}
