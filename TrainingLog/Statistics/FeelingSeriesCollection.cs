using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;
using TrainingLog.Entries;
using TrainingLog.Forms;

namespace TrainingLog.Statistics
{
    public class FeelingSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override Series[] Series
        {
            get { return _series.ToArray(); }
        }

        public override double MinimumY
        {
            get { return 0; }
        }

        public override double MaximumY
        {
            get { return 12; }
        }

        #endregion

        #region Private Fields

        private readonly List<Series> _series = new List<Series>();

        private const int RestingHrSeries = 0;

        private const int TrainingSeries = 1;

        private const int SleepSeries = 2;

        #endregion

        #region Constructor

        public FeelingSeriesCollection()
        {
            _series.AddRange(new[]
                                 {
                                     new Series("Resting Heart Rate")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Int32,
                                             ChartType = SeriesChartType.Spline,
                                             BorderWidth = 10,
                                             YAxisType = AxisType.Secondary,
                                             SmartLabelStyle = { Enabled =  false }
                                         },
                                     new Series("Training")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.Column,
                                             BorderColor = Color.Black,
                                             YAxisType = AxisType.Primary
                                         },
                                     new Series("Sleep")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.Column,
                                             YAxisType = AxisType.Primary,
                                             BorderColor = Color.Black,
                                             SmartLabelStyle = { Enabled = false }
                                         }
                                 });
            _series[TrainingSeries]["PixelPointWidth"] = "30";
            _series[SleepSeries]["PixelPointWidth"] = "45";
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries, Tuple<DateInterval, int> grouping)
        {
            foreach (var e in entries)
            {
                if (e is BiodataEntry)
                {
                    var be = e as BiodataEntry;
                    if (be.RestingHeartRateSpecified)
                    {
                        var rhr = be.RestingHeartRate ?? int.MaxValue;
                        _series[RestingHrSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), rhr)
                                                                {
                                                                    Color = TrainingLogForm.GetColor((double)(be.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green),
                                                                    Label = be.Note ?? "",
                                                                    LabelAngle = 90
                                                                });
                    }

                    if (be.SleepDurationStringSpecified && be.SleepQualitySpecified)
                    {
                        var sleep = (be.SleepDuration ?? TimeSpan.MaxValue).TotalHours;
                        _series[SleepSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), sleep)
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

                    var sameX = _series[TrainingSeries].Points.LastOrDefault(tee => tee.XValue == (te.Date ?? DateTime.MaxValue).ToOADate());

                    _series[TrainingSeries].Points.Add(new DataPoint((te.Date ?? DateTime.MaxValue).ToOADate(), te.Duration.Value.TotalHours + (sameX == null ? 0 : sameX.YValues[0])) { Color = te.Feeling == Common.Index.None ? Color.Gray : TrainingLogForm.GetColor((double)(te.Feeling ?? Common.Index.Count) / ((int)Common.Index.Count - 1), Color.Red, Color.Yellow, Color.Green) });

                    if (sameX != null)
                    {
                        _series[TrainingSeries].Points.Remove(sameX);
                        _series[TrainingSeries].Points.Add(sameX);
                    }
                }
                else throw new Exception();
            }
        }

        #endregion
    }
}
