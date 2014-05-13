
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TrainingLog.Forms
{
    public partial class TrainingEntryForm : Form
    {
        #region Public Fields

        public static TrainingEntryForm GetInstance
        {
            get { return _instance ?? (_instance = new TrainingEntryForm()); }
        }

        #endregion

        #region Private Fields

        private const string XmlValue1 = "value=";

        private readonly string[] _xmlKeys1 = new[]
                                        {
                                            "exe.result.duration",
                                            "exe.result.hrAvg",
                                            "exe.result.calories",
                                            "exe.result.distance",
                                            "exe.time_date"
                                        };
        private readonly string[] _xmlKeys2 = new[]
                                        {
                                            "exe.result.zones",
                                            "single_sport_name",
                                            "outputid=\"exe.note"
                                        };

        private static TrainingEntryForm _instance;

        #endregion

        #region Constructor

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
        }

        #endregion

        #region Main Methods

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
                comSport.SelectedIndex == (int) Common.Sport.Cycling)
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

                var diff = zoneData.Duration.CompareTo(duration) <= 0 ? zoneData.Duration.TotalSeconds / duration.TotalSeconds : duration.TotalSeconds / zoneData.Duration.TotalSeconds;
                if (diff > 1 + Common.SignificancePercentage || diff < 1 - Common.SignificancePercentage)
                {
                    var res = MessageBox.Show("Difference between sum of zone data and duration is too big (" + Math.Round((1 - diff) * 100, 2) + "%). Do you want to normalize?", "Too big difference", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    
                    if (res == DialogResult.Cancel)
                        return false;

                    if (res == DialogResult.Yes)
                    {
                        zoneData.Normailze(duration);

                        diff = zoneData.Duration.CompareTo(duration) <= 0 ? zoneData.Duration.TotalSeconds / duration.TotalSeconds : duration.TotalSeconds / zoneData.Duration.TotalSeconds;

                        MessageBox.Show("New difference after normalizing: " + Math.Round((1 - diff) * 100, 2) + "%. Times:\n" + zoneData.ToString().Replace('_', '\t'), "Results of Normalization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            return true;
        }

        private Enum GetTrainingType()
        {
            switch ((Common.Sport)comSport.SelectedIndex)
            {
                case Common.Sport.Running:
                case Common.Sport.Cycling:
                    return (Common.EnduranceType) comTrainingType.SelectedIndex;
                case Common.Sport.Squash:
                    return (Common.SquashType) comTrainingType.SelectedIndex;
                default:
                    return Common.TrainingType.None;
            }
        }

#endregion

        #region Event Handling

        private void ButCancelClick(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        //private void NumericTextChanged(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar)
        //        && !char.IsDigit(e.KeyChar)
        //        && e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if (e.KeyChar == '.'
        //        && ((TextBox) sender).Text.IndexOf('.') > -1)
        //    {
        //        e.Handled = true;
        //    }
        //}

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
                case Common.Sport.Cycling:
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
            txtDistance.Enabled = comSport.SelectedIndex == (int) Common.Sport.Running ||
                                  comSport.SelectedIndex == (int) Common.Sport.Cycling;

            if (txtDistance.Enabled) return;
            labPace.Text = "Pace:   ";
            labSpeed.Text = "Speed: ";
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

        private void ButParseFileClick(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { FileName = "polarpersonaltrainer.com.htm", InitialDirectory = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString(), Filter = "HTM-Files|*.htm|HTML-Files|*.html"};
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var lines = File.ReadAllLines(dlg.FileName);

            var lineIndices = new int[_xmlKeys1.Length + _xmlKeys2.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                // check keys1
                for (var j = 0; j < _xmlKeys1.Length; j++)
                    if (lines[i].Contains(XmlValue1) && lines[i].Contains(_xmlKeys1[j]))
                        if (lineIndices[j] == 0)
                            lineIndices[j] = i;
                        else
                            MessageBox.Show("Possibly reading wrong data. Check key " + _xmlKeys1[j],
                                            "Potential bad data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // check keys2
                for (var j = 0; j < _xmlKeys2.Length; j++)
                    if (lines[i].Contains(_xmlKeys2[j]))
                        if (lineIndices[_xmlKeys1.Length + j] == 0)
                            lineIndices[_xmlKeys1.Length + j] = i;
                        else
                            MessageBox.Show("Possibly reading wrong data. Check key " + _xmlKeys2[j],
                                            "Potential bad data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            for (var i = 0; i < lineIndices.Length; i++)
                if (lineIndices[i] == 0)
                    MessageBox.Show("Probably not found data \"" + _xmlKeys1[i] + "\".", "Data not found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // prepare data from xml keys 1
            var data = new string[lineIndices.Length];
            for (var i = 0; i < _xmlKeys1.Length; i++)
            {
                if (lineIndices[i] == 0)
                    data[i] = "";
                else
                {
                    // get the interesting part
                    data[i] =
                        lines[lineIndices[i]].Substring(lines[lineIndices[i]].IndexOf(XmlValue1,
                                                                                      StringComparison.Ordinal));
                    var firstQuote = data[i].IndexOf('\"');
                    // get substring between quotation marks
                    data[i] = data[i].Substring(firstQuote + 1, data[i].IndexOf('\"', firstQuote + 1) - firstQuote - 1);
                }
            }

            // prepare data from xml keys 2
            var split = lines[lineIndices[_xmlKeys1.Length]].Split('<');
            foreach (var t in split)
            {
                if (!t.Contains("zone-dur-time")) continue;
                var firstQuote = t.IndexOf('\"');
                var secondQuote = t.IndexOf('\"', firstQuote + 1);
                data[_xmlKeys1.Length] += '_' + t.Substring(secondQuote + 2, 8);
            }
            data[_xmlKeys1.Length] = data[_xmlKeys1.Length].Substring(1);

            split = lines[lineIndices[_xmlKeys1.Length + 1]].Split('<');
            foreach (var s in split)
            {
                if (!s.Contains(_xmlKeys2[1]))
                    continue;
                var firstQuote = s.IndexOf('\"');
                var secondQuote = s.IndexOf('\"', firstQuote + 1);
                data[_xmlKeys1.Length + 1] = s.Substring(secondQuote + 2);
            }
            
            split = lines[lineIndices[_xmlKeys1.Length + 2]].Split('<');
            foreach (var s in split)
            {
                if (!s.Contains(_xmlKeys2[2]))
                    continue;
                data[_xmlKeys1.Length + 2] = s.Substring(s.IndexOf('>') + 1);
            }
            txtDuration.Text = data[0].Replace(':', '.');
            txtAvgHR.Text = data[1];
            txtCalories.Text = data[2];
            txtDistance.Text = data[3];
            datDate.Value = DateTime.Parse(data[4]);
            comSport.Text = data[_xmlKeys1.Length + 1].Equals("Other sport") ? "Other" : data[_xmlKeys1.Length + 1];
            txtNotes.Text = data[_xmlKeys1.Length + 2];

            var zones = data[_xmlKeys1.Length].Split('_');
            if (zones.Length != 5)
                MessageBox.Show("Unable to process zone data properly (" + data[_xmlKeys1.Length] + ").", "Invalid zone data",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                txtZone5.Text = zones[0].Replace(':', '.');
                txtZone4.Text = zones[1].Replace(':', '.');
                txtZone3.Text = zones[2].Replace(':', '.');
                txtZone2.Text = zones[3].Replace(':', '.');
                txtZone1.Text = zones[4].Replace(':', '.');
            }
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
                Sport = (Common.Sport)comSport.SelectedIndex,
                TrainingType = GetTrainingType(),
                Calories = txtCalories.Text == "" ? 0 : int.Parse(txtCalories.Text),
                //TODO: save sweat data
                AverageHr = txtAvgHR.Text == "" ? 0 : int.Parse(txtAvgHR.Text),
                ZoneData = zoneData,
                DistanceKm = txtDistance.Text == "" ? 0 : double.Parse(txtDistance.Text),
                Feeling =
                    comFeeling.Text != ""
                        ? (Common.Index)(int)Common.Index.Count - comFeeling.SelectedIndex
                        : Common.Index.None,
                Note = txtNotes.Text
            };

            Model.Instance.AddEntry(entry);

            ResetForm();
            Close();
        }

        private void ButClearClick(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void TrainingEntryFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ButParseXmlClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
