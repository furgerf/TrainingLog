using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
                               "", "", "Date", "Sport", "Duration", "Calories", "Zone Data", "Distance (km)", "Feeling", "Notes"
                           };
        private static readonly int[] TrainingWidths = new[] { EntryListControl.ButtonColumnWidth, EntryListControl.ButtonColumnWidth, 160, 110, 55, 50, 100, 80, 70, 150 };
        private static readonly bool[] TrainingFixed = new[] { true, true, true, true, true, true, false, true, true, false};

        private readonly static string[] BiodataHeader = new[]
                           {
                               "", "", "Date", "Sleep", "Rest HR", "OwnIndex", "Weight", "Feeling", "Niggles", "Notes"
                           };
        private static readonly int[] BiodataWidths = new[] { EntryListControl.ButtonColumnWidth, EntryListControl.ButtonColumnWidth, 160, 100, 60, 60, 50, 70, 110, 150 };
        private static readonly bool[] BiodataFixed = new[] { true, true, true, true, true, true, true, true, false, false };

        private readonly static string[] RaceHeader = new[]
                           {
                               "Date"
                           };
        private static readonly int[] RaceWidths = new[] { 1 };
        private static readonly bool[] RaceFixed = new[] { true };

        private readonly static string[] UnifiedHeader = new[]
                           {
                               "Date", "Description", "Feeling", "Heart Rate", "Distance/Weight", "Calories", "Notes"
                           };
        private static readonly int[] UnifiedWidths = new[] { 160, 180, 50, 120, 95, 60, 150 };
        private static readonly bool[] UnifiedFixed = new[] { true, true, true, false, true, true, false };

        private Size ScreenSize
        {
            get { return WindowState == FormWindowState.Maximized ? Screen.PrimaryScreen.WorkingArea.Size : ClientSize; }
        }

        private int TopY { get { return grpMain.Location.Y + grpMain.Height + 4; } }

        private int LeftX { get { return grpMain.Location.X; } }

        private bool _trainingdataAdded;
        private bool _biodataAdded;
        private bool _racedataAdded;
        private bool _unifieddataAdded;

        #endregion

        #region Constructor

        public TrainingLogForm()
        {
            InitializeComponent();

            // initialize controls
            _elcTraining = new EntryListControl { EntryName = "Training", Columns = MergeColumnData(TrainingHeaders, TrainingWidths, TrainingFixed) };
            _elcBiodata = new EntryListControl { EntryName = "Bio Data", Columns = MergeColumnData(BiodataHeader, BiodataWidths, BiodataFixed) };
            _elcRace = new EntryListControl { EntryName = "Race", Columns = MergeColumnData(RaceHeader, RaceWidths, RaceFixed) };
            _elcUnified = new EntryListControl { EntryName = "All", Columns = MergeColumnData(UnifiedHeader, UnifiedWidths, UnifiedFixed) };
            Controls.AddRange(new Control[] { _elcTraining, _elcBiodata, _elcRace, _elcUnified });

            // ensure data is re-loaded when form is shown again
            VisibleChanged += (s, e) =>
                                  {
                                      if (Visible)
                                          EntrySelectionChanged();
                                  };

            //_elcTraining.AddFilter(new DateFilterControl { Location = new Point(3, 16), IsMinDate = true }, 0, DateTime.Today.Subtract(new TimeSpan(10, 0, 0, 0)));
            //_elcTraining.AddFilter(new DateFilterControl { Location = new Point(140, 16), IsMinDate = false }, 0);
        }

        #endregion

        #region Main Methods

        private static EntryListColumn[] MergeColumnData(IList<string> headers, IList<int> widths, IList<bool> fixedSizes = null)
        {
            if (headers.Count != widths.Count)
                throw new ArgumentException();
            if (fixedSizes != null && fixedSizes.Count != headers.Count)
                throw new ArgumentException();

            var result = new EntryListColumn[headers.Count];
            for (var i = 0; i < headers.Count; i++)
                if (fixedSizes == null)
                    result[i] = new EntryListColumn(headers[i], widths[i]);
                else
                    result[i] = new EntryListColumn(headers[i], widths[i], fixedSizes[i]);

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

            foreach (var entry in Model.Instance.TrainingEntries.Where(entry => !_elcTraining.AddEntry(ControlsForTrainingEntry(entry), entry, updateControl: entry.Equals(Model.Instance.TrainingEntries.Last()))))
                MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _elcTraining.SortByDate();

            _trainingdataAdded = true;
        }

        public Control[] ControlsForTrainingEntry(TrainingEntry entry)
        {
            return new Control[]{
                        new Label{ Text = (entry.Date ?? DateTime.MinValue).ToLongDateString(), TextAlign = ContentAlignment.MiddleCenter, Tag = (entry.Date ?? DateTime.MinValue).ToOADate() },
                        new Label{ Text = entry.Sport + (entry.TrainingTypeSpecified ? " (" + entry.TrainingType + ")" : ""), TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Sport + (entry.TrainingTypeSpecified ? " (" + entry.TrainingType + ")" : "") },
                        new Label{ Text = entry.Duration.ToString().Replace(':', '.'), TextAlign = ContentAlignment.MiddleCenter, Tag = (entry.Duration ?? TimeSpan.Zero).TotalSeconds },
                        new Label{ Text = entry.Calories == 0 ? "" : entry.Calories.ToString(), TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Calories ?? 0 },
                        new ZoneDataBox { ZoneData = entry.HrZones ?? ZoneData.Empty(),  OverlayText = entry.AverageHrSpecified ? '\u00d8' + entry.AverageHr.ToString() : "", Tag = entry.AverageHr ?? 0 },
                        new Label{ Text = entry.DistanceKm > 0 ? entry.DistanceKm.ToString(CultureInfo.InvariantCulture) : "", TextAlign = ContentAlignment.MiddleCenter, Tag = entry.DistanceM ?? 0 },
                        new Label{ Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), entry.Feeling), BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)entry.Feeling / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : _elcTraining.FirstColor, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), entry.Feeling) },
                        new Label{ Text = entry.Note, Tag = entry.Note ?? "", TextAlign = ContentAlignment.MiddleLeft }};
        }

        private void AddBiodataEntries()
        {
            _elcBiodata.ClearEntries();

            foreach (var entry in Model.Instance.BiodataEntries.Where(entry => !_elcBiodata.AddEntry(ControlsForBiodataEntry(entry), entry)))
                MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _elcBiodata.SortByDate();

            _biodataAdded = true;
        }

        public Control[] ControlsForBiodataEntry(BiodataEntry entry)
        {
            return new Control[]{
                        new Label{ Text = (entry.Date ?? DateTime.MinValue).ToLongDateString(), TextAlign = ContentAlignment.MiddleCenter, Tag = (entry.Date ?? DateTime.MinValue).ToOADate() },
                        new Label{ Text = entry.SleepDuration.ToString() + " (" + entry.SleepQuality + ")", TextAlign = ContentAlignment.MiddleCenter, Tag = (entry.SleepDuration ?? TimeSpan.Zero).TotalMinutes, BackColor = GetColor((double)(entry.SleepQuality ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green)},
                        new Label{ Text = entry.RestingHeartRate == 0 ? "" : entry.RestingHeartRate.ToString(), TextAlign = ContentAlignment.MiddleCenter, Tag = entry.RestingHeartRate },
                        new Label{ Text = entry.OwnIndex == 0 ? "" : entry.OwnIndex.ToString(), BorderStyle = BorderStyle.None, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.OwnIndex},
                        new Label{ Text = entry.Weight > 0 ? entry.Weight.ToString() : "", BorderStyle = BorderStyle.None, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Weight },
                        new Label{ Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)), BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)(entry.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : _elcBiodata.FirstColor, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count))}, 
                        new Label{ Text = entry.Niggles, BorderStyle = BorderStyle.None, Tag = entry.Niggles ?? "", TextAlign = ContentAlignment.MiddleLeft },
                        new Label{ Text = entry.Note, BorderStyle = BorderStyle.None, Tag = entry.Note ?? "", TextAlign = ContentAlignment.MiddleLeft }};
        }

        private void AddUnifiedEntries()
        {
            _elcUnified.ClearEntries();

            foreach (var entry in Model.Instance.Entries)
            {
                if (entry is TrainingEntry)
                {
                    if (!_elcUnified.AddEntry(ControlsForUnifiedTrainingEntry(entry as TrainingEntry), entry, false))
                        MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (entry is BiodataEntry)
                {
                    if (!_elcUnified.AddEntry(ControlsForUnifiedBiodataEntry(entry as BiodataEntry), entry, false))
                        MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    throw new Exception();
            }

            _elcUnified.SortByDate();

            _unifieddataAdded = true;
        }

        public Control[] ControlsForUnifiedTrainingEntry(TrainingEntry entry)
        {
            return new Control[]{
                    new Label{ Text = (entry.Date ?? DateTime.MinValue).ToLongDateString(), TextAlign = ContentAlignment.MiddleCenter, Tag = (entry.Date ?? DateTime.MinValue).ToOADate() },
                    new Label{ Text = entry.Sport + (entry.TrainingTypeSpecified ? " (" + entry.TrainingType + ")" : "") + " - " + entry.Duration, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Sport + (entry.TrainingTypeSpecified ? " (" + entry.TrainingType + ")" : "") + " - " + entry.Duration },
                    new Label{ Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)), BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)(entry.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : _elcUnified.FirstColor, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)) },
                    new ZoneDataBox { ZoneData = entry.HrZones ?? ZoneData.Empty(), OverlayText =  entry.AverageHr == 0 ? "" : '\u00d8' + entry.AverageHr.ToString(), Tag = entry.AverageHr > 0 ? entry.AverageHr.ToString() : "" },
                    new Label{ Text = entry.DistanceKm > 0 ? entry.DistanceKm.ToString(CultureInfo.InvariantCulture) + " km" : "", TextAlign = ContentAlignment.MiddleCenter, Tag = entry.DistanceKm },
                    new Label{ Text = entry.Calories > 0 ? entry.Calories.ToString() + " kcal" : "", BorderStyle = BorderStyle.None, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Calories },
                    new Label{ Text = entry.Note, TextAlign = ContentAlignment.MiddleLeft, Tag = entry.NoteSpecified ? entry.Note : "" }};
        }

        public Control[] ControlsForUnifiedBiodataEntry(BiodataEntry entry)
        {
            var hr = entry.RestingHeartRateSpecified ? "Rest: " + entry.RestingHeartRate : "";
            if (entry.OwnIndexSpecified)
                if (hr.Length == 0)
                    hr = "OwnIndex: " + entry.OwnIndex;
                else
                    hr += " - OwnIndex: " + entry.OwnIndex;

            var note = entry.NoteSpecified ? entry.Note : "";
            if (entry.NoteSpecified && entry.NigglesSpecified)
                note += "; Niggle: " + entry.Niggles;
            else if (entry.NigglesSpecified)
                note += "Niggle: " + entry.Niggles;

            return new Control[]{
            new Label{ Text = (entry.Date ?? DateTime.MinValue).ToLongDateString(), TextAlign = ContentAlignment.MiddleCenter, Tag = (entry.Date ?? DateTime.MinValue).ToOADate() },
            new Label { Text = "Sleep: " + entry.SleepDuration + " (" + entry.SleepQuality + ")", TextAlign = ContentAlignment.MiddleCenter, BackColor = entry.SleepQuality < Common.Index.Count ? GetColor((double)(entry.SleepQuality ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : _elcUnified.FirstColor, Tag = "Sleep: " + entry.SleepDuration + " (" + entry.SleepQuality + ")" },
            new Label{ Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)), BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)(entry.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : _elcUnified.FirstColor, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), (entry.Feeling ?? Common.Index.Count)) },
            new Label{ Text = hr, TextAlign = ContentAlignment.MiddleCenter, Tag = entry.RestingHeartRateSpecified ? entry.RestingHeartRate : 0 },
            new Label{ Text = entry.Weight > 0 ? entry.Weight.ToString() + " kg" : "", TextAlign = ContentAlignment.MiddleCenter, Tag = entry.Weight > 0 ? entry.Weight : 0 },
            new Label{ Tag = 0 },
            new Label{ Text = note, TextAlign = ContentAlignment.MiddleLeft, Tag = note }};
        }

        private void AddRaceEntries()
        {
            _racedataAdded = true;
            throw new NotImplementedException();
        }

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

        private void EntrySelectionChanged(object sender = null, EventArgs e = null)
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

                if (!_unifieddataAdded)
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

            if (chkTraining.Checked && !_trainingdataAdded)
                AddTrainingEntries();
            if (chkBiodata.Checked && !_biodataAdded)
                AddBiodataEntries();
            if (chkRace.Checked && !_racedataAdded)
                AddRaceEntries();
        }

        private void ButCloseClick(object sender, EventArgs e)
        {
            // ensure data is reloaded when window is re-opened
            _trainingdataAdded = false;
            _biodataAdded = false;
            _racedataAdded = false;
            _unifieddataAdded = false;

            Close();
        }

        private void TrainingLogFormSizeChanged(object sender, EventArgs e)
        {
            if (Visible)
                EntrySelectionChanged();
        }

        #endregion
    }
}
