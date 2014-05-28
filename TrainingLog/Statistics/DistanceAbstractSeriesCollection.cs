using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using Microsoft.VisualBasic;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class DistanceAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override Series[] Series
        {
            get { return _series.ToArray(); }
        }

        public override double MinimumY
        {
            get { throw new Exception(); }
        }

        public override double MaximumY
        {
            // +9 to have at least 5 difference from max to top
            get { var m = ((int)_maxY + 9) / 5 * 5; return m; }
        }

        #endregion

        #region Private Fields

        private readonly List<Series> _series = new List<Series>();

        private double _maxY = double.MinValue;

        private const int RunningSeries = 0;

        private const int CyclingSeries = 1;

        #endregion

        #region Constructor

        public DistanceAbstractSeriesCollection()
        {
            _series.AddRange(new[]
                                 {
                                     new Series("Running")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.StackedColumn,
                                             Color = Color.RoyalBlue
                                         },
                                     new Series("Cycling")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.StackedColumn,
                                             Color = Color.Green,
                                         }
                                 });
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries, Tuple<DateInterval, int> grouping)
        {
            if (entries.Length == 0)
                return;

            var intervalStart = GetStartOfInterval(entries[0].Date ?? DateTime.MaxValue, grouping.Item1, grouping.Item2);
            var intervalEnd = GetEndOfInterval(intervalStart, grouping.Item1, grouping.Item2);

            var points = new List<Tuple<DateTime, double, double>> { new Tuple<DateTime, double, double>(intervalStart, 0, 0) };

            foreach (var e in entries.Cast<TrainingEntry>())
            {
                var last = points.LastOrDefault();
                if (last != null && (e.Date ?? DateTime.MinValue) < last.Item1)
                    throw new Exception("entries are not ordered");

                // are we still in same interval?
                if (last != null && e.Date < intervalEnd)
                {
                    // add to last tuple
                    points[points.Count - 1] = new Tuple<DateTime, double, double>(last.Item1,
                        last.Item2 + (e.Sport.Equals(Common.Sport.Running) ? e.DistanceKm : 0),
                        last.Item3 + (e.Sport.Equals(Common.Sport.Cycling) ? e.DistanceKm : 0));
                }
                else
                {
                    // update end of interval
                    intervalStart = intervalEnd;
                    intervalEnd = GetEndOfInterval(intervalEnd, grouping.Item1, grouping.Item2);

                    while (e.Date >= intervalEnd)
                    {
                        // add empty tuple
                        points.Add(new Tuple<DateTime, double, double>(intervalStart, 0, 0));

                        intervalStart = intervalEnd;
                        intervalEnd = GetEndOfInterval(intervalEnd, grouping.Item1, grouping.Item2);
                    }

                    // add new tuple
                    points.Add(new Tuple<DateTime, double, double>(intervalStart, 
                        e.Sport.Equals(Common.Sport.Running) ? e.DistanceKm : 0,
                        e.Sport.Equals(Common.Sport.Cycling) ? e.DistanceKm : 0));
                }
            }

            foreach (var t in points)
            {
                var p1 = new DataPoint();
                var p2 = new DataPoint();
                p1.SetValueXY(t.Item1, t.Item2);
                p2.SetValueXY(t.Item1, t.Item3);
                _series[0].Points.Add(p1);
                _series[1].Points.Add(p2);
            }

            if (_series[0].Points.Count == 1)
                _series[0].Points.Add(_series[0].Points[0]);
            if (_series[1].Points.Count == 1)
                _series[1].Points.Add(_series[1].Points[0]);

            // find max
            _maxY = double.MinValue;
            for (var i = 0; i < _series[1].Points.Count; i++)
            {
                var max = _series[RunningSeries].Points[i].YValues[0] + _series[CyclingSeries].Points[i].YValues[0];

                if (max > _maxY)
                    _maxY = max;
            }
        }

        #endregion
    }
}
