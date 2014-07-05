using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Charts
{
    public class SportOverviewChart : AbstractChart
    {
        #region Private Fields

        private readonly Common.Sport _sport = Common.Sport.Count;

        private int _maximizedChartArea;

        #endregion

        #region Constructor

        public SportOverviewChart(Func<TrainingEntry[]> getEntries, Common.Sport sport)
            : base(() => getEntries().Cast<Entry>().ToArray())
        {
            _sport = sport;
            Titles.Add(_sport + " Overview");

            // can't do that in Initialize() because _sport isn't yet set
            var trainingTypeColors = Common.GetTrainingTypeColors(_sport);
            for (var i = 0; i < Common.GetTrainingTypes(_sport).Length; i++)
                Series.Add(
                    new Series("Training Type " + Common.GetTrainingTypes(_sport)[i].ToString())
                    {
                        XValueType = ChartValueType.Date,
                        YValueType = ChartValueType.Int32,
                        ChartType = SeriesChartType.StackedColumn,
                        Color = trainingTypeColors[i],
                        ChartArea = "Monthly Training Types"
                    });
            // must add entries manually for the same reason
            AddEntries();

            // detect whether chartarea is clicked
            MouseClick += (s, e) =>
                              {
                                  if (_maximizedChartArea != 0)
                                  {
                                      _maximizedChartArea = 0;
                                      AlignChartAreas();
                                      return;
                                  }

                                  for (var i = 0; i < ChartAreas.Count; i++)
                                  {
                                      var minX = (int) ChartAreas[i].Position.X * Width / 100;
                                      var maxX = (int) ((ChartAreas[i].Position.X + ChartAreas[i].Position.Width)*Width/100);
                                      var minY = (int) ChartAreas[i].Position.Y * Height / 100;
                                      var maxY = (int) ((ChartAreas[i].Position.Y + ChartAreas[i].Position.Height)*Height/100);

                                      if (e.X < minX || e.X > maxX || e.Y < minY || e.Y > maxY)
                                          continue;
                                      
                                      //The mouse is inside the given area
                                      _maximizedChartArea = i + 1;
                                      AlignChartAreas();
                                      return;
                                  }
                              };
        }

        #endregion

        #region Main Methods

        protected override void Initialize()
        {
            // areas
            ChartAreas.Add(new ChartArea("Totals"));
            ChartAreas.Add(new ChartArea("Training Types"));
            ChartAreas.Add(new ChartArea("Heart Rate Zones"));
            ChartAreas.Add(new ChartArea("Monthly Training Types"));
            ChartAreas.Add(new ChartArea("Monthly Heart Rate Zones"));
            ChartAreas["Totals"].AxisX = new Axis(ChartAreas["Totals"], AxisName.X)
            {
                Title = "Date",
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                IntervalType = DateTimeIntervalType.Weeks,
                Interval = 2
            };
            ChartAreas["Totals"].AxisY = new Axis(ChartAreas["Totals"], AxisName.Y)
            {
                Title = "Distance",
                TitleForeColor = Color.Red,
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                Interval = 100,
                MajorGrid = { LineColor = Color.Red },
                LabelStyle = { Format = "{0} km" }
            };
            ChartAreas["Totals"].AxisY2 = new Axis(ChartAreas["Totals"], AxisName.Y2)
            {
                Title = "Time",
                IntervalType = DateTimeIntervalType.Number,
                TitleForeColor = Color.Blue,
                MajorGrid = { LineColor = Color.Blue },
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                Interval = 12,
                LabelStyle = { Format = "{0} h" }
            };
            
            // series
            Series.Add(new Series("Distance")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.Spline,
                               BorderWidth = 3,
                               YAxisType = AxisType.Primary,
                               Color = Color.Red,
                               ChartArea = "Totals"
                           });
            Series.Add(new Series("Time")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.Spline,
                               BorderWidth = 3,
                               YAxisType = AxisType.Secondary,
                               Color = Color.Blue,
                               ChartArea = "Totals"
                           });

            Series.Add(new Series("Training Types")
                           {
                               ChartType = SeriesChartType.Pie,
                               ChartArea = "Training Types"
                           });
            Series["Training Types"]["PieLabelStyle"] = "Inside";

            Series.Add(new Series("Heart Rate Zones")
                           {
                               ChartType = SeriesChartType.Pie,
                               ChartArea = "Heart Rate Zones"
                           });
            Series["Heart Rate Zones"]["PieLabelStyle"] = "Inside";

            ChartAreas["Monthly Training Types"].AxisX = new Axis(ChartAreas["Monthly Training Types"], AxisName.X)
            {
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                IntervalType = DateTimeIntervalType.Months,
                Interval = 1
            };
            ChartAreas["Monthly Training Types"].AxisY = new Axis(ChartAreas["Monthly Training Types"], AxisName.Y)
            {
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                Interval = 5
            };

            for (var i = 0; i < 5; i++)
                Series.Add(new Series("Zone " + (i + 1))
                {
                    XValueType = ChartValueType.Date,
                    YValueType = ChartValueType.Double,
                    ChartType = SeriesChartType.StackedColumn,
                    Color = ZoneDataBox.ZoneColors[i],
                    ChartArea = "Monthly Heart Rate Zones"
                });
            ChartAreas["Monthly Heart Rate Zones"].AxisX = new Axis(ChartAreas["Monthly Heart Rate Zones"], AxisName.X)
            {
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                IntervalType = DateTimeIntervalType.Months,
                Interval = 1
            };
            ChartAreas["Monthly Heart Rate Zones"].AxisY = new Axis(ChartAreas["Monthly Heart Rate Zones"], AxisName.Y)
            {
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                LabelStyle = { Format = "{0} h" },
                Interval = 5
            };

            // NSEs
            AddNonSportEntries("Totals");

            AlignChartAreas();
        }

        protected override void AddEntries()
        {
            // must add entries manually once _sport is set
            if (_sport == Common.Sport.Count)
                return;

            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            var entries = GetEntries().Cast<TrainingEntry>().ToArray();

            // totals
            var sumDistance = 0.0;
            var sumTime = 0.0;
            foreach (var e in entries)
            {
                sumDistance += e.DistanceKm;
                Series["Distance"].Points.Add(new DataPoint((e.Date ?? DateTime.MinValue).ToOADate(), sumDistance));
                if (e.Duration == null)
                    throw new Exception();
                sumTime += e.Duration.Value.TotalHours;
                Series["Time"].Points.Add(new DataPoint((e.Date ?? DateTime.MinValue).ToOADate(), sumTime));
            }

            // training types
            var types = Common.GetTrainingTypes(_sport);
            var trainingTypeColors = Common.GetTrainingTypeColors(_sport);
            var count = new int[types.Length];
            foreach (var e in entries)
                count[Array.IndexOf(types, e.TrainingType)]++;

            for (var i = 0; i < types.Length; i++)
                if (count[i] > 0)
                    Series["Training Types"].Points.Add(new DataPoint(0, count[i]) { Label = Enum.GetName(typeof(Common.TrainingType), types[i]) + ": " + count[i] + " (" + Math.Round((double)count[i] / count.Sum() * 100, 1) + "%)", Color = trainingTypeColors[i] });

            // heart rate zones
            var zd = ZoneData.Empty();
            foreach (var e in entries.Where(e => e.HrZones != null))
                for (var i = 0; i < 5; i++)
                    zd.Zones[i] = zd.Zones[i].Add((e.HrZones ?? ZoneData.Empty()).Zones[i]);

            for (var i = 0; i < 5; i++)
                Series["Heart Rate Zones"].Points.Add(new DataPoint(0, zd.Zones[i].TotalHours) { Color = ZoneDataBox.ZoneColors[i], Label = "Zone " + (i + 1) + " (" + Math.Round(zd.Zones[i].TotalHours / zd.Duration.TotalHours * 100, 1) + "%):\n" + (zd.Zones[i].Days * 24 + zd.Zones[i].Hours) + "h " + zd.Zones[i].Minutes + "m " + zd.Zones[i].Seconds + "s" });

            // monthly training types
            var month = entries.First().Date ?? DateTime.MaxValue;
            month = new DateTime(month.Year, month.Month, 1);
            foreach (var s in Series.Where(s => s.Name.StartsWith("Training Type ")))
                s.Points.Add(new DataPoint(month.ToOADate(), 0));

            foreach (var e in entries)
            {
                if (e.Date == null)
                    throw new Exception();
                if (e.Date.Value.Month != month.Month)
                {
                    // add new dp
                    month = month.AddMonths(1);
                    foreach (var s in Series.Where(s => s.Name.StartsWith("Training Type ")))
                        s.Points.Add(new DataPoint(month.ToOADate(), 0));
                }
                Series["Training Type " + e.TrainingType.ToString()].Points.Last().YValues[0]++;
            }

            // monthly training zones
            month = entries.First().Date ?? DateTime.MaxValue;
            month = new DateTime(month.Year, month.Month, 1);
            foreach (var s in Series.Where(s => s.Name.StartsWith("Zone ")))
                s.Points.Add(new DataPoint(month.ToOADate(), 0));

            foreach (var e in entries)
            {
                if (e.Date == null)
                    throw new Exception();
                if (e.HrZones == null)
                    continue;
                if (e.Date.Value.Month != month.Month)
                {
                    // add new dp
                    month = month.AddMonths(1);
                    foreach (var s in Series.Where(s => s.Name.StartsWith("Zone ")))
                        s.Points.Add(new DataPoint(month.ToOADate(), 0));
                }

                for (var i = 0; i < 5; i++)
                    Series["Zone " + (i + 1)].Points.Last().YValues[0] += e.HrZones.Value.Zones[i].TotalHours;
            }
        }

        private void AlignChartAreas()
        {
            if (_maximizedChartArea == 0)
            {
                // spread CAs fairly
                if (ChartAreas.Count != 5)
                    throw new NotImplementedException("don't know how to spread this amount of CAs");

                ChartAreas["Totals"].Position = new ElementPosition(0, 0, 50, 50);
                ChartAreas["Training Types"].Position = new ElementPosition(0, 50, 25, 50);
                ChartAreas["Heart Rate Zones"].Position = new ElementPosition(25, 50, 25, 50);
                ChartAreas["Monthly Training Types"].Position = new ElementPosition(50, 0, 50, 50);
                ChartAreas["Monthly Heart Rate Zones"].Position = new ElementPosition(50, 50, 50, 50);
            }
            else
            {
                // maximize one area
                var bigIndex = _maximizedChartArea - 1;
                ChartAreas[bigIndex].Position = new ElementPosition(0, 0, 75, 100);
                var index = 0;
                var smallCount = ChartAreas.Count - 1;
                var step = 100/smallCount;

                for (var i = 0; i < ChartAreas.Count; i++)
                    if (i != bigIndex)
                        ChartAreas[i].Position = new ElementPosition(75, index++ * step, 25, step);
            }
        }

        #endregion
    }
}
