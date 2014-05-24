using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog
{
    public class ZoneDataAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override double MinimumY
        {
            get { throw new Exception(); }
        }

        public override double MaximumY
        {
            get { throw new Exception(); }
        }

        public override Series[] Series
        {
            get
            {
                var result = new List<Series>();
                foreach (var s in _series)
                    result.AddRange(s.Series);
                return result.ToArray();
            }
        }

        #endregion

        #region Private Fields

        private readonly List<ZoneDataSeries> _series = new List<ZoneDataSeries>();

        private ZoneDataSeries GetZoneDataSeries
        {
            get
            {
                return new ZoneDataSeries(new[]
                                              {
                                                  new Series("Zone 1 (" + _series.Count + ")")
                                                      {
                                                          XValueType = ChartValueType.Date,
                                                          YValueType = ChartValueType.Time,
                                                          ChartType = SeriesChartType.StackedColumn,
                                                          Color = ZoneDataBox.Zone1Color,
                                                          //IsVisibleInLegend = false
                                                      },
                                                  new Series("Zone 2 (" + _series.Count + ")")
                                                      {
                                                          XValueType = ChartValueType.Date,
                                                          YValueType = ChartValueType.Time,
                                                          ChartType = SeriesChartType.StackedColumn,
                                                          Color = ZoneDataBox.Zone2Color,
                                                          //IsVisibleInLegend = false
                                                      },
                                                  new Series("Zone 3 (" + _series.Count + ")")
                                                      {
                                                          XValueType = ChartValueType.Date,
                                                          YValueType = ChartValueType.Time,
                                                          ChartType = SeriesChartType.StackedColumn,
                                                          Color = ZoneDataBox.Zone3Color,
                                                          //IsVisibleInLegend = false
                                                      },
                                                  new Series("Zone 4 (" + _series.Count + ")")
                                                      {
                                                          XValueType = ChartValueType.Date,
                                                          YValueType = ChartValueType.Time,
                                                          ChartType = SeriesChartType.StackedColumn,
                                                          Color = ZoneDataBox.Zone4Color,
                                                          //IsVisibleInLegend = false
                                                      },
                                                  new Series("Zone 5 (" + _series.Count + ")")
                                                      {
                                                          XValueType = ChartValueType.Date,
                                                          YValueType = ChartValueType.Time,
                                                          ChartType = SeriesChartType.StackedColumn,
                                                          Color = ZoneDataBox.Zone5Color,
                                                          //IsVisibleInLegend = false
                                                      }
                                              });
            }
        }

        #endregion

        #region Constructor

        public ZoneDataAbstractSeriesCollection()
        {
            _series.Add(GetZoneDataSeries);
            _series.Add(GetZoneDataSeries);
            _series.Add(GetZoneDataSeries);
            //_series.Add(GetZoneDataSeries);
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries)
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
                data.Add(new TrainingEntry[_series.Count]);
                data[index][0] = (TrainingEntry) e;
            }

            foreach (var tes in data)
            {
                for (var i = 0; i < tes.Length; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        var zd = tes[i] == null ? TimeSpan.MaxValue : (tes[i].HrZones ?? ZoneData.Empty()).Zones[j];
                        var dp = new DataPoint();
                        dp.SetValueXY(tes[0].Date ?? DateTime.MinValue,
                            zd);
                        _series[i].Series[j].Points.Add(dp);

                    }
                }
            }
        }

        #endregion

    }
}
