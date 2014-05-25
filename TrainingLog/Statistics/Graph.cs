using System;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class Graph
    {
        #region Enums, Delegates

        public enum GraphType { ZoneData, ZoneDataArea, BiodataFigures }

        #endregion

        #region Public Fields

        public string Title
        {
            get { return _title; }
            set { _title = value; if (Chart.Titles.Count > 0) Chart.Titles.RemoveAt(0); Chart.Titles.Add(_title); }
        }

        #endregion

        #region Private Fields

        private readonly ChartArea _area = new ChartArea();

        public readonly Chart Chart = new Chart();

        private readonly Legend _legend = new Legend();
        private string _title;

        private AbstractSeriesCollection _series;

        private readonly GraphType _type;

        #endregion

        #region Constructor

        public Graph(GraphType type, Entry[] entries)
        {
            _type = type;

            Chart.ChartAreas.Add(_area);
            Chart.Legends.Add(_legend);

            InitializeGraph(entries);
        }

        #endregion

        #region Main Methods

        private void InitializeAxes()
        {
            var x = new Axis(_area, AxisName.X);
            var y = new Axis(_area, AxisName.Y);

            switch (_type)
            {
                case GraphType.ZoneData:
                    // x
                    x.IntervalType = DateTimeIntervalType.Days;
                    x.IntervalAutoMode = IntervalAutoMode.FixedCount;
                    x.Title = "Date";
                    x.Interval = 1;

                    // y
                    y.IntervalType = DateTimeIntervalType.Seconds;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    //y.Interval = 5;
                    y.Maximum = _series.MaximumY;
                    break;
                case GraphType.ZoneDataArea:
                    // x
                    x.IntervalType = DateTimeIntervalType.Days;
                    x.IntervalAutoMode = IntervalAutoMode.FixedCount;
                    x.Title = "Date";
                    x.Interval = 1;

                    // y
                    y.IntervalType = DateTimeIntervalType.Seconds;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    //y.Interval = 5;
                    y.Maximum = _series.MaximumY;
                    break;
                case GraphType.BiodataFigures:
                    // x
                    x.IntervalType = DateTimeIntervalType.Days;
                    x.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    x.Title = "Date";
                    //x.Interval = 1;

                    // y
                    y.Interval = 5;
                    y.Minimum = _series.MinimumY;
                    y.Maximum = _series.MaximumY;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            _area.AxisX = x;
            _area.AxisY = y;
        }

        private void InitializeSeries()
        {
            _series = AbstractSeriesCollection.GetCollection(_type);
        }

        private void InitializeGraph(Entry[] entries)
        {
            InitializeSeries();

            InitializeData(entries);

            InitializeAxes();
        }

        private void InitializeData(Entry[] entries)
        {
            _series.AddPoints(entries);
            foreach (var s in _series.Series.Where(s => s.Points.Count > 0))
                Chart.Series.Add(s);
        }

        #endregion
    }
}
