using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Charts;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class StatisticsForm : Form
    {
        #region Public Fields

        public static StatisticsForm Instance
        {
            get { return _instance ?? (_instance = new StatisticsForm()); }
        }

        public AbstractChart.GroupingType GroupingInterval
        {
            get
            {
                if (comGrouping.Text.Contains("day") && int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))) == 1)
                    return AbstractChart.GroupingType.OneDay;
                if (comGrouping.Text.Contains("week"))
                    switch (int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))))
                    {
                        case 1:
                            return AbstractChart.GroupingType.OneWeek;
                        case 2:
                            return AbstractChart.GroupingType.TwoWeeks;
                    }
                if (comGrouping.Text.Contains("month"))
                    switch (int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))))
                    {
                        case 1:
                            return AbstractChart.GroupingType.OneMonth;
                        case 3:
                            return AbstractChart.GroupingType.ThreeMonths;
                        case 6:
                            return AbstractChart.GroupingType.SixMonths;
                    }
                if (comGrouping.Text.Contains("year") && int.Parse(comGrouping.Text.Substring(0, comGrouping.Text.IndexOf(' '))) == 1)
                    return AbstractChart.GroupingType.OneYear;

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

        //private readonly IStatisticsPage[] _pages;
        private readonly AbstractChart[] _charts;

        private readonly bool[] _dirtyPages;

        #endregion

        #region Constructor
       
        private StatisticsForm()
        {
            // forms
            InitializeComponent();

            // filters
            InitializeFilters();
            _filters = new IFilter[] { dfcFrom, dfcTo, efcSport, efcTrainingType };

            _charts = GetCharts();
            AddCharts(_charts);


            //// pages
            //var graphs = GetGraphs();
            //var pages = GetPages();
            //foreach (var g in graphs)
            //    AddGraph(g as Graph);
            //foreach (var p in pages)
            //    AddPage(p as Control);

            //_pages = graphs.Concat(pages).ToArray();
            _dirtyPages = new bool[_charts.Length];

            tabTabs.SelectedIndexChanged += (s, e) =>
                                                {
                                                    // set grouping (dis/en)abled
                                                    comGrouping.Enabled = ((AbstractChart)tabTabs.TabPages[tabTabs.SelectedIndex].Controls[0]).GetGrouping != null;

                                                    // update page if necessary
                                                    if (!_dirtyPages[tabTabs.SelectedIndex]) return;
                                                    _charts[tabTabs.SelectedIndex].UpdateStatistics();
                                                    _dirtyPages[tabTabs.SelectedIndex] = false;
                                                };

            // TODO: make updating more fine-grained using the event args
            Model.Instance.EntriesChanged += (s, e) =>
            {
                if (Visible)
                    UpdateData();
                else
                {
                    EventHandler updateData = null;

                    updateData = (ss, ee) =>
                    {
                        UpdateData();
                        VisibleChanged -= updateData;
                    };
                    VisibleChanged += (ss, ee) => updateData(ss, ee);
                }
            };

            comGrouping.Enabled = ((AbstractChart)tabTabs.TabPages[tabTabs.SelectedIndex].Controls[0]).GetGrouping != null;
        }

        #endregion

        #region Main Methods

        private void AddCharts(IEnumerable<AbstractChart> charts)
        {
            foreach (var chart in charts)
            {
                var page = new TabPage { Text = chart.Titles[0].Text };

                // location/size
                chart.Location = new Point(0, 0);
                chart.Size = page.Size;
                var chart1 = chart;
                page.SizeChanged += (s, e) =>
                                        {
                                            chart1.Size = page.Size;
                                        };
                // add controls
                page.Controls.Add(chart);
                tabTabs.Controls.Add(page);
            }
        }

        private AbstractChart[] GetCharts()
        {
            return new AbstractChart[]
                       {
                           new SportOverviewChart(() => Model.Instance.TrainingEntries.Where(e => e.Sport == Common.Sport.Running).OrderBy(e => e.Date).ToArray(), Common.Sport.Running),
                           new BiodataChart(
                               () =>
                               Model.Instance.BiodataEntries.Except(
                                   (from te in Model.Instance.BiodataEntries
                                    from f in _filters
                                    where !f.IsEntryVisible(te)
                                    select te)).OrderBy(te => te.Date).ToArray())
                               {NonSportEntries = Common.NonSportEntries},
                           new DistanceChart(
                               () =>
                               Model.Instance.TrainingEntries.Except(
                                   (from te in Model.Instance.TrainingEntries
                                    from f in _filters
                                    where !f.IsEntryVisible(te)
                                    select te)).Where(te => te.DistanceMSpecified).OrderBy(te => te.Date).ToArray())
                               {NonSportEntries = Common.NonSportEntries, GetGrouping = () => GroupingInterval},
                           new FeelingChart(
                               () =>
                               Model.Instance.BiodataEntries.Except(
                                   (from te in Model.Instance.BiodataEntries
                                    from f in _filters
                                    where !f.IsEntryVisible(te)
                                    select te)).Cast<Entry>().Concat(
                                        Model.Instance.TrainingEntries.Where(
                                            e => e.Date >= Model.Instance.BiodataEntries.First().Date)
                                             .Except(
                                                 (from te in Model.Instance.TrainingEntries
                                                  from f in _filters
                                                  where !f.IsEntryVisible(te)
                                                  select te))).OrderBy(te => te.Date).ToArray())
                               {
                                   NonSportEntries = Common.NonSportEntries
                               },
                           new ZoneDataChart(
                               () =>
                               Model.Instance.TrainingEntries.Except(
                                   (from te in Model.Instance.TrainingEntries
                                    from f in _filters
                                    where !f.IsEntryVisible(te)
                                    select te)).Where(te => te.HrZoneStringSpecified).OrderBy(te => te.Date).ToArray())
                               {NonSportEntries = Common.NonSportEntries},
                           new ZoneDataAreaChart(
                               () =>
                               Model.Instance.TrainingEntries.Except(
                                   (from te in Model.Instance.TrainingEntries
                                    from f in _filters
                                    where !f.IsEntryVisible(te)
                                    select te)).Where(te => te.HrZoneStringSpecified).OrderBy(te => te.Date).ToArray())
                               {NonSportEntries = Common.NonSportEntries, GetGrouping = () => GroupingInterval}
                       };
        }

        private void UpdateData()
        {
            if (tabTabs.Controls.Count == 0)
                return;

            // active tab is a graph
            // visible page: update graph
            _charts[tabTabs.SelectedIndex].UpdateStatistics();

            // all other pages: mark as dirty
            foreach (var p in from Control p in tabTabs.Controls where tabTabs.Controls.IndexOf(p) != tabTabs.SelectedIndex select p)
                _dirtyPages[tabTabs.Controls.IndexOf(p)] = true;
        }

        //private void AddGraph(Graph graph)
        //{
        //    var page = new TabPage { Text = graph.Title };

        //    // location/size
        //    graph.Chart.Location = new Point(0, 0);
        //    graph.Chart.Size = page.Size;
        //    page.SizeChanged += (s, e) => graph.Chart.Size = page.Size;
        //    // add controls
        //    page.Controls.Add(graph.Chart);
        //    tabTabs.Controls.Add(page);
        //}

        //private void AddPage(Control page)
        //{
        //    var tabPage = new TabPage(page.Name);

        //    // location/size
        //    page.Location = new Point(0, 0);
        //    page.Size = tabPage.Size;
        //    tabPage.SizeChanged += (s, e) => page.Size = tabPage.Size;
        //    // add controls
        //    tabPage.Controls.Add(page);
        //    tabTabs.Controls.Add(tabPage);
        //}

        private void InitializeFilters()
        {
            // update graphs when grouping changes
            comGrouping.SelectedIndex = 0;
            comGrouping.SelectedIndexChanged += (s, e) => { UpdateData(); comGrouping.Focus(); };

            // prepare filters and update graphs when values change
            var entries = Model.Instance.TrainingEntries.Cast<Entry>().Concat(Model.Instance.BiodataEntries).OrderBy(e => e.Date);
            ((DateTimePicker) dfcFrom.GetControl()).Value = entries.First().Date ?? DateTime.MaxValue;
            ((DateTimePicker) dfcTo.GetControl()).Value = entries.Last().Date ?? DateTime.MinValue;
            ((DateTimePicker) dfcFrom.GetControl()).ValueChanged += (s, e) => { UpdateData(); dfcFrom.Focus(); };
            ((DateTimePicker) dfcTo.GetControl()).ValueChanged += (s, e) => { UpdateData(); dfcTo.Focus(); };

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

        //private IStatisticsPage[] GetGraphs()
        //{
        //    return new IStatisticsPage[0];//{
        //    //    new Graph(Graph.GraphType.BiodataFigures, 
        //    //        () => Model.Instance.BiodataEntries.Except((from te in Model.Instance.BiodataEntries from f in _filters where !f.IsEntryVisible(te) select te)).OrderBy(te => te.Date).Cast<Entry>().ToArray(),
        //    //        Common.NonSportEntries,
        //    //        () => new Tuple<DateInterval, int>(DateInterval.Day, 1))
        //    //        { Title = "Resting Heart Rate per day" }, 
        //    //    new Graph(Graph.GraphType.Distance,
        //    //        () => Model.Instance.TrainingEntries.Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)).Where(te => te.DistanceMSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray(),
        //    //        Common.NonSportEntries,
        //    //        () => GroupingInterval)
        //    //        { Title = "Distance" },
        //    //    new Graph(Graph.GraphType.ZoneData, 
        //    //        () => Model.Instance.TrainingEntries.Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)).Where(te => te.HrZoneStringSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray(),   
        //    //        Common.NonSportEntries,
        //    //        () => new Tuple<DateInterval, int>(DateInterval.Day, 1))
        //    //        { Title = "Zone Data per training" },
        //    //    new Graph(Graph.GraphType.ZoneDataArea, 
        //    //        () => Model.Instance.TrainingEntries.Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te)).Where(te => te.HrZoneStringSpecified).OrderBy(te => te.Date).Cast<Entry>().ToArray(),   
        //    //        Common.NonSportEntries,
        //    //        () => GroupingInterval)
        //    //        { Title = "Zone Data area" },
        //    //    new Graph(Graph.GraphType.Feeling, 
        //    //        () => Model.Instance.BiodataEntries.Except((from te in Model.Instance.BiodataEntries from f in _filters where !f.IsEntryVisible(te) select te)).Cast<Entry>().Concat(
        //    //            Model.Instance.TrainingEntries.Where(e => e.Date >= Model.Instance.BiodataEntries.First().Date).Except((from te in Model.Instance.TrainingEntries from f in _filters where !f.IsEntryVisible(te) select te))).OrderBy(te => te.Date).ToArray(),
        //    //        Common.NonSportEntries,
        //    //        () => new Tuple<DateInterval, int>(DateInterval.Day, 1))
        //    //        { Title = "Feeling" },
        //    //};
        //}

        //private IStatisticsPage[] GetPages()
        //{
        //    return new IStatisticsPage[]
        //               {
        //                   new SportOverviewStatisticsControl { GetEntries = () => Model.Instance.TrainingEntries.Where(e => e.Sport == Common.Sport.Running).OrderBy(e => e.Date).ToArray(), Sport = Common.Sport.Running},
        //                   new SportOverviewStatisticsControl { GetEntries = () => Model.Instance.TrainingEntries.Where(e => e.Sport == Common.Sport.Cycling).OrderBy(e => e.Date).ToArray(), Sport = Common.Sport.Cycling},
        //                   new SportOverviewStatisticsControl { GetEntries = () => Model.Instance.TrainingEntries.Where(e => e.Sport == Common.Sport.Squash).OrderBy(e => e.Date).ToArray(), Sport = Common.Sport.Squash}
        //               };
        //}

        #endregion

        #region Event Handling

        private void StatisticsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            MainForm.Instance.Show();
            MainForm.Instance.BringToFront();

            e.Cancel = !MainForm.Instance.CloseForms;
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
