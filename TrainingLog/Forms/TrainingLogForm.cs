using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrainingLog.Controls;

namespace TrainingLog.Forms
{
    public partial class TrainingLogForm : Form
    {
        private readonly EntryListControl _elcTraining = new EntryListControl { EntryName = "Training", Columns = MergeColumnData(TrainingHeaders, TrainingTypes, TrainingWidths) };
        private readonly EntryListControl _elcBiodata = new EntryListControl { EntryName = "Bio Data", Columns = MergeColumnData(BiodataHeader, BiodataTypes, BiodataWidths) };
        private readonly EntryListControl _elcRace = new EntryListControl { EntryName = "Race", Columns = MergeColumnData(RaceHeader, RaceTypes, RaceWidths) };
        private readonly EntryListControl _elcUnified = new EntryListControl { EntryName = "All", Columns = MergeColumnData(UnifiedHeader, UnifiedTypes, UnifiedWidths) };

        private static EntryListColumn[] MergeColumnData(string[] headers, Type[] types, int[] widths)
        {
            if (headers.Length != types.Length)
                throw new ArgumentException();

            var result = new EntryListColumn[headers.Length];
            for (var i = 0; i < headers.Length; i++)
                result[i] = new EntryListColumn(headers[i], types[i], widths[i]);

            return result;
        }

        private readonly static string[] TrainingHeaders = new[]
                           {
                               "Date", "Sport", "Duration", "Calories", "Avg. HR", "Zone Data", "Distance (km)", "Feeling", "Notes"
                           };
        private readonly static Type[] TrainingTypes = new []
                                                          {
                                                              typeof(DateTimePicker), typeof(ComboBox), typeof(TimeSpanTextBox), typeof(IntegerTextBox), typeof(IntegerTextBox), typeof(TextBox), typeof(DecimalTextBox), typeof(TextBox), typeof(TextBox)
                                                          };
        private static readonly int[] TrainingWidths = new[] { 10, 110, 300, 400, 100, 200, 300, 400, 100 };

        private readonly static string[] BiodataHeader = new[]
                           {
                               "Date", "Sleep", "Resting HR", "OwnIndex", "Weight", "Feeling", "Nibbles", "Notes"
                           };
        private readonly static Type[] BiodataTypes = new[]
                                                          {
                                                              typeof(DateTimePicker), typeof(TextBox), typeof(IntegerTextBox), typeof(IntegerTextBox), typeof(DecimalTextBox), typeof(ComboBox), typeof(TextBox), typeof(TextBox)
                                                          };
        private static readonly int[] BiodataWidths = new[] { 1, 1, 1, 1, 1, 1, 1, 1 };
        
        private readonly static string[] RaceHeader = new[]
                           {
                               "Date"
                           };
        private readonly static Type[] RaceTypes = new[]
                                                          {
                                                              typeof(DateTimePicker)
                                                          };
        private static readonly int[] RaceWidths = new[] { 1 };
        
        private readonly static string[] UnifiedHeader = new[]
                           {
                               "Date"
                           };
        private readonly static Type[] UnifiedTypes = new[]
                                                          {
                                                              typeof(DateTimePicker)
                                                          };
        private static readonly int[] UnifiedWidths = new[] { 1 };

        private Size ScreenSize
        {
            get { return WindowState == FormWindowState.Maximized ? Screen.PrimaryScreen.WorkingArea.Size : ClientSize; }
        }

        private int TopY { get { return grpMain.Location.Y + grpMain.Height + 4; } }

        private int LeftX { get { return grpMain.Location.X; } }

        public static TrainingLogForm GetInstance
        {
            get { return _instance ?? (_instance = new TrainingLogForm()); }
        }

        private static TrainingLogForm _instance;

        public TrainingLogForm()
        {
            InitializeComponent();

            Controls.AddRange(new Control[]{ _elcTraining, _elcBiodata, _elcRace, _elcUnified });
            
            EntrySelectionChanged(null, null);

            foreach (var entry in Model.Instance.TrainingEntries)
            {
                var comFeeling = new ComboBox { FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList };
                foreach (var i in Enum.GetNames(typeof(Common.Index)))
                    if (i.Equals("Count"))
                        break;
                    else
                        comFeeling.Items.Add(i);
                comFeeling.Text = entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof (Common.Index), entry.Feeling);
                comFeeling.SelectedIndexChanged += (s, e) => comFeeling.BackColor = GetColor((double) comFeeling.SelectedIndex/(comFeeling.Items.Count - 1), Color.Red, Color.Yellow, Color.Green);

                var comSport = new ComboBox {FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDownList};
                Type type = null;
                switch (entry.Sport)
                {
                    case Common.Sport.Running:
                    case Common.Sport.Cycling:
                        type = typeof(Common.EnduranceType);
                        break;
                    case Common.Sport.Squash:
                        type = typeof(Common.SquashType);
                        break;
                }

                if (type != null)
                {
                    foreach (var t in Enum.GetNames(type))
                        if (t.Equals("Count"))
                            break;
                        else
                            comSport.Items.Add(Enum.GetName(typeof (Common.Sport), entry.Sport) + " (" + t + ')');
                }
                comSport.Text = entry.Sport + (entry.HasTrainingType ? "" : " (" + entry.TrainingType + ")");

                if (!_elcTraining.AddEntry(new Control[]{
                new ColorDatePicker{ Value = entry.DateTime, Format = DateTimePickerFormat.Short },
                comSport,
                new TimeSpanTextBox{ Text = entry.Duration.ToString(), BorderStyle = BorderStyle.None  },
                new IntegerTextBox{ Text = entry.Calories == 0 ? "" : entry.Calories.ToString(), BorderStyle = BorderStyle.None },
                new IntegerTextBox{ Text = entry.AverageHr == 0 ? "" : entry.AverageHr.ToString(), BorderStyle = BorderStyle.None },
                new TextBox{ Text = "<img>", BorderStyle = BorderStyle.None },
                new DecimalTextBox{ Text = entry.DistanceKm > 0 ? entry.DistanceKm.ToString() : "", BorderStyle = BorderStyle.None },
                comFeeling,
                new TextBox{ Text = entry.Note, BorderStyle = BorderStyle.None }}))
                    MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comFeeling.BackColor = entry.Feeling < Common.Index.Count ? GetColor((double)entry.Feeling/((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) : comFeeling.BackColor;
            }
            
            //foreach (var entry in Model.Instance.BioDataEntries.Where(entry => !_elcBiodata.AddEntry(new[]{
            //    entry.DateTime.ToShortDateString(),
            //    entry.SleepDuration + " (" + Enum.GetName(typeof (Common.Index), entry.SleepQuality) + ")",
            //    entry.RestingHeartRate == 0 ? "" : entry.RestingHeartRate.ToString(),
            //    entry.OwnIndex == 0 ? "" : entry.OwnIndex.ToString(),
            //    entry.Weight == 0 ? "" : entry.Weight.ToString(),
            //    entry.Feeling == Common.Index.None ? "" : Enum.GetName(typeof(Common.Index), entry.Feeling),
            //    entry.Nibbles,
            //    entry.Note 
            //                                                                                                })))
            //        MessageBox.Show("Problem adding entry " + entry, "Problem adding entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static Color GetColor(double percentage, Color from, Color middle, Color to)
        {
            return percentage < 0.5 ? GetColor(2*percentage, from, middle) : GetColor(2*(percentage - 0.5), middle, to);
        }

        private static Color GetColor(int actual, int max, Color from, Color to)
        {
            return GetColor((double) actual/max, from, to);
        }
        private static Color GetColor(double percentage, Color from, Color to)
        {
            return Color.FromArgb(from.R + (int)(percentage * (to.R - from.R)),
                                  from.G + (int)(percentage * (to.G - from.G)),
                                  from.B + (int)(percentage * (to.B - from.B)));
        }

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
            if (chkUnified.Checked)
            {
                _elcUnified.Visible = true;
                _elcTraining.Visible = false;
                _elcBiodata.Visible = false;
                _elcRace.Visible = false;

                PlaceOneEntryList(_elcUnified);
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
                    return;
                case 1:
                    PlaceOneEntryList(visible[0]);
                    return;
                case 2:
                    PlaceTwoEntryLists(visible[0], visible[1]);
                    return;
                case 3:
                    PlaceThreeEntryLists(visible[0], visible[1], visible[2]);
                    return;
            }
            throw new Exception();
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
            var width = ScreenSize.Width - 2*elc1.Location.X;

            elc1.Size = new Size(width, height);

            elc2.Location = new Point(elc1.Location.X, elc1.Location.Y + height + 6);
            elc2.Size = new Size(width, height);
        }

        private void PlaceOneEntryList(Control elc)
        {
            elc.Location = new Point(LeftX, TopY);
            elc.Size = new Size(ScreenSize.Width - 2 * elc.Location.X, ScreenSize.Height - elc.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14));
        }

        private void ButCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TrainingLogFormSizeChanged(object sender, EventArgs e)
        {
            EntrySelectionChanged(null, null);
        }
    }
}
