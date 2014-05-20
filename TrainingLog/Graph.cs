using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;

namespace TrainingLog
{
    public class Graph
    {
        #region Enums, Delegates

        public enum GraphType { TrainingDurationZoneData }

        public delegate DataPoint[] DataPointFromEntry(Entry entry);

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

        private readonly List<Series> _series = new List<Series>();

        private readonly GraphType _type;

        #endregion

        #region Constructor

        public Graph(GraphType type, Entry[] entries, DataPointFromEntry dpfe)
        {
            _type = type;

            Chart.ChartAreas.Add(_area);
            Chart.Legends.Add(_legend);

            InitializeGraph(entries, dpfe);

            foreach (var s in _series)
                Chart.Series.Add(s);
        }

        #endregion

        #region Main Methods

        private void InitializeAxes()
        {
            var x = new Axis(_area, AxisName.X);
            var y = new Axis(_area, AxisName.Y);

            switch (_type)
            {
                case GraphType.TrainingDurationZoneData:
                    // x
                    x.IntervalType = DateTimeIntervalType.Days;
                    x.IntervalAutoMode = IntervalAutoMode.FixedCount;
                    x.Title = "Date";
                    x.Interval = 1;

                    // y
                    y.IntervalType = DateTimeIntervalType.Hours;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    y.Interval = 0.5;

                    //var maxDur = entries.Length == 0 ? TimeSpan.MaxValue : ((TrainingEntry)entries.Aggregate((curmax, foo) => (curmax == null) || (((TrainingEntry)foo).Duration ?? TimeSpan.MaxValue) > ((TrainingEntry)curmax).Duration ? foo : curmax)).Duration ?? TimeSpan.MinValue;
                    //// "round up" to next half hour
                    //maxDur = maxDur.Minutes >= 30
                    //             ? maxDur.Add(new TimeSpan(0, 60 - maxDur.Minutes, 0))
                    //             : maxDur.Add(new TimeSpan(0, 30 - maxDur.Minutes, 0));

                    //var maxDur = double.MinValue;

                    //foreach (var s in _series)
                    //    foreach (var p in s.Points)
                    //        foreach (var yy in p.YValues)
                    //            if (yy > maxDur)
                    //                maxDur = yy;

                    //var date = DateTime.FromOADate(maxDur);

                    y.Minimum = 0;
                    //y.Maximum = maxDur;

                    //y.Maximum = new DateTime(1, 1, 1, maxDur.Hours, maxDur.Minutes, 0).ToOADate();

                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }

            _area.AxisX = x;
            _area.AxisY = y;
        }

        private void InitializeSeries()
        {
            switch (_type)
            {
                case GraphType.TrainingDurationZoneData:
                    _series.Add(new Series("Zone 1")
                    {
                        XValueType = ChartValueType.Date,
                        YValueType = ChartValueType.Time,
                        ChartType = SeriesChartType.StackedColumn,
                        Color = ZoneDataBox.Zone1Color,
                        IsVisibleInLegend = false
                    });
                    _series.Add(new Series("Zone 2")
                    {
                        XValueType = ChartValueType.Date,
                        YValueType = ChartValueType.Time,
                        ChartType = SeriesChartType.StackedColumn,
                        Color = ZoneDataBox.Zone2Color,
                        IsVisibleInLegend = false
                    });
                    _series.Add(new Series("Zone 3")
                    {
                        XValueType = ChartValueType.Date,
                        YValueType = ChartValueType.Time,
                        ChartType = SeriesChartType.StackedColumn,
                        Color = ZoneDataBox.Zone3Color,
                        IsVisibleInLegend = false
                    });
                    _series.Add(new Series("Zone 4")
                    {
                        XValueType = ChartValueType.Date,
                        YValueType = ChartValueType.Time,
                        ChartType = SeriesChartType.StackedColumn,
                        Color = ZoneDataBox.Zone4Color,
                        IsVisibleInLegend = false
                    });
                    _series.Add(new Series("Zone 5")
                    {
                        XValueType = ChartValueType.Date,
                        YValueType = ChartValueType.Time,
                        ChartType = SeriesChartType.StackedColumn,
                        Color = ZoneDataBox.Zone5Color,
                        IsVisibleInLegend = false
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void InitializeGraph(Entry[] entries, DataPointFromEntry dpfe)
        {
            InitializeSeries();

            InitializeData(entries, dpfe);

            InitializeAxes();
        }

        private void InitializeData(Entry[] entries, DataPointFromEntry dpfe)
        {
            for (var i = 0; i < entries.Length; i++)
            {
                var dp = dpfe(entries[i]);
                for (var j = 0; j < dp.Length; j++)
                    _series[j].Points.Add(dp[j]);
                // TODO: after adding point, check whether x already exists. if yes, increment all y's
            }
        }

        #endregion
    }
}
