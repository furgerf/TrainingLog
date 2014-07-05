using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Charts
{
    public class ZoneDataAreaChart : AbstractChart
    {
        #region Constructor

        public ZoneDataAreaChart(Func<TrainingEntry[]> getEntries)
            : base(() => getEntries().Cast<Entry>().ToArray(), true)
        {
            Titles.Add("Zone Data Area");

            GetGroupingChanged += AddEntries;
        }

        #endregion

        #region Main Methods

        protected override void Initialize()
        {
            ChartAreas.Add(new ChartArea("ZoneData"));

            // prepare seriesnew[]
            Series.Add(new Series("Zone 5")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Time,
                ChartType = SeriesChartType.SplineArea,
                Color = ZoneDataBox.Zone5Color,
                IsVisibleInLegend = false
            });
            Series.Add(new Series("Zone 4")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Time,
                ChartType = SeriesChartType.SplineArea,
                Color = ZoneDataBox.Zone4Color,
                IsVisibleInLegend = false
            });
            Series.Add(new Series("Zone 3")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Time,
                ChartType = SeriesChartType.SplineArea,
                Color = ZoneDataBox.Zone3Color,
                IsVisibleInLegend = false
            });
            Series.Add(new Series("Zone 2")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Time,
                ChartType = SeriesChartType.SplineArea,
                Color = ZoneDataBox.Zone2Color,
                IsVisibleInLegend = false
            });
            Series.Add(new Series("Zone 1")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Time,
                ChartType = SeriesChartType.SplineArea,
                Color = ZoneDataBox.Zone1Color,
                IsVisibleInLegend = false
            });

            // prepare axes
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;

            // x
            x.IntervalAutoMode = IntervalAutoMode.FixedCount;
            x.IntervalOffsetType = DateTimeIntervalType.Days;

            // y
            y.IntervalType = DateTimeIntervalType.Minutes;
            y.IntervalAutoMode = IntervalAutoMode.VariableCount;
            y.LabelStyle.Format = "HH:mm";
        }

        protected override void AddEntries()
        {
            if (GetGrouping == null)
                return;

            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            // update axis
            var x = ChartAreas[0].AxisX;
            x.IntervalOffset = 0;

            switch (GetGrouping())
            {
                case GroupingType.OneDay:
                    x.IntervalType = DateTimeIntervalType.Days;
                    x.Interval = 1;
                    break;
                case GroupingType.OneWeek:
                    x.IntervalType = DateTimeIntervalType.Weeks;
                    x.IntervalOffset = -6;
                    x.Interval = 1;
                    break;
                case GroupingType.TwoWeeks:
                    x.IntervalType = DateTimeIntervalType.Weeks;
                    x.IntervalOffset = -6;
                    x.Interval = 2;
                    break;
                case GroupingType.OneMonth:
                    x.IntervalType = DateTimeIntervalType.Months;
                    x.Interval = 1;
                    break;
                case GroupingType.ThreeMonths:
                    x.IntervalType = DateTimeIntervalType.Months;
                    x.Interval = 3;
                    break;
                case GroupingType.SixMonths:
                    x.IntervalType = DateTimeIntervalType.Months;
                    x.Interval = 6;
                    break;
                case GroupingType.OneYear:
                    x.IntervalType = DateTimeIntervalType.Years;
                    x.Interval = 1;
                    break;
                case GroupingType.Count:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //x.Interval = grouping.Item2;

            //if (grouping.Item1 == DateInterval.Day)
            //    if (grouping.Item2 == 5 || grouping.Item2 == 7)
            //        x.IntervalOffset = -1;
            //    else if (grouping.Item2 == 14)
            //        x.IntervalOffset = -9;
            //    else if (grouping.Item2 == 21)
            //        x.IntervalOffset = -12;

            // add entries
            var entries = GetEntries();

            if (entries.Length == 0)
                return;

            var intervalStart = GetStartOfInterval(entries[0].Date ?? DateTime.MaxValue);
            var intervalEnd = GetEndOfInterval(intervalStart);
            var previousIntervalStart = intervalStart.AddSeconds(-1);

            var points = new List<Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, string>>
                             {
                                 new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, string>(intervalStart, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, "")
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
                    points[points.Count - 1] = new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, string>(last.Item1,
                        last.Item2.Add(e.HrZones.Value.Zone1),
                        last.Item3.Add(e.HrZones.Value.Zone2),
                        last.Item4.Add(e.HrZones.Value.Zone3),
                        last.Item5.Add(e.HrZones.Value.Zone4),
                        last.Item6.Add(e.HrZones.Value.Zone5),
                        last.Item7 + (last.Item7 != "" ? "\n" : "") + e);
                }
                else
                {
                    // update end of interval
                    intervalStart = intervalEnd;
                    intervalEnd = GetEndOfInterval(intervalEnd);

                    while (e.Date >= intervalEnd)
                    {
                        // add empty tuple
                        points.Add(new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, string>(intervalStart, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, ""));

                        intervalStart = intervalEnd;
                        intervalEnd = GetEndOfInterval(intervalEnd);
                    }

                    // add new tuple
                    points.Add(new Tuple<DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, string>(intervalStart,
                            DateTime.MinValue.Add(e.HrZones.Value.Zone1),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone2),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone3),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone4),
                            DateTime.MinValue.Add(e.HrZones.Value.Zone5),
                            e.ToString()));
                }
            }

            // add zero-point before
            var zeroPoint = new DataPoint(previousIntervalStart.ToOADate(), 0);
            foreach (var s in Series.Where(s => s.Name.StartsWith("Zone ")))
                s.Points.Add(zeroPoint);

            var max = double.MinValue;
            foreach (var t in points)
            {
                var ts = new[] { t.Item2, t.Item3, t.Item4, t.Item5, t.Item6 };

                var sum = 0.0;
                for (var i = 0; i < 5; i++)
                {
                    if (ts[i].DayOfYear > 1)
                    {
                        sum += ts[i].DayOfYear - 1;
                        ts[i] = ts[i].AddDays(-ts[i].DayOfYear + 1);
                    }
                    sum += ts[i].ToOADate();
                    Series["Zone " + (i + 1)].Points.Add(new DataPoint(t.Item1.ToOADate(), sum) { ToolTip = t.Item7 });
                }
                if (sum > max)
                    max = sum;
            }
            var foo = DateTime.FromOADate(max);
            foo = foo.AddHours(foo.Minute > 30 ? 2 : 1);
            foo = foo.AddMinutes(-foo.Minute);
            foo = foo.AddSeconds(-foo.Second);

            ChartAreas[0].AxisY.Maximum = foo.ToOADate();

            // add zero-point after
            zeroPoint = new DataPoint(intervalStart.AddSeconds(1).ToOADate(), 0);
            foreach (var s in Series.Where(s => s.Name.StartsWith("Zone ")))
                s.Points.Add(zeroPoint.Clone());
        }

        #endregion
    }
}
