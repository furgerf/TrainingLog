using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class TrainingEntryForm : Form
    {
        #region Public Fields

        public static TrainingEntryForm Instance
        {
            get { return _instance ?? (_instance = new TrainingEntryForm()); }
        }

        public TrainingEntry NewEntry { get; private set; }

        #endregion

        #region Private Fields

        private const string XmlValue1 = "value=";

        private readonly string[] _xmlKeys1 =
        {
            "exe.result.duration",
            "exe.result.hrAvg",
            "exe.result.calories",
            "exe.result.distance",
            "exe.time_date"
        };
        private readonly string[] _xmlKeys2 =
        {
            "exe.result.zones",
            "single_sport_name",
            "outputid=\"exe.note"
        };

        private static TrainingEntryForm _instance;

        #endregion

        #region Constructor

        public TrainingEntryForm(TrainingEntry entry)
            : this()
        {
            FillEntryData(entry);
        }

        private TrainingEntryForm()
        {
            InitializeComponent();

            ChkRaceCheckedChanged();

            datDate.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            // fill combobox list
            foreach (var foo in Enum.GetNames(typeof (Common.Sport)))
                if (foo.Equals("Count"))
                    break;
                else
                    comSport.Items.Add(foo);
            comSport.SelectedIndex = 0;

            comFeeling.Items.Add("");
            for (var i = Common.Index.Count - 1; i >= 0; i--)
                comFeeling.Items.Add(Enum.GetName(typeof(Common.Index), i) ??  "ERROR ENUM NAME NOT FOUND");
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
            chkRace.Checked = false;
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
            if (txtDuration.Text.Split(':').Length == 2)
                txtDuration.Text = "0:" + txtDuration.Text;
            if (txtDuration.Text.Split(':').Length == 3)
            {
                if (!TimeSpan.TryParse(txtDuration.Text, out duration))
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
                if (txtZone1.Text.Split(':').Length == 2)
                    txtZone1.Text = "0:" + txtZone1.Text;
                if (txtZone2.Text.Split(':').Length == 2)
                    txtZone2.Text = "0:" + txtZone2.Text;
                if (txtZone3.Text.Split(':').Length == 2)
                    txtZone3.Text = "0:" + txtZone3.Text;
                if (txtZone4.Text.Split(':').Length == 2)
                    txtZone4.Text = "0:" + txtZone4.Text;
                if (txtZone5.Text.Split(':').Length == 2)
                    txtZone5.Text = "0:" + txtZone5.Text;

                if (txtZone1.Text == "")
                    txtZone1.Text = "0:0:0";
                if (txtZone2.Text == "")
                    txtZone2.Text = "0:0:0";
                if (txtZone3.Text == "")
                    txtZone3.Text = "0:0:0";
                if (txtZone4.Text == "")
                    txtZone4.Text = "0:0:0";
                if (txtZone5.Text == "")
                    txtZone5.Text = "0:0:0";

                if (!ZoneData.TryParse(txtZone5.Text + '_' + txtZone4.Text + '_' + txtZone3.Text + '_' +
                                                     txtZone2.Text + '_' + txtZone1.Text, out
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

        private void FillEntryData(TrainingEntry entry)
        {
            ResetForm();

            if (entry.AverageHrSpecified)
                txtAvgHR.Text = entry.AverageHr.ToString();
            if (entry.CaloriesSpecified)
                txtCalories.Text = entry.Calories.ToString();
            if (entry.DateSpecified)
                datDate.Value = entry.Date ?? DateTime.MinValue;
            if (entry.DistanceMSpecified)
                txtDistance.Text = entry.DistanceKm.ToString(CultureInfo.InvariantCulture);
            if (entry.DurationStringSpecified)
                txtDuration.Text = entry.DurationString;
            if (entry.FeelingSpecified)
                comFeeling.Text = Enum.GetName(typeof(Common.Index), entry.Feeling ?? Common.Index.Count);
            if (entry.HrZoneStringSpecified)
            {
                txtZone1.Text = (entry.HrZones ?? ZoneData.Empty()).Zone1.ToString();
                txtZone2.Text = (entry.HrZones ?? ZoneData.Empty()).Zone2.ToString();
                txtZone3.Text = (entry.HrZones ?? ZoneData.Empty()).Zone3.ToString();
                txtZone4.Text = (entry.HrZones ?? ZoneData.Empty()).Zone4.ToString();
                txtZone5.Text = (entry.HrZones ?? ZoneData.Empty()).Zone5.ToString();
            }
            if (entry.NoteSpecified)
                txtNotes.Text = entry.Note;
            if (entry.SportSpecified)
                comSport.Text = Enum.GetName(typeof(Common.Sport), entry.Sport ?? Common.Sport.Count);
            if (entry.TrainingTypeSpecified)
                comTrainingType.Text = Enum.GetName(typeof(Common.TrainingType), entry.TrainingType);
            if (entry.EquipmentNameSpecified)
                comEquipment.Text = entry.Equipment.Name;

            DistanceTimeChanged();
        }

        #endregion

        #region Event Handling

        private void ButCancelClick(object sender, EventArgs e)
        {
            ResetForm();
            Close();
        }

        private void ChkRaceCheckedChanged(object sender = null, EventArgs e = null)
        {
            Width += (chkRace.Checked ? 1 : -1)*(grpCompetition.Width + 6);
            grpCompetition.Visible = chkRace.Checked;

            if (!chkRace.Checked) return;

            // set visibility of proper control
            runningRaceEntryControl1.Visible = (Common.Sport) comSport.SelectedIndex == Common.Sport.Running;
            squashMatchEntryControl1.Visible = (Common.Sport) comSport.SelectedIndex == Common.Sport.Squash;
                
            // fill in comboboxes
            if (runningRaceEntryControl1.Visible)
                runningRaceEntryControl1.UpdateComboBoxes();

            if (squashMatchEntryControl1.Visible)
                squashMatchEntryControl1.UpdateComboBoxes();
        }

        private void ComSportSelectedIndexChanged(object sender, EventArgs e)
        {
            // update training types
            comTrainingType.Items.Clear();

            if (Array.Exists(Common.EnduranceSports, ee => ee == (Common.Sport) comSport.SelectedIndex))
            {
                var foo = new object[Common.EnduranceTypes.Length];
                for (var i = 0; i < Common.EnduranceTypes.Length; i++)
                    foo[i] = Common.EnduranceTypes[i].ToString();
                comTrainingType.Items.AddRange(foo);
            }
            else if (((Common.Sport) comSport.SelectedIndex) == Common.Sport.Squash)
            {
                var foo = new object[Common.SquashTypes.Length];
                for (var i = 0; i < Common.SquashTypes.Length; i++)
                    foo[i] = Common.SquashTypes[i].ToString();
                comTrainingType.Items.AddRange(foo);   
            }

            if (comTrainingType.Items.Count > 0)
                comTrainingType.SelectedIndex = 0;

            // en-/disable distance
            txtDistance.Enabled = comSport.SelectedIndex == (int) Common.Sport.Running ||
                                  comSport.SelectedIndex == (int) Common.Sport.Cycling;

            if (!txtDistance.Enabled)
            {
                labPace.Text = "Pace:   ";
                labSpeed.Text = "Speed: ";
            }

            // update equipment
            comEquipment.Items.Clear();
            foreach (var ee in Model.Instance.Equipment.Where(ee => ee.Sport.ToString().Equals(comSport.Text)))
                comEquipment.Items.Add(ee.Name);

            if (comEquipment.Items.Count > 0)
                comEquipment.SelectedIndex = comEquipment.Items.Count - 1;

            // en/dis-able race checkbox
            chkRace.Enabled = (Common.Sport) comSport.SelectedIndex == Common.Sport.Running ||
                              (Common.Sport) comSport.SelectedIndex == Common.Sport.Squash;
            if (!chkRace.Enabled)
                chkRace.Checked = false;

            // ensure proper competition control is visible
            if (chkRace.Checked)
            {
                runningRaceEntryControl1.Visible = (Common.Sport)comSport.SelectedIndex == Common.Sport.Running;
                squashMatchEntryControl1.Visible = (Common.Sport)comSport.SelectedIndex == Common.Sport.Squash;
            }
        }

        private void DistanceTimeChanged(object sender = null, EventArgs e = null)
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

            var dist = double.Parse(txtDistance.Text.EndsWith(".") ? txtDistance.Text + "0" : txtDistance.Text);
            var pace = ts.TotalMinutes/dist;
            var paceMin = Math.Floor(pace);
            var paceSec = Math.Floor((pace%1)*60);
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
            txtDuration.Text = data[0];
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
                txtZone5.Text = zones[0];
                txtZone4.Text = zones[1];
                txtZone3.Text = zones[2];
                txtZone2.Text = zones[3];
                txtZone1.Text = zones[4];
            }
        }

        private void TrainingEntryFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // already cancelled?
            if (e.Cancel)
                return;

            Hide();

            e.Cancel = !MainForm.Instance.CloseForms;
        }

        private void ButOkClick(object sender, EventArgs e)
        {
            TimeSpan duration;
            ZoneData zoneData;
            if (!IsDataValid(out duration, out zoneData))
                return;

            TrainingEntry entry;

            if (!chkRace.Checked)
            {
                entry = new TrainingEntry(duration)
                {
                    Date = datDate.Value,
                    Sport = (Common.Sport) comSport.SelectedIndex,
                    TrainingType =
                        comTrainingType.Text.Equals("")
                            ? Common.TrainingType.None
                            : (Common.TrainingType) Enum.Parse(typeof (Common.TrainingType), comTrainingType.Text),
                    Calories = txtCalories.Text == "" ? 0 : int.Parse(txtCalories.Text),
                    AverageHr = txtAvgHR.Text == "" ? 0 : int.Parse(txtAvgHR.Text),
                    HrZones = zoneData,
                    DistanceKm = txtDistance.Text == "" ? 0 : double.Parse(txtDistance.Text),
                    Feeling =
                        comFeeling.Text != ""
                            ? (Common.Index) (int) Common.Index.Count - comFeeling.SelectedIndex
                            : Common.Index.None,
                    Note = txtNotes.Text,
                    Equipment = Model.Instance.Equipment.FirstOrDefault(ee => ee.Name.Equals(comEquipment.Text))
                };
            }
            else if (comSport.SelectedIndex == (int)Common.Sport.Running)
            {
                if (runningRaceEntryControl1.ExactTime == null)
                {
                    MessageBox.Show("Please enter the exact time of the race!", "Enter exact time", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                if (runningRaceEntryControl1.ExactDistanceKm == null)
                {
                    MessageBox.Show("Please enter the exact distance of the race!", "Enter exact distance", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                if (runningRaceEntryControl1.Competition == "")
                {
                    MessageBox.Show("Please enter the competition name!", "Enter competition", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                entry = new RunningRace(duration, runningRaceEntryControl1.ExactTime.Value, 1000 * (double)runningRaceEntryControl1.ExactDistanceKm.Value, runningRaceEntryControl1.Competition)
                {
                    Date = datDate.Value,
                    Sport = (Common.Sport)comSport.SelectedIndex,
                    TrainingType =
                        comTrainingType.Text.Equals("")
                            ? Common.TrainingType.None
                            : (Common.TrainingType)Enum.Parse(typeof(Common.TrainingType), comTrainingType.Text),
                    Calories = txtCalories.Text == "" ? 0 : int.Parse(txtCalories.Text),
                    AverageHr = txtAvgHR.Text == "" ? 0 : int.Parse(txtAvgHR.Text),
                    HrZones = zoneData,
                    DistanceKm = txtDistance.Text == "" ? 0 : double.Parse(txtDistance.Text),
                    Feeling =
                        comFeeling.Text != ""
                            ? (Common.Index)(int)Common.Index.Count - comFeeling.SelectedIndex
                            : Common.Index.None,
                    Note = txtNotes.Text,
                    Equipment = Model.Instance.Equipment.FirstOrDefault(ee => ee.Name.Equals(comEquipment.Text)),

                    RaceAverageHr = runningRaceEntryControl1.RaceAverageHr
                };

                if (runningRaceEntryControl1.OverallRank != 0)
                    ((RunningRace)entry).OverallRank = runningRaceEntryControl1.OverallRank;
                if (runningRaceEntryControl1.AgeGroupRank != 0)
                    ((RunningRace)entry).AgeGroupRank = runningRaceEntryControl1.AgeGroupRank;
            }
            else if (comSport.SelectedIndex == (int) Common.Sport.Squash)
            {
                if (squashMatchEntryControl1.Result == "")
                {
                    MessageBox.Show("Please enter the result of the match!", "Enter result", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                if (squashMatchEntryControl1.Competition == "")
                {
                    MessageBox.Show("Please enter the competition name!", "Enter competition", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                entry = new SquashMatch(duration, squashMatchEntryControl1.Result, squashMatchEntryControl1.Competition)
                {
                    Date = datDate.Value,
                    Sport = (Common.Sport) comSport.SelectedIndex,
                    TrainingType =
                        comTrainingType.Text.Equals("")
                            ? Common.TrainingType.None
                            : (Common.TrainingType) Enum.Parse(typeof (Common.TrainingType), comTrainingType.Text),
                    Calories = txtCalories.Text == "" ? 0 : int.Parse(txtCalories.Text),
                    AverageHr = txtAvgHR.Text == "" ? 0 : int.Parse(txtAvgHR.Text),
                    HrZones = zoneData,
                    DistanceKm = txtDistance.Text == "" ? 0 : double.Parse(txtDistance.Text),
                    Feeling =
                        comFeeling.Text != ""
                            ? (Common.Index) (int) Common.Index.Count - comFeeling.SelectedIndex
                            : Common.Index.None,
                    Note = txtNotes.Text,
                    Equipment = Model.Instance.Equipment.FirstOrDefault(ee => ee.Name.Equals(comEquipment.Text)),

                    MatchTime = squashMatchEntryControl1.ExactTime,
                    Opponent = squashMatchEntryControl1.Opponent,
                    MatchAverageHr = squashMatchEntryControl1.MatchAverageHr,
                };
            }
            else
            {
                throw new NotImplementedException("This sport doesnt know competitions!");
            }

            NewEntry = entry;

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
            var dlg = new OpenFileDialog { InitialDirectory = "D:\\downloads",//Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString()
                Filter = "XML-Files|*.xml" };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var ser = new XmlSerializer(typeof(polarexercisedata));
            calendaritem[] foo;
            using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                foo = ((polarexercisedata) ser.Deserialize(fs)).calendaritems.Items;
            var exercises = new List<exercisedata>();
            var invalidCount = 0;
            foreach (var f in foo)
                if (f is exercisedata)
                    exercises.Add((exercisedata) f);
                else
                    invalidCount++;

            if (exercises.Count == 1 && invalidCount > 0)
                MessageBox.Show("Ignoring " + invalidCount + " invalid entries", "Invalid data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            var res = DialogResult.Yes;
            if (exercises.Count > 1)
                res = MessageBox.Show(exercises.Count + " exercises found" + (invalidCount > 0 ? " as well as " + invalidCount + " other entries which will be skipped. " : ".") + " Entry forms for each exercise will be opened sequentially. Do you want to continue?", exercises.Count + " exercises found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
                return;

            Action openTef = null;
            CancelEventHandler preventClosing = (ss, ee) =>
                               {
                                   ee.Cancel = true;
                                   openTef();
                               };

            openTef = () =>
                          {
                              FillEntryData(new TrainingEntry
                                                {
                                                    AverageHr = exercises[0].result.heartrate.average,
                                                    Calories = int.Parse(exercises[0].result.calories),
                                                    Date = DateTime.Parse(exercises[0].time),
                                                    DistanceM = (int) exercises[0].result.distance,
                                                    Duration =
                                                        TimeSpan.Parse(exercises[0].result.duration.Contains(".") ? 
                                                        exercises[0].result.duration.Remove(exercises[0].result.duration.IndexOf('.')) : 
                                                        exercises[0].result.duration),
                                                    HrZones =
                                                        ZoneData.Parse(exercises[0].result.zones[4].inzone + "_" +
                                                                       exercises[0].result.zones[3].inzone +
                                                                       "_" + exercises[0].result.zones[2].inzone +
                                                                       "_" +
                                                                       exercises[0].result.zones[1].inzone + "_" +
                                                                       exercises[0].result.zones[0].inzone),
                                                    Note = exercises[0].note,
                                                    Sport = exercises[0].sport == "Other sport" ? Common.Sport.Other : 
                                                        (Common.Sport) Enum.Parse(typeof (Common.Sport), exercises[0].sport)
                                                });
                              exercises.RemoveAt(0);

                              if (exercises.Count == 0)
                                  Closing -= preventClosing;
                          };

            if (exercises.Count > 1)
                Closing += preventClosing;

            openTef();




            //    if (exercises.Count == 1)
            //    {
            //        txtDuration.Text = exercises[0].result.duration.Remove(exercises[0].result.duration.IndexOf('.'));
            //        txtAvgHR.Text = exercises[0].result.heartrate.average.ToString(CultureInfo.InvariantCulture);
            //        txtCalories.Text = exercises[0].result.calories;
            //        txtDistance.Text = (exercises[0].result.distance / 1000).ToString(CultureInfo.InvariantCulture);
            //        datDate.Value = DateTime.Parse(exercises[0].time);
            //        comSport.Text = exercises[0].sport.Equals("Other sport") ? "Other" : exercises[0].sport;
            //        txtNotes.Text = exercises[0].note;
            //        txtZone5.Text = exercises[0].result.zones[4].inzone;
            //        txtZone4.Text = exercises[0].result.zones[3].inzone;
            //        txtZone3.Text = exercises[0].result.zones[2].inzone;
            //        txtZone2.Text = exercises[0].result.zones[1].inzone;
            //        txtZone1.Text = exercises[0].result.zones[0].inzone;
            //        Show();
            //    }
            //    else
            //    {
            //        var tef = new TrainingEntryForm(new TrainingEntry
            //            {
            //                AverageHr = exercises[0].result.heartrate.average,
            //                Calories = int.Parse(exercises[0].result.calories),
            //                Date = DateTime.Parse(exercises[0].time),
            //                DistanceM = (int)exercises[0].result.distance,
            //                Duration = TimeSpan.Parse(exercises[0].result.duration.Remove(exercises[0].result.duration.IndexOf('.'))),
            //                HrZones =
            //                    ZoneData.Parse(exercises[0].result.zones[4].inzone + "_" +
            //                                    exercises[0].result.zones[3].inzone +
            //                                    "_" + exercises[0].result.zones[2].inzone +
            //                                    "_" +
            //                                    exercises[0].result.zones[1].inzone + "_" +
            //                                    exercises[0].result.zones[0].inzone),
            //                Note = exercises[0].note,
            //                Sport =
            //                    (Common.Sport)
            //                    Enum.Parse(typeof(Common.Sport), exercises[0].sport)
            //            });

            //        tef.Closing += (ss, ee) => openTef();

            //        tef.Show();
            //    }
            //    exercises.RemoveAt(0);
            //};

            //openTef();

            //    var te = new TrainingEntry
            //{
            //    AverageHr = bar.result.heartrate.average,
            //    Calories = int.Parse(bar.result.calories),
            //    Date = DateTime.Parse(bar.time),
            //    DistanceM = (int)bar.result.distance,
            //    Duration = TimeSpan.Parse(bar.result.duration),
            //    HrZones =
            //        ZoneData.Parse(bar.result.zones[4].inzone + "_" + bar.result.zones[3].inzone +
            //                       "_" + bar.result.zones[2].inzone + "_" +
            //                       bar.result.zones[1].inzone + "_" + bar.result.zones[0].inzone),
            //    Note = bar.note,
            //    Sport = (Common.Sport)Enum.Parse(typeof(Common.Sport), bar.sport)
            //};
        }

        #endregion
    }
}
