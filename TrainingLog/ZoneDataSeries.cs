using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrainingLog
{
    public struct ZoneDataSeries
    {
        public readonly Series[] Series;

        public ZoneDataSeries(Series[] series)
        {
            if (series.Length != 5) throw new ArgumentException();

            Series = series;
        }
    }
}
