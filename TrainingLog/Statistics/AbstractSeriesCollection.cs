using System;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public abstract class AbstractSeriesCollection
    {
        #region Properties

        public abstract double MinimumY { get; }

        public abstract double MaximumY { get; }
       
        public abstract Series[] Series { get; }

        #endregion

        #region Methods

        public abstract void AddPoints(Entry[] entries, Tuple<DateInterval, int> grouping);

        public static AbstractSeriesCollection GetCollection(Graph.GraphType type)
        {
            switch (type)
            {
                case Graph.GraphType.ZoneData:
                    return new ZoneDataSeriesCollection();
                case Graph.GraphType.ZoneDataArea:
                    return new ZoneDataAreaSeriesCollection();
                case Graph.GraphType.BiodataFigures:
                    return new BiodataFiguresSeriesCollection();
                case Graph.GraphType.Distance:
                    return new DistanceSeriesCollection();
                case Graph.GraphType.Feeling:
                    return new FeelingSeriesCollection();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        protected static DateTime GetEndOfInterval(DateTime now, DateInterval interval, int count)
        {
            switch (interval)
            {
                case DateInterval.Year:
                    now = now.AddYears(count);
                    return now.AddMonths(1 - now.Month).AddDays(1 - now.Day);
                case DateInterval.Month:
                    now = now.AddMonths(count);
                    return now.AddDays(1 - now.Day);
                case DateInterval.Day:
                    return count % 7 == 0 ? now.AddDays(count - (int)now.DayOfWeek + 1) : now.AddDays(count);
                default:
                    throw new ArgumentOutOfRangeException("interval");
            }
        }

        protected static DateTime GetStartOfInterval(DateTime now, DateInterval interval, int count)
        {
            switch (interval)
            {
                case DateInterval.Year:
                    return now.AddMonths(1 - now.Month).AddDays(1 - now.Day);
                case DateInterval.Month:
                    return now.AddDays(1 - now.Day);
                case DateInterval.Day:
                    return count % 7 == 0 ? now.AddDays(1 - (int)now.DayOfWeek) : now;
                default:
                    throw new ArgumentOutOfRangeException("interval");
            }
        }

        #endregion
    }
}
