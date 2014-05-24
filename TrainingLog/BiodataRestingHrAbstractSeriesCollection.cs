using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using TrainingLog.Entries;

namespace TrainingLog
{
    public class BiodataRestingHrAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override Series[] Series
        {
            get { return _series.ToArray(); }
        }

        public override double MinimumY
        {
            // -4 because /5 rounds down
            get { var m = (_minHr - 4) / 5 * 5; return m; }
        }

        public override double MaximumY
        {
            // +9 to have at least 5 difference from max to top
            get { var m = (_maxHr + 9) / 5 * 5; return m; }
        }

        #endregion

        #region Private Fields

        private readonly List<Series> _series = new List<Series>();

        private int _minHr = int.MaxValue;

        private int _maxHr = int.MinValue;

        private const int RestingHrSeries = 0;

        private const int AverageRestingHrSeries = 1;

        private Series GetNewHrSeries
        {
            get
            {
                return new Series("Resting Heart Rate")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Int32,
                               ChartType = SeriesChartType.Spline,
                               BorderWidth = 10,
                               //IsVisibleInLegend = false
                           };
            }
        }

        #endregion

        #region Constructor

        public BiodataRestingHrAbstractSeriesCollection()
        {
            _series.Add(GetNewHrSeries);
            _series.Add(new Series("Average Resting Heart Rate")
                            {
                                XValueType = ChartValueType.Date,
                                YValueType = ChartValueType.Double,
                                ChartType = SeriesChartType.Spline,
                                BorderWidth = 3,
                                Label = "Average",
                                //IsVisibleInLegend = false
                            });
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries)
        {
            foreach (var e in entries)
            {
                var rhr = ((BiodataEntry) e).RestingHeartRate ?? int.MaxValue;
                if (rhr < _minHr)
                    _minHr = rhr;
                if (rhr > _maxHr)
                    _maxHr = rhr;

                var dp = new DataPoint();
                dp.SetValueXY(e.Date ?? DateTime.MaxValue, rhr);
                _series[RestingHrSeries].Points.Add(dp);
            }

            _series[AverageRestingHrSeries].Points.Clear();
            var avg = ((double)entries.Sum(e => ((BiodataEntry)e).RestingHeartRate)) / entries.Length;
            var minAvg = new DataPoint();
            minAvg.SetValueXY(entries[0].Date ?? DateTime.MinValue, avg);
            var maxAvg= new DataPoint();
            maxAvg.SetValueXY(entries[entries.Length - 1].Date ?? DateTime.MinValue, avg);
            _series[AverageRestingHrSeries].Points.Add(minAvg);
            _series[AverageRestingHrSeries].Points.Add(maxAvg);
        }

        #endregion

    }
}
