using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Charts
{
    public class ZoneDataChart : AbstractChart
    {
        #region Constructor

        public ZoneDataChart(Func<TrainingEntry[]> getEntries)
            : base(() => getEntries().Cast<Entry>().ToArray(), true)
        {
            Titles.Add("Zone Data");
        }

        #endregion

        #region Main Methods

        private IEnumerable<Series> GetZoneDataSeries(int index)
        {
            var res = new[] {
                               new Series("Zone 1 (" + index + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone1Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 2 (" + index + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone2Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 3 (" + index + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone3Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 4 (" + index + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone4Color,
                                       IsVisibleInLegend = false
                                   },
                               new Series("Zone 5 (" + index + ")")
                                   {
                                       XValueType = ChartValueType.Date,
                                       YValueType = ChartValueType.Time,
                                       ChartType = SeriesChartType.StackedColumn,
                                       Color = ZoneDataBox.Zone5Color,
                                       IsVisibleInLegend = false
                                   }
                           };
            foreach (var s in res)
                s["PixelPointWidth"] = "10";

            return res;
        }

        protected override void Initialize()
        {
            ChartAreas.Add(new ChartArea("ZoneData"));

            // prepare series
            for (var i = 0; i < 3; i++)
                foreach (var s in GetZoneDataSeries(i))
                    Series.Add(s);

            // prepare axes
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;

            // x
            x.IntervalAutoMode = IntervalAutoMode.FixedCount;
            x.IntervalType = DateTimeIntervalType.Days;
            x.Interval = 1;

            // y
            y.IntervalAutoMode = IntervalAutoMode.FixedCount;
            y.IntervalType = DateTimeIntervalType.Minutes;
            y.Interval = 15;
            y.Minimum = new DateTime(1, 1, 1, 0, 0, 0).ToOADate();
            y.LabelStyle.Format = "HH:mm";
        }

        protected override void AddEntries()
        {
            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            var entries = GetEntries();

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
                                data[index][i] = (TrainingEntry)e;
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
                data.Add(new TrainingEntry[Series.Count / 5]);
                data[index][0] = (TrainingEntry)e;
            }

            var max = double.MinValue;
            foreach (var tes in data)
            {
                for (var i = 0; i < tes.Length; i++)
                {
                    var sum = 0.0;
                    for (var j = 0; j < 5; j++)
                    {
                        var zd = tes[i] == null ? TimeSpan.Zero : (tes[i].HrZones ?? ZoneData.Empty()).Zones[j];

                        var dp = new DataPoint((tes[0].Date ?? DateTime.MinValue).ToOADate(),
                                          new DateTime(1, 1, 1, zd.Hours, zd.Minutes, zd.Seconds).ToOADate());
                                          //zd.TotalSeconds);
                        Series["Zone " + (j + 1) + " (" + i + ")"].Points.Add(dp);

                        sum += dp.YValues[0];
                        if (sum > max)
                            max = sum;
                    }
                }
            }
            var dt = DateTime.FromOADate(max);
            if (dt.Minute > 30)
                dt = dt.AddHours(1);
            dt = dt.AddMinutes(30 - dt.Minute);
            dt = dt.AddSeconds(-dt.Second);
            ChartAreas[0].AxisY.Maximum = dt.ToOADate();
        }

        #endregion
    }
}
