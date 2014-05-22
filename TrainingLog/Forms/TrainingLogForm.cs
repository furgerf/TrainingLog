﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class TrainingLogForm : Form
    {
        #region Public Fields

        public static TrainingLogForm GetInstance
        {
            get { return _instance ?? (_instance = new TrainingLogForm()); }
        }

        #endregion

        #region Private Fields

        private static TrainingLogForm _instance;

        private readonly EntryListControl _elcTraining;
        private readonly EntryListControl _elcBiodata;
        private readonly EntryListControl _elcRace;
        private readonly EntryListControl _elcUnified;

        private readonly static string[] TrainingHeaders = new[]
                           {
                               "Date", "Sport", "Duration", "Calories", "Avg. HR", "Zone Data", "Distance (km)", "Feeling", "Notes"
                           };
        private static readonly int[] TrainingWidths = new[] { 75, 110, 55, 50, 50, 100, 80, 70, 150 };

        private readonly static string[] BiodataHeader = new[]
                           {
                               "Date", "Sleep", "Rest HR", "OwnIndex", "Weight", "Feeling", "Nibbles", "Notes"
                           };
        private static readonly int[] BiodataWidths = new[] { 75, 100, 60, 60, 45, 70, 110, 150 };

        private readonly static string[] RaceHeader = new[]
                           {
                               "Date"
                           };
        private static readonly int[] RaceWidths = new[] { 1 };

        private readonly static string[] UnifiedHeader = new[]
                           {
                               "Date", "Description", "Feeling", "Heart Rate", "Distance/Weight", "Calories", "Notes"
                           };
        private static readonly int[] UnifiedWidths = new[] { 75, 140, 50, 120, 95, 50, 150 };

        private Size ScreenSize
        {
            get { return WindowState == FormWindowState.Maximized ? Screen.PrimaryScreen.WorkingArea.Size : ClientSize; }
        }

        private int TopY { get { return grpMain.Location.Y + grpMain.Height + 4; } }

        private int LeftX { get { return grpMain.Location.X; } }

        #endregion

        #region Constructor

        public TrainingLogForm()
        {
            InitializeComponent();

            _elcTraining = new EntryListControl { EntryName = "Training", Columns = MergeColumnData(TrainingHeaders, TrainingWidths), ControlsEnabled = chkEdit.Checked };
            _elcBiodata = new EntryListControl { EntryName = "Bio Data", Columns = MergeColumnData(BiodataHeader, BiodataWidths), FilterVisible = false, ControlsEnabled = chkEdit.Checked };
            _elcRace = new EntryListControl { EntryName = "Race", Columns = MergeColumnData(RaceHeader, RaceWidths), ControlsEnabled = chkEdit.Checked };
            _elcUnified = new EntryListControl { EntryName = "All", Columns = MergeColumnData(UnifiedHeader, UnifiedWidths), ControlsEnabled = chkEdit.Checked };

            Controls.AddRange(new Control[] { _elcTraining, _elcBiodata, _elcRace, _elcUnified });

            _elcTraining.AddFilter(new DateFilterControl { Location = new Point(3, 16), IsMinDate = true }, 0, DateTime.Today.Subtract(new TimeSpan(10, 0, 0, 0)));
            _elcTraining.AddFilter(new DateFilterControl { Location = new Point(140, 16), IsMinDate = false }, 0);
        }

        #endregion

        #region Main Methods

        private static EntryListColumn[] MergeColumnData(IList<string> headers, IList<int> widths)
        {
            if (headers.Count != widths.Count)
                throw new ArgumentException();

            var result = new EntryListColumn[headers.Count];
            for (var i = 0; i < headers.Count; i++)
                result[i] = new EntryListColumn(headers[i], widths[i]);

            return result;
        }

        public static Color GetColor(double percentage, Color from, Color middle, Color to)
        {
            return percentage < 0.5 ? GetColor(2*percentage, from, middle) : GetColor(2*(percentage - 0.5), middle, to);
        }

        private static Color GetColor(double percentage, Color from, Color to)
        {
            return Color.FromArgb(from.R + (int)(percentage * (to.R - from.R)),
                                  from.G + (int)(percentage * (to.G - from.G)),
                                  from.B + (int)(percentage * (to.B - from.B)));
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
            var width = ScreenSize.Width - 2 * elc1.Location.X;

            elc1.Size = new Size(width, height);

            elc2.Location = new Point(elc1.Location.X, elc1.Location.Y + height + 6);
            elc2.Size = new Size(width, height);
        }

        private void PlaceOneEntryList(Control elc)
        {
            elc.Location = new Point(LeftX, TopY);
            elc.Size = new Size(ScreenSize.Width - 2 * elc.Location.X, ScreenSize.Height - elc.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14));
        }

        private void AddTrainingEntries()
        {
            _elcTraining.ClearEntries();
            foreach (var entry in Model.Instance.TrainingEntries)
            {
                var comFeeling = new ComboBox { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
                foreach (var i in Enum.GetNames(typeof(Common.Index)))
                    if (i.Equals("Count"))
                        break;
                    else
                        comFeeling.Items.Add(i);
                comFeeling.Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), entry.Feeling);
                comFeeling.SelectedIndexChanged += (s, e) =>
                {
                    comFeeling.BackColor = GetColor((double)comFeeling.SelectedIndex / (comFeeling.Items.Count - 1), Color.Red, Color.Yellow, Color.Green);
                    comFeeling.Text = comFeeling.SelectedText;
                };

                var comSport = new ComboBox { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
                switch (entry.Sport)
                {
                    case Common.Sport.Running:
                    case Common.Sport.Cycling:
                        foreach (var t in Common.EnduranceTypes)
                            comSport.Items.Add(entry.Sport + " (" + t + ")");
                        break;
                    case Common.Sport.Squash:
                        foreach (var t in Common.SquashTypes)
                            comSport.Items.Add(entry.Sport + " (" + t + ")");
                        break;
                    case Common.Sport.Other:
                        comSport.Items.Add(Enum.GetName(typeof(Common.Sport), Common.Sport.Other));
                        break;
                }

                comSport.Text = entry.Sport + (entry.TrainingTypeSpecified ? " (" + entry.TrainingType + ")" : "");
                comSport.SelectedIndexChanged += (s, e) => comSport.Text = comSport.SelectedText;

                if (!_elcTraining.AddEntry(new Control[]{
                new ColorDatePicker{ Value = entry.Date ?? DateTime.MinValue, Format = DateTimePickerFormat.Short },
                comSport,
                new TimeSpanTextBox{ Text = entry.Duration.ToString().Replace(':', '.'), BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                new IntegerTextBox{ Text = entry.Calories == 0 ? "" : entry.Calories.ToString(), BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                new IntegerTextBox{ Text = entry.AverageHr == 0 ? "" : entry.AverageHr.ToString(), BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                new ZoneDataBox { ZoneData = entry.HrZones ?? ZoneData.Empty() },
                new DecimalTextBox{ Text = entry.DistanceKm > 0 ? entry.DistanceKm.ToString(CultureInfo.InvariantCulture) : "", BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                comFeeling,
                new TextBox{ Text = entry.Note, BorderStyle = BorderStyle.None }}, entry))
                    MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comFeeling.BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)entry.Feeling / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : comFeeling.BackColor;
            }
            _elcTraining.SortByDate();
        }

        private void AddBiodataEntries()
        {
            _elcBiodata.ClearEntries();
            foreach (var entry in Model.Instance.BiodataEntries)
            {
                var comFeeling = new ComboBox { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
                foreach (var i in Enum.GetNames(typeof(Common.Index)))
                    if (i.Equals("Count"))
                        break;
                    else
                        comFeeling.Items.Add(i);
                comFeeling.Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count));
                comFeeling.SelectedIndexChanged += (s, e) =>
                {
                    comFeeling.BackColor = GetColor((double)comFeeling.SelectedIndex / (comFeeling.Items.Count - 1), Color.Red, Color.Yellow, Color.Green);
                    comFeeling.Text = comFeeling.SelectedText;
                };

                var txtSleep = new TextBox
                {
                    Text = entry.SleepDuration.ToString() + " (" + entry.SleepQuality + ")",
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    BackColor = Color.Purple,
                };
                // "disable" manual entry
                txtSleep.KeyDown += (s, e) =>
                {
                    e.Handled = true;
                };
                // show entry form on double click
                txtSleep.DoubleClick += (s, e) =>
                {
                    var txt = ((TextBox)s).Text;
                    new SleepForm { Duration = TimeSpan.Parse(txt.Substring(0, txt.IndexOf('('))), Quality = (Common.Index)Enum.Parse(typeof(Common.Index), txt.Substring(txt.IndexOf('(') + 1, txt.IndexOf(')') - txt.IndexOf('(') - 1)), OriginalText = (TextBox)s }.Show();
                };

                foreach (var s in Enum.GetNames(typeof(Common.Index)))
                {
                    if (
                        txtSleep.Text.Substring(txtSleep.Text.IndexOf('(') + 1,
                                                txtSleep.Text.IndexOf(')') - txtSleep.Text.IndexOf('(') - 1).Equals(s))
                    {
                        txtSleep.BackColor = GetColor(((double)(int)Enum.Parse(typeof(Common.Index), s) / ((int)Common.Index.Count - 1)), Color.Red, Color.Yellow, Color.Green);
                        break;
                    }
                }

                if (!_elcBiodata.AddEntry(new Control[]{
                new ColorDatePicker{ Value = entry.Date ?? DateTime.MinValue, Format = DateTimePickerFormat.Short },
                txtSleep,
                new IntegerTextBox{ Text = entry.RestingHeartRate == 0 ? "" : entry.RestingHeartRate.ToString(), BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                new IntegerTextBox{ Text = entry.OwnIndex == 0 ? "" : entry.OwnIndex.ToString(), BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                new DecimalTextBox { Text = entry.Weight > 0 ? entry.Weight.ToString() : "", BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                comFeeling,
                new TextBox{ Text = entry.Nibbles, BorderStyle = BorderStyle.None  },
                new TextBox{ Text = entry.Note, BorderStyle = BorderStyle.None }}, entry))
                    MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comFeeling.BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)(entry.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : comFeeling.BackColor;
            }
            _elcBiodata.SortByDate();
        }

        private void AddUnifiedEntries()
        {
            _elcUnified.ClearEntries();
            foreach (var entry in Model.Instance.Entries)
            {
                if (entry is TrainingEntry)
                {
                    var training = entry as TrainingEntry;

                    if (!_elcUnified.AddEntry(new Control[]{
                    new ColorDatePicker{ Value = entry.Date ?? DateTime.MinValue, Format = DateTimePickerFormat.Short },
                    new TextBox{ Text = training.Sport + (training.TrainingTypeSpecified ? "" : " (" + training.TrainingType + ") - " + training.Duration), BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                    new TextBox{ Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)), BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)(entry.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : BackColor, TextAlign = HorizontalAlignment.Center, BorderStyle = BorderStyle.None },
                    new ZoneDataBox { ZoneData = training.HrZones ?? ZoneData.Empty(), OverlayText = training.AverageHr > 0 ? training.AverageHr.ToString() : "", Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)},
                    new TextBox{ Text = training.DistanceKm > 0 ? training.DistanceKm.ToString(CultureInfo.InvariantCulture) + " km" : "", BorderStyle =  BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                    new TextBox{ Text = training.Calories > 0 ? training.Calories.ToString() + " kcal" : "", BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                    new TextBox{ Text = entry.Note, BorderStyle = BorderStyle.None }}, entry))
                        MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (entry is BiodataEntry)
                {
                    var biodata = entry as BiodataEntry;
                    var hr = biodata.RestingHeartRate != 0 ? "Rest: " + biodata.RestingHeartRate : "";
                    if (biodata.OwnIndex != 0)
                        if (hr.Length == 0)
                            hr = "OwnIndex " + biodata.OwnIndex;
                        else
                            hr += " - OwnIndex " + biodata.OwnIndex;

                    if (!_elcUnified.AddEntry(new Control[]{
                    new ColorDatePicker{ Value = entry.Date ?? DateTime.MinValue, Format = DateTimePickerFormat.Short },
                    new TextBox { Text = "Sleep: " + biodata.SleepDuration + " (" + biodata.SleepQuality + ")", BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center, BackColor = biodata.SleepQuality < Common.Index.Count ? GetColor((double)(biodata.SleepQuality ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : BackColor },
                    new TextBox{ Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)), BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)(entry.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : BackColor, TextAlign = HorizontalAlignment.Center, BorderStyle = BorderStyle.None },
                    new TextBox{ Text = hr, BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                    new TextBox{ Text = biodata.Weight > 0 ? biodata.Weight.ToString() + " kg" : "", BorderStyle = BorderStyle.None, TextAlign = HorizontalAlignment.Center },
                    new TextBox{ BorderStyle = BorderStyle.None },
                    new TextBox{ Text = entry.Note, BorderStyle = BorderStyle.None }}, entry))
                        MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    throw new Exception();
            }
            _elcUnified.SortByDate();
        }

        private void AddRaceEntries()
        {
            throw new NotImplementedException();
        }

        //private string GetParseableStringTraining(string[] data)
        //{
        //    ZoneData zd;
        //    if (!ZoneData.TryParse(data[5].Split('\t')[1], out zd))
        //        return null;
        //    var sport = (Common.Sport)Enum.Parse(typeof(Common.Sport), data[1].IndexOf('(') > 0 ? data[1].Substring(0, data[1].IndexOf('(') - 1) : data[1]);
        //    var trainingType = (Common.TrainingType)Enum.Parse(typeof(Common.TrainingType), data[1].Substring(data[1].IndexOf('(') + 1, data[1].IndexOf(')') - data[1].IndexOf('(') - 1));

        //    //if (data[1].IndexOf('(') > 0)
        //    //{
        //    //    sport = (Common.Sport) Enum.Parse(typeof (Common.Sport), data[1].Substring(0, data[1].IndexOf('(') - 1));
        //    //    var type = GetType();
        //    //    switch (sport)
        //    //    {
        //    //        case Common.Sport.Running:
        //    //        case Common.Sport.Cycling:
        //    //            type = typeof(Common.EnduranceType);
        //    //            break;
        //    //        case Common.Sport.Squash:
        //    //            type = typeof(Common.SquashType);
        //    //            break;
        //    //    }

        //    //    trainingType = (Common.TrainingType)Enum.Parse(type, data[1].Substring(data[1].IndexOf('(') + 1, data[1].IndexOf(')') - data[1].IndexOf('(') - 1));

        //    //    if (type == typeof (Common.EnduranceType))
        //    //        trainingType = (Common.EnduranceType) trainingType;
        //    //    if (type == typeof (Common.SquashType))
        //    //        trainingType = (Common.SquashType) trainingType;
        //    //} else
        //    //{
        //    //    sport = (Common.Sport) Enum.Parse(typeof (Common.Sport), data[1]);
        //    //    trainingType = Common.TrainingType.None;
        //    //}

        //    var entry = new TrainingEntry(TimeSpan.Parse(data[2].Replace('.', ':')))
        //    {
        //        AverageHr = int.Parse(data[4]),
        //        Calories = int.Parse(data[3]),
        //        Date = DateTime.ParseExact(data[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None),
        //        DistanceKm = double.Parse(data[6]),
        //        Feeling = (Common.Index)Enum.Parse(typeof(Common.Index), data[7]),
        //        Note = data[8],
        //        HrZones = zd,
        //        Sport = sport,
        //        TrainingType = trainingType
        //    };
        //    return entry.LogString;
        //}

        #endregion

        #region Event Handling

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
                Close();
        }

        private void EntrySelectionChanged(object sender, EventArgs e)
        {
            if (chkUnified == null || _elcTraining == null)
                return;

            if (chkUnified.Checked)
            {
                _elcUnified.Visible = true;
                _elcTraining.Visible = false;
                _elcBiodata.Visible = false;
                _elcRace.Visible = false;

                PlaceOneEntryList(_elcUnified);

                AddUnifiedEntries();

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
                    break;
                case 1:
                    PlaceOneEntryList(visible[0]);
                    break;
                case 2:
                    PlaceTwoEntryLists(visible[0], visible[1]);
                    break;
                case 3:
                    PlaceThreeEntryLists(visible[0], visible[1], visible[2]);
                    break;
                default:
                    throw new Exception();
            }

            if (chkTraining.Checked)
                AddTrainingEntries();
            if (chkBiodata.Checked)
                AddBiodataEntries();
            if (chkRace.Checked)
                AddRaceEntries();
        }

        private void ButCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TrainingLogFormSizeChanged(object sender, EventArgs e)
        {
            EntrySelectionChanged(null, null);
        }

        private void ChkEditCheckedChanged(object sender, EventArgs e)
        {
            //if (chkEdit.Checked)
            //{
            //    if (
            //        MessageBox.Show("Are you sure you want to edit the data?", "Enable editing", MessageBoxButtons.YesNo,
            //                        MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        chkEdit.Checked = false;
            //        return;
            //    }
            //}

            _elcTraining.ControlsEnabled = chkEdit.Checked;
            _elcBiodata.ControlsEnabled = chkEdit.Checked;
            _elcRace.ControlsEnabled = chkEdit.Checked;
            _elcUnified.ControlsEnabled = chkEdit.Checked;
        }

        private void TrainingLogFormActivated(object sender, EventArgs e)
        {
            EntrySelectionChanged(null, null);
        }

        #endregion
    }
}
