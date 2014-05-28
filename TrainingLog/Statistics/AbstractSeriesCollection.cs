using System;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public abstract class AbstractSeriesCollection
    {
        public abstract double MinimumY { get; }

        public abstract double MaximumY { get; }

        public abstract void AddPoints(Entry[] entries, Tuple<DateInterval,int> grouping);

        public abstract Series[] Series { get; }

        public static AbstractSeriesCollection GetCollection(Graph.GraphType type)
        {
            switch (type)
            {
                case Graph.GraphType.ZoneData:
                    return new ZoneDataAbstractSeriesCollection();
                case Graph.GraphType.ZoneDataArea:
                    return new ZoneDataAreaAbstractSeriesCollection();
                case Graph.GraphType.BiodataFigures:
                    return new BiodataFiguresAbstractSeriesCollection();
                case Graph.GraphType.Distance:
                    return new DistanceAbstractSeriesCollection();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        protected DateTime GetEndOfInterval(DateTime now, DateInterval interval, int count)
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

        protected DateTime GetStartOfInterval(DateTime now, DateInterval interval, int count)
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
    }
}
