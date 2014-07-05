using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;

namespace TrainingLog.Charts
{
    public class DistanceChart : AbstractChart
    {
        #region Private Fields



        #endregion

        #region Constructor
        
        public DistanceChart(Func<TrainingEntry[]> getEntries) : base(() => getEntries().Cast<Entry>().ToArray(), true)
        {
            Titles.Add("Distance");

            GetGroupingChanged += AddEntries;
        }

        #endregion

        #region Main Methods

        protected override void Initialize()
        {
            ChartAreas.Add(new ChartArea("Distance"));
            Legends.Add(new Legend
            {
                LegendStyle = LegendStyle.Row,
                Alignment = StringAlignment.Center,
                Docking = Docking.Top
            });

            // prepare series
            Series.Add(new Series("Running")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.StackedColumn,
                               Color = Color.RoyalBlue
                           });
            Series.Add(new Series("Cycling")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.StackedColumn,
                               Color = Color.Green,
                           });

            // prepare axes
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;

            // x
            x.IntervalAutoMode = IntervalAutoMode.FixedCount;
            x.IntervalOffsetType = DateTimeIntervalType.Days;

            // y
            y.IntervalAutoMode = IntervalAutoMode.VariableCount;
            y.LabelStyle.Format = "{0} km";
        }

        protected override void AddEntries()
        {
            if (GetGrouping == null)
                return;

            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            // set axis
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
                    intervalEnd = GetEndOfInterval(intervalEnd);

                    while (e.Date >= intervalEnd)
                    {
                        // add empty tuple
                        points.Add(new Tuple<DateTime, double, double>(intervalStart, 0, 0));

                        intervalStart = intervalEnd;
                        intervalEnd = GetEndOfInterval(intervalEnd);
                    }

                    // add new tuple
                    points.Add(new Tuple<DateTime, double, double>(intervalStart,
                        e.Sport.Equals(Common.Sport.Running) ? e.DistanceKm : 0,
                        e.Sport.Equals(Common.Sport.Cycling) ? e.DistanceKm : 0));
                }
            }

            foreach (var t in points)
            {
                var p1 = new DataPoint(t.Item1.ToOADate(), t.Item2);
                var p2 = new DataPoint(t.Item1.ToOADate(), t.Item3);
                Series["Running"].Points.Add(p1);
                Series["Cycling"].Points.Add(p2);
            }

            if (Series["Running"].Points.Count == 1)
                Series["Running"].Points.Add(Series["Running"].Points[0]);
            if (Series["Cycling"].Points.Count == 1)
                Series["Cycling"].Points.Add(Series["Cycling"].Points[0]);
        }

        #endregion
    }
}
