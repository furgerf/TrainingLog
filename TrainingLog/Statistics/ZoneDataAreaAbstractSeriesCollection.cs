using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class ZoneDataAreaAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override double MinimumY
        {
            get { return 0; }
        }

        public override double MaximumY
        {
            get
            {
                if (Series[0].Points.Count == 0)
                    return 100;

                var dt = DateTime.FromOADate(_maxY).Add(new TimeSpan(0, 30, 0));

                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute / 30 * 30, 0).ToOADate();
            }
        }

        public override Series[] Series
        {
            get
            {
                return _series.Series;
            }
        }

        #endregion

        #region Private Fields

        private double _maxY = double.MinValue;

        private readonly ZoneDataSeries _series;

        #endregion

        #region Constructor

        public ZoneDataAreaAbstractSeriesCollection()
        {
            _series = new ZoneDataSeries(new[]
                                   {
                                       new Series("Zone 5")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone5Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 4")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone4Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 3")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone3Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 2")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone2Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 1")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone1Color,
                                               IsVisibleInLegend = false
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
            var previousIntervalStart = intervalStart.AddSeconds(-1);

            var points = new List<Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime>>
                             {
                                 new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime>(intervalStart, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue)
                             };

            foreach (var e in entries.Cast<TrainingEntry>())
            {
                var last = points.LastOrDefault();
                if (last != null && (e.Date ?? DateTime.MinValue) < last.Item1)
                    throw new Exception("entries are not ordered");

                if (e.HrZones == null)
                    throw new Exception("entry has no zonedata");

                // are we still in same interval?
                if (last != null && e.Date < intervalEnd)
                {
                    // add to last tuple
                    points[points.Count - 1] = new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime>(last.Item1,
                        last.Item2.Add(e.HrZones.Value.Zone1),
                        last.Item3.Add(e.HrZones.Value.Zone2),
                        last.Item4.Add(e.HrZones.Value.Zone3),
                        last.Item5.Add(e.HrZones.Value.Zone4),
                        last.Item6.Add(e.HrZones.Value.Zone5));
                }
                else
                {
                    // update end of interval
                    intervalStart = intervalEnd;
                    intervalEnd = GetEndOfInterval(intervalEnd, grouping.Item1, grouping.Item2);

                    while (e.Date >= intervalEnd)
                    {
                        // add empty tuple
                        points.Add(new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime>(intervalStart, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue));

                        intervalStart = intervalEnd;
                        intervalEnd = GetEndOfInterval(intervalEnd, grouping.Item1, grouping.Item2);
                    }

                    // add new tuple
                    points.Add(new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime>(intervalStart,
                            DateTime.MinValue.Add(e.HrZones.Value.Zone1),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone2),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone3),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone4),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone5)));
                }
            }

            // add zero-point before
            var zeroPoint = new DataPoint();
            zeroPoint.SetValueXY(previousIntervalStart, 0);
            foreach (var s in _series.Series)
                s.Points.Add(zeroPoint);

            foreach (var t in points)
            {
                var ts = new[] {t.Item2, t.Item3, t.Item4, t.Item5, t.Item6};

                var sum = 0.0;
                for (var i = 0; i < 5; i++)
                {
                    while (ts[i].DayOfYear > 1)
                    {
                        sum++;
                        ts[i] = ts[i].AddDays(-1);
                    }
                    sum += ts[i].ToOADate();
                    var dp = new DataPoint();
                    dp.SetValueXY(t.Item1, sum);
                    _series.Series[4 - i].Points.Add(dp);
                }
            }

            // add zero-point after
            zeroPoint = new DataPoint();
            zeroPoint.SetValueXY(intervalStart.AddSeconds(1), 0);
            foreach (var s in _series.Series)
                s.Points.Add(zeroPoint.Clone());

            // find max
            for (var i = 0; i < _series.Series[0].Points.Count; i++)
            {
                foreach (var s in _series.Series.Where(s => s.Points[i].YValues[0] > _maxY))
                    _maxY = s.Points[i].YValues[0];
            }
        }

        #endregion
    }
}
