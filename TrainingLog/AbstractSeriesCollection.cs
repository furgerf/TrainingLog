using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainingLog
{
    public abstract class AbstractSeriesCollection
    {
        //public abstract void AddPoint(DataPoint point, int index = 0);
        
        //public void AddPoints(DataPoint[] points)
        //{
        //    for (var i = 0; i < points.Length; i++)
        //        AddPoint(points[i], i);
        //}

        public abstract void AddPoints(DataPoint[] points);

        public abstract Series[] Series { get; }

        public static AbstractSeriesCollection GetCollection(Graph.GraphType type)
        {
            switch (type)
            {
                case Graph.GraphType.TrainingDurationZoneData:
                    return new ZoneDataAbstractSeriesCollection();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
