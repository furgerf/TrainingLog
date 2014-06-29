using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class Graph : IStatisticsPage
    {
        #region Enums

        public enum GraphType
        {
            ZoneData,
            ZoneDataArea,
            BiodataFigures,
            Distance,
            Feeling
        }

        #endregion

        #region Public Fields

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                //if (Chart.Titles.Count > 0) Chart.Titles.RemoveAt(0);
                //Chart.Titles.Add(_title);
            }
        }

        #endregion

        #region Private Fields

        private readonly ChartArea _area = new ChartArea();

        public readonly Chart Chart = new Chart();

        private readonly Legend _legend = new Legend();

        private string _title;

        private AbstractSeriesCollection _series;

        private readonly Series _nonSportSeries = new Series("Non-Sport Entries") { IsVisibleInLegend = false };

        private readonly GraphType _type;

        private readonly Func<Tuple<DateInterval, int>> _getGrouping;

        private readonly Func<Entry[]> _getEntries;

        private readonly Func<Entry[], NonSportEntry[]> _nonSportEntries;

        #endregion

        #region Constructor

        public Graph(GraphType type, Func<Entry[]> entries, Func<Entry[], NonSportEntry[]> nonSportEntries, Func<Tuple<DateInterval, int>> grouping)
        {
            _getGrouping = grouping;
            _type = type;
            _getEntries = entries;
            _nonSportEntries = nonSportEntries;

            Chart.ChartAreas.Add(_area);
            Chart.Legends.Add(_legend);

            Initialize();
        }

        #endregion

        #region Main Methods

        private void InitializeAxes(Tuple<DateInterval, int> grouping)
        {
            var x = new Axis(_area, AxisName.X);
            var y = new Axis(_area, AxisName.Y);

            // x
            x.Title = "Date";
            if (grouping != null)
            {
                x.IntervalAutoMode = IntervalAutoMode.FixedCount;
                switch (grouping.Item1)
                {
                    case DateInterval.Year:
                        x.IntervalType = DateTimeIntervalType.Years;
                        break;
                    case DateInterval.Month:
                        x.IntervalType = DateTimeIntervalType.Months;
                        break;
                    case DateInterval.Day:
                        x.IntervalType = DateTimeIntervalType.Days;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                x.Interval = grouping.Item2;

                if (grouping.Item1 == DateInterval.Day)
                    if (grouping.Item2 == 5 || grouping.Item2 == 7)
                        x.IntervalOffset = -1;
                    else if (grouping.Item2 == 14)
                        x.IntervalOffset = -9;
                    else if (grouping.Item2 == 21)
                        x.IntervalOffset = -12;
            }
            else
                x.IntervalAutoMode = IntervalAutoMode.VariableCount;

            // y
            y.Minimum = _series.MinimumY;
            y.Maximum = _series.MaximumY; 
            switch (_type)
            {
                case GraphType.ZoneData:
                    y.IntervalType = DateTimeIntervalType.Seconds;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    break;
                case GraphType.ZoneDataArea:
                    y.IntervalType = DateTimeIntervalType.Seconds;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    break;
                case GraphType.BiodataFigures:
                    y.Interval = 5;
                    Chart.Legends[0].LegendStyle = LegendStyle.Row;
                    Chart.Legends[0].Alignment = StringAlignment.Center;
                    Chart.Legends[0].Docking = Docking.Top;
                    break;
                case GraphType.Feeling:
                    y.IntervalAutoMode = IntervalAutoMode.FixedCount;
                    y.Interval = 1;
                    y.Title = "Time";
                    y.LabelStyle.Format = "{0} hr";
                    y.TitleForeColor = Color.Red;
                    y.MajorGrid.LineColor = Color.Red;
                    y.IntervalAutoMode = IntervalAutoMode.FixedCount;

                    Chart.ChartAreas[0].AxisY2 = new Axis(Chart.ChartAreas[0], AxisName.Y2)
                    {
                        Title = "Heart Rate",
                        IntervalType = DateTimeIntervalType.Number,
                        TitleForeColor = Color.Blue,
                        MajorGrid = { LineColor = Color.Blue },
                        IntervalAutoMode = IntervalAutoMode.FixedCount,
                        Interval = 5,
                        IntervalOffset = 40,
                        Maximum = 65
                    };
                    break;
                case GraphType.Distance:
                    y.IntervalAutoMode = IntervalAutoMode.FixedCount;
                    y.Interval = 2;
                    y.Title = "Distance";
                    y.LabelStyle.Format = "{0} km";
                    Chart.Legends[0].LegendStyle = LegendStyle.Row;
                    Chart.Legends[0].Alignment = StringAlignment.Center;
                    Chart.Legends[0].Docking = Docking.Top;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("grouping");
            }

            _area.AxisX = x;
            _area.AxisY = y;
        }

        private void InitializeSeries()
        {
            _series = AbstractSeriesCollection.GetCollection(_type);
        }

        private void Initialize()
        {
            var entries = _getEntries();
            var grouping = _getGrouping();

            InitializeSeries();

            InitializeData(entries, grouping);

            InitializeAxes(grouping);

            foreach (var s in _series.Series)
                Chart.Series.Add(s);
            Chart.Series.Add(_nonSportSeries);



            Chart.DoubleClick += (s, e) => _area.AxisX.ScaleView.ZoomReset(0);

            _area.AxisX.ScrollBar.Enabled = false;
            _area.AxisX.ScaleView.Zoomable = true;
            _area.AxisY.ScaleView.Zoomable = false;


            _area.CursorX.AutoScroll = true;
            _area.CursorY.AutoScroll = false;

            _area.CursorX.IsUserEnabled = true;
            _area.CursorY.IsUserEnabled = true;
            _area.CursorX.IsUserSelectionEnabled = true;

            _area.CursorX.LineWidth = 3;
            _area.CursorY.LineWidth = 3;

            _area.CursorX.LineColor = Color.DarkRed;
            _area.CursorY.LineColor = Color.DarkRed;

            _area.CursorX.SelectionColor = Color.LightYellow;

            _area.CursorX.Interval = _area.AxisX.Interval;
            _area.CursorY.Interval = _area.AxisY.Interval;

            Chart.MouseMove += (s, e) =>
                                   {
                                       var p = new Point(e.X, e.Y);
                                       _area.CursorX.SetCursorPixelPosition(p, true);
                                       _area.CursorY.SetCursorPixelPosition(p, true);
                                   };
        }

        private void InitializeData(Entry[] entries, Tuple<DateInterval, int> grouping)
        {
            foreach (var s in _series.Series)
                s.Points.Clear();
            _series.AddPoints(entries, grouping);

            _nonSportSeries.Points.Clear();
            Chart.Annotations.Clear();
            foreach (var e in _nonSportEntries(entries))
                e.AddEntryToChart(_area, _nonSportSeries, Chart.Annotations, _series.MinimumY);
        }

        public void UpdateStatistics()
        {
            var entries = _getEntries();
            var grouping = _getGrouping();

            InitializeData(entries, grouping);
            InitializeAxes(grouping);
        }

        #endregion
    }
}
