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
        
        public DistanceChart(Func<TrainingEntry[]> getEntries, Func<DateTime, DateTime, NonSportEntry[]> getNonSportEntries, Func<GroupingType> grouping) : base(() => getEntries().Cast<Entry>().ToArray(), getNonSportEntries, grouping, true)
        {
            Titles.Add("Distance");
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
            Series.Add(new Series(NonSportSeriesString)
                           {
                               IsVisibleInLegend = false
                           });

            // prepare axes
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;

            // x
            x.Title = "Date";
            x.IntervalAutoMode = IntervalAutoMode.FixedCount;
            switch (GetGrouping())
            {
                case GroupingType.OneDay:
                    x.IntervalType = DateTimeIntervalType.Days;
                    x.Interval = 1;
                    break;
                case GroupingType.OneWeek:
                    x.IntervalType = DateTimeIntervalType.Weeks;
                    x.Interval = 1;
                    break;
                case GroupingType.TwoWeeks:
                    x.IntervalType = DateTimeIntervalType.Weeks;
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

            // y
            y.IntervalAutoMode = IntervalAutoMode.VariableCount;
            y.Title = "Distance";
            y.LabelStyle.Format = "{0} km";

            // fill points
            AddEntries();
            AddNonSportEntries();
        }

        protected override void AddEntries()
        {
            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

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

        //protected override void AddNonSportEntries()
        //{
        //    var minX = double.MaxValue;
        //    var maxX = double.MinValue;
        //    foreach (var s in Series.Where(s => s.Points.Count > 0 && s.Name != "Non-Sport Entries"))
        //    {
        //        if (s.Points[0].XValue < minX)
        //            minX = s.Points[0].XValue;
        //        if (s.Points[0].XValue > maxX)
        //            maxX = s.Points[0].XValue;
        //    }

        //    foreach (var e in NonSportEntries(DateTime.FromOADate(minX), DateTime.FromOADate(maxX)))
        //        e.AddEntryToChart(ChartAreas[0], Series["Non-Sport Entries"], Annotations);
        //}

        #endregion
    }
}
