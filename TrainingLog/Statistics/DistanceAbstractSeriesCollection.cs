using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class DistanceAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override Series[] Series
        {
            get { return _series.ToArray(); }
        }

        public override double MinimumY
        {
            get { throw new Exception(); }
        }

        public override double MaximumY
        {
            // +9 to have at least 5 difference from max to top
            get { var m = ((int)_maxY + 9) / 5 * 5; return m; }
        }

        #endregion

        #region Private Fields

        private readonly List<Series> _series = new List<Series>();

        private double _maxY = double.MinValue;

        private const int CyclingSeries = 0;

        private const int RunningSeries = 1;

        #endregion

        #region Constructor

        public DistanceAbstractSeriesCollection()
        {
            _series.AddRange(new[]
                                 {
                                     new Series("Cycling Distance")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.SplineArea,
                                             //Color = Color.Purple,
                                         },
                                     new Series("Running Distance")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.SplineArea,
                                             //Color = Color.RoyalBlue
                                         }
                                 });
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries)
        {
            var lastDate = DateTime.MaxValue;

            foreach (var te in entries.Cast<TrainingEntry>())
            {
                if (te.Date == lastDate)
                {
                    // add distance to last point
                    _series[te.Sport == Common.Sport.Running ? RunningSeries : CyclingSeries].Points[
                        _series[te.Sport == Common.Sport.Running ? RunningSeries : CyclingSeries].Points.Count - 1]
                        .YValues[0] += te.DistanceKm;
                }
                else
                {
                    // add zero-datapoints for training-free days
                    while (lastDate != DateTime.MaxValue &&
                           (te.Date ?? DateTime.MinValue).DayOfYear != lastDate.DayOfYear + 1)
                    {
                        lastDate = lastDate.AddDays(1);

                        foreach (var foo in _series)
                        {
                            var dpp = new DataPoint();
                            dpp.SetValueXY(lastDate, 0);
                            foo.Points.Add(dpp);
                        }
                    }

                    // add new datapoint to each series
                    var dp = new DataPoint();
                    dp.SetValueXY(te.Date ?? DateTime.MinValue, te.DistanceKm);
                    _series[te.Sport == Common.Sport.Running ? RunningSeries : CyclingSeries].Points.Add(dp);
                    dp = dp.Clone();
                    dp.SetValueY(0);
                    _series[te.Sport == Common.Sport.Cycling? RunningSeries : CyclingSeries].Points.Add(dp);
                    
                    lastDate = te.Date ?? DateTime.MinValue;
                }
            }

            // find max
            for (var i = 0; i < _series[0].Points.Count; i++)
            {
                var allSet = _series.All(s => !s.Points[i].YValues[0].Equals(0));

                if (allSet)
                    for (var j = _series.Count - 1; j >= 1; j--)
                        _series[j - 1].Points[i].YValues[0] += _series[j].Points[i].YValues[0];

                var max = _series[0].Points[i].YValues[0];

                if (max > _maxY)
                    _maxY = max;
            }
        }

        #endregion
    }
}
