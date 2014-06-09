using System;
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
            Distance
        }

        #endregion

        #region Public Fields

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (Chart.Titles.Count > 0) Chart.Titles.RemoveAt(0);
                Chart.Titles.Add(_title);
            }
        }

        #endregion

        #region Private Fields

        private readonly ChartArea _area = new ChartArea();

        public readonly Chart Chart = new Chart();

        private readonly Legend _legend = new Legend();

        private string _title;

        private AbstractSeriesCollection _series;

        private readonly GraphType _type;

        private readonly Func<Tuple<DateInterval, int>> _getGrouping;

        private readonly Func<Entry[]> _getEntries;

        #endregion

        #region Constructor

        public Graph(GraphType type, Func<Entry[]> entries, Func<Tuple<DateInterval, int>> grouping)
        {
            _getGrouping = grouping;
            _type = type;
            _getEntries = entries;

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
            switch (_type)
            {
                case GraphType.ZoneData:
                    y.IntervalType = DateTimeIntervalType.Seconds;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    y.Minimum = _series.MinimumY;
                    y.Maximum = _series.MaximumY;
                    break;
                case GraphType.ZoneDataArea:
                    y.IntervalType = DateTimeIntervalType.Seconds;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    y.Minimum = _series.MinimumY;
                    y.Maximum = _series.MaximumY;
                    break;
                case GraphType.BiodataFigures:
                    y.Interval = 5;
                    y.Minimum = _series.MinimumY;
                    y.Maximum = _series.MaximumY;
                    break;
                case GraphType.Distance:
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.Title = "Distance";
                    y.Maximum = _series.MaximumY;
                    y.LabelStyle.Format = "{0} km";
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
        }

        private void InitializeData(Entry[] entries, Tuple<DateInterval, int> grouping)
        {
            foreach (var s in _series.Series)
                s.Points.Clear();

            _series.AddPoints(entries, grouping);
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
