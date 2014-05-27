using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Controls;
using TrainingLog.Entries;
using TrainingLog.Statistics;

namespace TrainingLog.Forms
{
    public partial class StatisticsForm : Form
    {
        #region Public Fields

        public static StatisticsForm GetInstance
        {
            get { return _instance ?? (_instance = new StatisticsForm()); }
        }

        #endregion

        #region Private Fields

        private static StatisticsForm _instance;

        private Size ScreenSize
        {
            get { return WindowState == FormWindowState.Maximized ? Screen.PrimaryScreen.WorkingArea.Size : ClientSize; }
        }

        private IEnumerable<TrainingEntry> FilteredTrainingEntries
        {
            get
            {
                var invisible =
                    (from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)
                        .ToList();
                return Model.Instance.TrainingEntries.Except(invisible).ToArray();
            }
        }

        private IEnumerable<BiodataEntry> FilteredBiodataEntries
        {
            get
            {
                var invisible =
                    (from te in Model.Instance.BiodataEntries from f in _filters where !f.IsEntryVisible(te) select te)
                        .ToList();
                return Model.Instance.BiodataEntries.Except(invisible).ToArray();
            }
        }

        private readonly IFilter[] _filters;

        private readonly Action _loadData;

        #endregion

        #region Constructor

        public StatisticsForm()
        {
            InitializeComponent();

            ((DateTimePicker)dfcFrom.GetControl()).Value = DateTime.Today.Subtract(new TimeSpan(31 * 6, 0, 0, 0));
            ((DateTimePicker)dfcTo.GetControl()).Value = DateTime.Today;
            ((DateTimePicker)dfcFrom.GetControl()).ValueChanged += UpdateData;
            ((DateTimePicker)dfcTo.GetControl()).ValueChanged += UpdateData;

            efcTrainingType.LabelText = "Training";
            efcTrainingType.DataFromEntry = e => ((TrainingEntry)e).TrainingType.ToString();
            ((ComboBox)efcTrainingType.GetControl()).SelectedValueChanged += UpdateData;
            ((ComboBox)efcSport.GetControl()).SelectedValueChanged += (s, e) =>
                                                        {
                                                            var types = efcSport.GetControl()
                                                                .Text.Equals(EnumFilterControl.All) ? Common.AllTypes : Common.GetTrainingTypes((Common.Sport)Enum.Parse(typeof (Common.Sport), (efcSport.GetControl()).Text));
                                                            var strings = new string[types.Length];
                                                            for (var i = 0; i < types.Length; i++)
                                                                strings[i] = types[i].ToString();
                                                            efcTrainingType.Items =
                                                                new [] {EnumFilterControl.All}.Concat(strings)
                                                                                    .ToArray();
                                                        };

            efcSport.LabelText = "Sport";
            efcSport.DataFromEntry = e => ((TrainingEntry)e).Sport.ToString();
            efcSport.Items = new[] { EnumFilterControl.All }.Concat(Enum.GetNames(typeof(Common.Sport)).Where(e => !e.Equals("Count"))).ToArray();
            ((ComboBox)efcSport.GetControl()).SelectedValueChanged += UpdateData;
            
            _filters = new IFilter[] {dfcFrom, dfcTo, efcSport, efcTrainingType};

            _loadData = () =>
                            {
                                AddDistanceGraph();
                                AddZoneDataGraph();
                                AddZoneDataAreaGraph();
                                AddBiodataRestingHrGraph();
                            };
        }

        #endregion

        #region Main Methods

        public void UpdateData(object sender = null, EventArgs e = null)
        {
            if (_loadData == null)
                return;

            var index = tabTabs.SelectedIndex;
            ClearGraphs();
            _loadData();
            tabTabs.SelectedIndex = index;
        }

        private void AddDistanceGraph()
        {
            var graph = new Graph(Graph.GraphType.Distance, FilteredTrainingEntries.Where(te => te.DistanceMSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray()) { Title = "Distance per day" };
            AddGraph(graph);
        }

        private void AddBiodataRestingHrGraph()
        {
            var entries = FilteredBiodataEntries.Where(e => e.RestingHeartRateSpecified || e.WeightSpecified || e.OwnIndexSpecified).Cast<Entry>().OrderBy(e => e.Date).ToArray();

            var graph = new Graph(Graph.GraphType.BiodataFigures, entries) { Title = "Resting Heart Rate per day" };
            AddGraph(graph);
        }

        private void AddZoneDataGraph()
        {
            var entries = FilteredTrainingEntries.Cast<Entry>().OrderBy(ee => ee.Date).ToArray();

            var graph = new Graph(Graph.GraphType.ZoneData, entries) { Title = "Zone Data per training" };
            AddGraph(graph);
        }

        private void AddZoneDataAreaGraph()
        {
            var entries = FilteredTrainingEntries.Cast<Entry>().OrderBy(ee => ee.Date).ToArray();

            var graph = new Graph(Graph.GraphType.ZoneDataArea, entries) { Title = "Zone Data area per day" };
            AddGraph(graph);
        }

        private void AddGraph(Graph graph)
        {
            var page = new TabPage {Text = graph.Title};

            // location/size
            graph.Chart.Location = new Point(0,0);
            graph.Chart.Size = page.Size;
            page.SizeChanged += (s, e) => graph.Chart.Size = page.Size;

            // add controls
            page.Controls.Add(graph.Chart);
            tabTabs.Controls.Add(page);
        }

        private void ClearGraphs()
        {
            tabTabs.Controls.Clear();
        }

        #endregion

        #region Event Handling

        private void StatisticsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.GetInstance.Show();
            MainForm.GetInstance.BringToFront();

            e.Cancel = !MainForm.GetInstance.CloseForms;
        }

        private void StatisticsFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void StatisticsFormSizeChanged(object sender, EventArgs e)
        {
            grpFilter.Width = ScreenSize.Width - 2 * grpFilter.Location.X;

            tabTabs.Size = new Size(ScreenSize.Width - 2 * tabTabs.Location.X, ScreenSize.Height - tabTabs.Location.Y - (WindowState == FormWindowState.Maximized ? 28 : 14));
        }

        #endregion
    }
}
