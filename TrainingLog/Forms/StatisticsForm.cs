using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
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

        public Tuple<DateInterval,int> GroupingInterval
        {
            get
            {
                if (comGrouping.Text.Contains("day"))
                    return new Tuple<DateInterval, int>(DateInterval.Day, int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))));
                if (comGrouping.Text.Contains("week"))
                    return new Tuple<DateInterval, int>(DateInterval.Day, 7 * int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))));
                if (comGrouping.Text.Contains("month"))
                    return new Tuple<DateInterval, int>(DateInterval.Month, int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))));
                if (comGrouping.Text.Contains("year"))
                    return new Tuple<DateInterval, int>(DateInterval.Year, int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))));
                throw new Exception("invalid text: " + comGrouping.Text);
            }
        }

        #endregion

        #region Private Fields

        private static StatisticsForm _instance;

        private Size ScreenSize
        {
            get
            {
                return WindowState == FormWindowState.Maximized ? Screen.FromControl(this).WorkingArea.Size : ClientSize;
            }
        }

        private readonly IFilter[] _filters;

        private readonly Graph[] _graphs;

        private readonly bool[] _dirtyGraphs;

        #endregion

        #region Constructor
       
        public StatisticsForm()
        {
            // forms
            InitializeComponent();

            // filters
            InitializeFilters();
            _filters = new IFilter[] { dfcFrom, dfcTo, efcSport, efcTrainingType };

            // graphs
            _graphs = GetGraphs();
            _dirtyGraphs = new bool[_graphs.Length];

            foreach (var g in _graphs)
                AddGraph(g);


            tabTabs.SelectedIndexChanged += (s, e) =>
                                                {
                                                    if (!_dirtyGraphs[tabTabs.SelectedIndex]) return;
                                                    _graphs[tabTabs.SelectedIndex].UpdateGraph();
                                                    _dirtyGraphs[tabTabs.SelectedIndex] = false;
                                                };
        }

        #endregion

        #region Main Methods

        public void UpdateData(object sender = null, EventArgs e = null)
        {
            if (tabTabs.Controls.Count == 0)
                return;

            // visible page: update graph
            _graphs[tabTabs.SelectedIndex].UpdateGraph();

            // all other pages: mark as dirty
            foreach (var p in from Control p in tabTabs.Controls where tabTabs.Controls.IndexOf(p) != tabTabs.SelectedIndex select p)
                _dirtyGraphs[tabTabs.Controls.IndexOf(p)] = true;
        }

        private void AddGraph(Graph graph)
        {
            var page = new TabPage { Text = graph.Title };

            // location/size
            graph.Chart.Location = new Point(0, 0);
            graph.Chart.Size = page.Size;
            page.SizeChanged += (s, e) => graph.Chart.Size = page.Size;
            // add controls
            page.Controls.Add(graph.Chart);
            tabTabs.Controls.Add(page);
        }

        private void InitializeFilters()
        {
            // update graphs when grouping changes
            comGrouping.SelectedIndex = 0;
            comGrouping.SelectedIndexChanged += (s, e) => { UpdateData(); comGrouping.Focus(); };

            // prepare filters and update graphs when values change
            var orderedEntries = Model.Instance.Entries.OrderBy(e => e.Date);
            ((DateTimePicker) dfcFrom.GetControl()).Value = orderedEntries.First().Date ?? DateTime.MinValue;
            ((DateTimePicker)dfcTo.GetControl()).Value = orderedEntries.Last().Date ?? DateTime.MaxValue;
            ((DateTimePicker)dfcFrom.GetControl()).ValueChanged += (s, e) => { UpdateData(); dfcFrom.Focus(); };
            ((DateTimePicker)dfcTo.GetControl()).ValueChanged += (s, e) => { UpdateData(); dfcTo.Focus(); };

            efcTrainingType.LabelText = "Training";
            efcTrainingType.DataFromEntry = e => ((TrainingEntry)e).TrainingType.ToString();
            ((ComboBox)efcTrainingType.GetControl()).SelectedValueChanged += (s, e) => { UpdateData(); efcTrainingType.Focus(); };
            ((ComboBox)efcSport.GetControl()).SelectedValueChanged += (s, e) =>
            {
                var types = efcSport.GetControl()
                    .Text.Equals(EnumFilterControl.All) ? Common.AllTypes : Common.GetTrainingTypes((Common.Sport)Enum.Parse(typeof(Common.Sport), (efcSport.GetControl()).Text));
                var strings = new string[types.Length];
                for (var i = 0; i < types.Length; i++)
                    strings[i] = types[i].ToString();
                efcTrainingType.Items =
                    new[] { EnumFilterControl.All }.Concat(strings)
                                        .ToArray();
            };

            efcSport.LabelText = "Sport";
            efcSport.DataFromEntry = e => ((TrainingEntry)e).Sport.ToString();
            efcSport.Items = new[] { EnumFilterControl.All }.Concat(Enum.GetNames(typeof(Common.Sport)).Where(e => !e.Equals("Count"))).ToArray();
            ((ComboBox)efcSport.GetControl()).SelectedValueChanged += (s, e) => { UpdateData(); efcSport.Focus(); };
        }

        private Graph[] GetGraphs()
        {
            return new[]{
                new Graph(Graph.GraphType.BiodataFigures, 
                    () => Model.Instance.BiodataEntries.Except((from te in Model.Instance.BiodataEntries from f in _filters where !f.IsEntryVisible(te) select te)).OrderBy(te => te.Date).Cast<Entry>().ToArray(),
                    () => new Tuple<DateInterval, int>(DateInterval.Day, 1))
                    { Title = "Resting Heart Rate per day" }, 

                new Graph(Graph.GraphType.Distance,
                    () => Model.Instance.TrainingEntries.Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)).Where(te => te.DistanceMSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray(),
                    () => GroupingInterval)
                    { Title = "Distance" },
            
                new Graph(Graph.GraphType.ZoneData, 
                    () => Model.Instance.TrainingEntries.Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)).Where(te => te.HrZoneStringSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray(),   
                    () => new Tuple<DateInterval, int>(DateInterval.Day, 1))
                    { Title = "Zone Data per training" },

                new Graph(Graph.GraphType.ZoneDataArea, 
                    () => Model.Instance.TrainingEntries.Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)).Where(te => te.HrZoneStringSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray(),   
                    () => GroupingInterval)
                    { Title = "Zone Data area" }
            };
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
