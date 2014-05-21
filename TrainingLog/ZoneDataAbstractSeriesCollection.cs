using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;

namespace TrainingLog
{
    public class ZoneDataAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

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
            _series.Add(GetZoneDataSeries);
        }

        #endregion

        #region Main Methods

        //public override void AddPoint(DataPoint point, int index = 0)
        //{
        //    if (point.XValue.Equals(41750))
        //    {
                
        //    }

        //    var seriesIndex = 0;
        //    // find out which series to add the point to
        //    for (; seriesIndex < _series.Count; seriesIndex++)
        //    {
        //        var xPresent = false;
        //        foreach (var p in _series[seriesIndex].Series[0].Points)
        //            if (p.XValue.Equals(point.XValue))
        //            {
        //                xPresent = true;
                        
        //                if (seriesIndex == _series.Count - 1)
        //                    _series.Add(GetZoneDataSeries);
        //            }

        //        if (!xPresent)
        //            break;
        //    }

        //    _series[seriesIndex].Series[index].Points.Add(point);
        //    //foreach (var s in _series[seriesIndex].Series)
        //    //    s.Points.Add(point);
        //}

        public override void AddPoints(DataPoint[] points)
        {
            foreach (var s in _series)
            {
                var add = true;
                foreach (var p in s.Series[0].Points)
                {
                    if (p.XValue.Equals(points[0].XValue))
                    {
                        add = false;
                        break;
                    }
                }

                if (add)
                {
                    if (s.Equals(_series[3]))
                    {
                        
                    }

                    for (var i = 0; i < points.Length; i++)
                        s.Series[i].Points.Add(points[i]);

                    return;
                }
            }

            //var zds = GetZoneDataSeries;

            //for (var i = 0; i < points.Length; i++)
            //    zds.Series[i].Points.Add(points[i]);

            //_series.Add(zds);
        }

        #endregion

    }
}
