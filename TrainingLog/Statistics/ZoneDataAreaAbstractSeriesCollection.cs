using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class ZoneDataAreaAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override double MinimumY
        {
            get { throw new Exception(); }
        }

        public override double MaximumY
        {
            get
            {
                if (Series[0].Points.Count == 0)
                    return 100;

                var max = Series[0].Points.Select(p => p.YValues[0]).Max();

                var dt = DateTime.FromOADate(max).Add(new TimeSpan(0, 30, 0));

                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute / 30 * 30, 0).ToOADate();
            }
        }

        public override Series[] Series
        {
            get
            {
                return _series.Series;
            }
        }

        #endregion

        #region Private Fields

        private readonly ZoneDataSeries _series;

        #endregion

        #region Constructor

        public ZoneDataAreaAbstractSeriesCollection()
        {
            _series = new ZoneDataSeries(new[]
                                   {
                                       new Series("Zone 5")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone5Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 4")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone4Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 3")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone3Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 2")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone2Color,
                                               IsVisibleInLegend = false
                                           },
                                       new Series("Zone 1")
                                           {
                                               XValueType = ChartValueType.Date,
                                               YValueType = ChartValueType.Time,
                                               ChartType = SeriesChartType.SplineArea,
                                               Color = ZoneDataBox.Zone1Color,
                                               IsVisibleInLegend = false
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
                    // add times to last point
                    var subsum = 0.0;
                    for (var j = 0; j < 5; j++)
                    {
                        var zd = (te.HrZones ?? ZoneData.Empty()).Zones[j];

                        var addedTime = new DateTime(1, 1, 1, zd.Hours, zd.Minutes, zd.Seconds).ToOADate();

                        _series.Series[4-j].Points[_series.Series[j].Points.Count - 1].YValues[0] += addedTime + subsum;

                        subsum += addedTime;
                    }
                }
                else
                {
                    // add zero-datapoints for training-free days
                    while (lastDate != DateTime.MaxValue && (te.Date ?? DateTime.MinValue).DayOfYear != lastDate.DayOfYear + 1)
                    {
                        lastDate = lastDate.AddDays(1);

                        foreach (var foo in _series.Series)
                        {
                            var dp = new DataPoint();
                            dp.SetValueXY(lastDate, 0);
                            foo.Points.Add(dp);
                        }
                    }

                    // add new datapoint to each series
                    var subsum = 0.0;
                    for (var j = 0; j < 5; j++)
                    {
                        var zd = (te.HrZones ?? ZoneData.Empty()).Zones[j];

                        var dp = new DataPoint();
                        dp.SetValueXY(te.Date ?? DateTime.MinValue,
                                      subsum + new DateTime(1, 1, 1, zd.Hours, zd.Minutes, zd.Seconds).ToOADate());
                        _series.Series[4-j].Points.Add(dp);

                        subsum += new DateTime(1, 1, 1, zd.Hours, zd.Minutes, zd.Seconds).ToOADate();
                    }
                }

                lastDate = te.Date ?? DateTime.MinValue;
            }
        }

        #endregion

    }
}
