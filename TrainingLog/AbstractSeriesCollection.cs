using System;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;

namespace TrainingLog
{
    public abstract class AbstractSeriesCollection
    {
        public abstract double MinimumY { get; }

        public abstract double MaximumY { get; }

        public abstract void AddPoints(Entry[] entries);

        public abstract Series[] Series { get; }

        public static AbstractSeriesCollection GetCollection(Graph.GraphType type)
        {
            switch (type)
            {
                case Graph.GraphType.TrainingDurationZoneData:
                    return new ZoneDataAbstractSeriesCollection();
                case Graph.GraphType.BiodataFigures:
                    return new BiodataFiguresAbstractSeriesCollection();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
