using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class ZoneDataSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override double MinimumY
        {
            get { return 0; }
        }

        public override double MaximumY
        {
            get
            {
                var max = Series[0].Points.Select((t1, i) => Series.Sum(t => t.Points[i].YValues[0])).Concat(new[] {double.MinValue}).Max();

                if (max.Equals(double.MinValue))
                    return 0;

                var dt = DateTime.FromOADate(max).Add(new TimeSpan(0, 30, 0));

                return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute / 30 * 30, 0).ToOADate();
            }
        }

        public override Series[] Series { get { return _series.ToArray(); } }

        #endregion

        #region Private Fields

        private readonly List<Series> _series = new List<Series>();

        private IEnumerable<Series> GetZoneDataSeries
        {
            get
            {
                return new[]
                           {
                               new Series("Zone 1 (" + _series.Count + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone1Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 2 (" + _series.Count + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone2Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 3 (" + _series.Count + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone3Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 4 (" + _series.Count + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone4Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 5 (" + _series.Count + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone5Color,
                                       IsVisibleInLegend = false
                                   }
                           };
            }
        }

        #endregion

        #region Constructor

        public ZoneDataSeriesCollection()
        {
            // enough series for 3 trainings in one day
            _series.AddRange(GetZoneDataSeries);
            _series.AddRange(GetZoneDataSeries);
            _series.AddRange(GetZoneDataSeries);
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries, Tuple<DateInterval, int> grouping)
        {
            var data = new List<TrainingEntry[]>();
            var index = 0;

            foreach (var e in entries)
            {
                if (data.Count != index)
                {
                    // we are currently still in an array
                    if (e.Date.Equals(data[index][0].Date))
                    {
                        // add date to first free item in array
                        var added = false;

                        for (var i = 0; i < data[index].Length; i++)
                            if (data[index][i] == null)
                            {
                                data[index][i] = (TrainingEntry) e;
                                added = true;
                                break;
                            }

                        if (added)
                            continue;

                        throw new Exception("PROBABLY need more zonedataseries (too many trainings in one day)");
                    }
                    
                    // get to next index
                    index++;
                }

                // add new array
                data.Add(new TrainingEntry[_series.Count / 5]);
                data[index][0] = (TrainingEntry) e;
            }

            foreach (var tes in data)
            {
                for (var i = 0; i < tes.Length; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        var zd = tes[i] == null ? TimeSpan.Zero : (tes[i].HrZones ?? ZoneData.Empty()).Zones[j];

                        var dp = new DataPoint((tes[0].Date ?? DateTime.MinValue).ToOADate(),
                                      new DateTime(1, 1, 1, zd.Hours, zd.Minutes, zd.Seconds).ToOADate());
                        //_series[i].Series[j].Points.Add(dp);
                        _series[5*i + j].Points.Add(dp);
                    }
                }
            }
        }

        #endregion

    }
}
