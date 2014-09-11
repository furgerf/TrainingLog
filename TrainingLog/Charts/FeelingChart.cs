using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;
using TrainingLog.Forms;

namespace TrainingLog.Charts
{
    public class FeelingChart : AbstractChart
    {
        #region Private Fields



        #endregion

        #region Constructor

        public FeelingChart(Func<Entry[]> getEntries)
            : base(() => getEntries(), true)
        {
            Titles.Add("Feeling");
        }

        #endregion

        #region Main Methods

        protected override void AddEntries()
        {
            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            var entries = GetEntries();

            var trainingDates = new Dictionary<DateTime, double>();

            foreach (var e in entries)
            {
                if (e is BiodataEntry)
                {
                    var be = e as BiodataEntry;
                    if (be.RestingHeartRateSpecified)
                    {
                        var rhr = be.RestingHeartRate ?? int.MaxValue;
                        Series["Resting Heart Rate"].Points.Add(new DataPoint(
                            (be.Date ?? DateTime.MaxValue).ToOADate(), rhr)
                        {
                            Color =
                                be.Feeling == Common.Index.None
                                    ? Color.Gray
                                    : TrainingLogForm.GetColor(
                                        (double) (be.Feeling ?? Common.Index.Count)/((int) Common.Index.Count - 1),
                                        Color.Red, Color.Yellow, Color.Green),
                            Label = be.Note ?? "",
                            LabelAngle = 90
                        });
                    }
                    else
                    {
                        Series["Resting Heart Rate"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), 0)
                        {
                            IsEmpty = true
                        });

                        Series["Feeling only"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), 50)
                        {
                            Color =
                                be.Feeling == Common.Index.None
                                    ? Color.Gray
                                    : TrainingLogForm.GetColor(
                                        (double) (be.Feeling ?? Common.Index.Count)/((int) Common.Index.Count - 1),
                                        Color.Red, Color.Yellow, Color.Green),
                            Label = be.Note ?? "",
                            LabelAngle = 90
                        });
                    }

                    if (be.SleepDurationStringSpecified && be.SleepQualitySpecified)
                    {
                        var sleep = (be.SleepDuration ?? TimeSpan.MaxValue).TotalHours;
                        Series["Sleep"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), sleep)
                        {
                            Color = TrainingLogForm.GetColor((double)(be.SleepQuality ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green),
                            Label = " " + (be.Niggles ?? ""),
                            LabelAngle = 90
                        });
                    }
                }
                else if (e is TrainingEntry)
                {
                    var te = e as TrainingEntry;

                    if (te.Duration == null)
                        throw new Exception();

                    var offset = trainingDates.ContainsKey((te.Date ?? DateTime.MaxValue).Date) ? trainingDates[(te.Date ?? DateTime.MaxValue).Date] : 0;

                    // insert instead of add so that earlier (shorter) DPs aren't hidden
                    Series["Training"].Points.Insert(0, new DataPoint((te.Date ?? DateTime.MaxValue).Date.ToOADate(), te.Duration.Value.TotalHours + offset) { Color = te.Feeling == Common.Index.None ? Color.Gray : TrainingLogForm.GetColor((double)(te.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) });

                    if (offset > 0)
                        trainingDates[(te.Date ?? DateTime.MaxValue).Date] += te.Duration.Value.TotalHours;
                    else
                        trainingDates.Add((te.Date ?? DateTime.MaxValue).Date, te.Duration.Value.TotalHours);
                }
                else throw new Exception();
            }
        }

        protected override void Initialize()
        {
            ChartAreas.Add(new ChartArea("Feeling"));

            // prepare series
            Series.Add(new Series("Resting Heart Rate")
                            {
                                XValueType = ChartValueType.Date,
                                YValueType = ChartValueType.Int32,
                                ChartType = SeriesChartType.Spline,
                                BorderWidth = 7,
                                YAxisType = AxisType.Secondary,
                                SmartLabelStyle = { Enabled = false }
                            });
            Series.Add(new Series("Feeling only")
                            {
                                XValueType = ChartValueType.Date,
                                YValueType = ChartValueType.Int32,
                                ChartType = SeriesChartType.Point,
                                MarkerSize = 10,
                                MarkerStyle = MarkerStyle.Diamond,
                                YAxisType = AxisType.Secondary,
                                SmartLabelStyle = {Enabled = false}
                            });
            Series.Add(new Series("Training")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.Column,
                               BorderColor = Color.Black,
                               YAxisType = AxisType.Primary
                           });
            Series.Add(new Series("Sleep")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.Column,
                               YAxisType = AxisType.Primary,
                               BorderColor = Color.Black,
                               SmartLabelStyle = {Enabled = false}
                           });

            // prepare axes
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;

            // x
            x.IntervalAutoMode = IntervalAutoMode.FixedCount;
            x.IntervalType = DateTimeIntervalType.Days;
            x.Interval = 1;

            // y
            y.IntervalAutoMode = IntervalAutoMode.FixedCount;
            y.Interval = 1;
            y.Title = "Time";
            y.LabelStyle.Format = "{0} hr";
            y.TitleForeColor = Color.Red;
            y.MajorGrid.LineColor = Color.Red;
            y.IntervalAutoMode = IntervalAutoMode.FixedCount;

            ChartAreas[0].AxisY2 = new Axis(ChartAreas[0], AxisName.Y2)
            {
                Title = "Heart Rate",
                IntervalType = DateTimeIntervalType.Number,
                TitleForeColor = Color.Blue,
                MajorGrid = { LineColor = Color.Blue },
                IntervalAutoMode = IntervalAutoMode.FixedCount,
                Interval = 5,
                IntervalOffset = 50,
                Maximum = 65
            };
        }

        #endregion
    }
}
