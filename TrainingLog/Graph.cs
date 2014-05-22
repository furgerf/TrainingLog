using System;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;

namespace TrainingLog
{
    public class Graph
    {
        #region Enums, Delegates

        public enum GraphType { TrainingDurationZoneData }

        public delegate DataPoint[] DataPointFromEntry(Entry[] entries);

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

        public Graph(GraphType type, Entry[] entries, DataPointFromEntry dpfe)
        {
            _type = type;

            Chart.ChartAreas.Add(_area);
            Chart.Legends.Add(_legend);

            InitializeGraph(entries, dpfe);

            foreach (var s in _series.Series)
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
                    y.IntervalType = DateTimeIntervalType.Minutes;
                    y.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    y.LabelStyle.Format = "HH:mm";
                    y.Title = "Duration";
                    y.Interval = 5;

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
            _series = AbstractSeriesCollection.GetCollection(_type);
        }

        private void InitializeGraph(Entry[] entries, DataPointFromEntry dpfe)
        {
            InitializeSeries();

            InitializeData(entries, dpfe);

            InitializeAxes();
        }

        private void InitializeData(Entry[] entries, DataPointFromEntry dpfe)
        {
            _series.AddPoints(dpfe(entries));
            //foreach (var e in entries)
            //{
            //    //if (e.Date.Equals(new DateTime(2014, 4, 21)))
            //    //{
            //    //    var dp = dpfe(e);
            //    //}
            //    _series.AddPoints(dpfe(e));
            //}

            //for (var i = 0; i < entries.Length; i++)
            //{
            //    var dp = dpfe(entries[i]);

            //    for (var j = 0; j < dp.Length; j++)
            //    {
            //        var add = true;
            //        foreach (var p in _series[j].Points)
            //            if (p.XValue == dp[j].XValue)
            //            {
            //                // TODO: Add new series if neccessary and add points there instead of to current series

            //                //var prevY = p.YValues;
            //                //var newY = new double[prevY.Length + dp[j].YValues.Length];
            //                //Array.Copy(prevY, newY, prevY.Length);
            //                //Array.Copy(dp[j].YValues, 0, newY, prevY.Length, dp[j].YValues.Length);

            //                //p.YValues = newY;
            //                //add = false;
            //                //break;
            //            }

            //        if (add)
            //            _series[j].Points.Add(dp[j]);
            //    }
            //}
        }

        #endregion
    }
}
