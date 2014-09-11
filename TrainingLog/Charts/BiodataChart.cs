using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;

namespace TrainingLog.Charts
{
    public class BiodataChart : AbstractChart
    {
        #region Private Fields

        //private double PixelPerInterval
        //{
        //    get { return _pixelPerInterval; }
        //    set
        //    {
        //        _pixelPerInterval = value;
        //        //ChartAreas[0].AxisX.ScaleView.Size = 10 * PixelPerInterval;
        //        var a = (ChartAreas[0].InnerPlotPosition.Width / 100);
        //        //var count = Width / (ChartAreas[0].AxisX.ScaleView.ViewMaximum - ChartAreas[0].AxisX.ScaleView.ViewMinimum);
        //        var count = a * Width / (ChartAreas[0].AxisX.ScaleView.ViewMaximum - ChartAreas[0].AxisX.ScaleView.ViewMinimum);
        //        count = a*Width*PixelPerInterval;
        //        count = 5;
        //        count = a*Width/25;
        //        ChartAreas[0].AxisX.ScaleView.Zoom(ChartAreas[0].AxisX.Minimum, count, DateTimeIntervalType.Days);
        //    }
        //}

        //private double _pixelPerInterval = 10;
        //private bool _updatePixelPerInterval = true;

        #endregion

        #region Constructor

        public BiodataChart(Func<BiodataEntry[]> getEntries) : base(() => getEntries().Cast<Entry>().ToArray(), true)
        {
            Titles.Add("Biodata");

            //Paint += (s, e) =>
            //             {
            //                 if (!_updatePixelPerInterval || ChartAreas.Count <= 0) return;
            //                 var firstDate = DateTime.FromOADate(Series[0].Points[0].XValue);
            //                 PixelPerInterval =
            //                     ChartAreas[0].AxisX.ValueToPixelPosition(firstDate.AddDays(1).ToOADate()) -
            //                     ChartAreas[0].AxisX.ValueToPixelPosition(firstDate.ToOADate());
            //                 _updatePixelPerInterval = false;
            //             };

            //Resize += (s, e) =>
            //              {
            //                  _updatePixelPerInterval = true;
            //              };
        }


        #endregion

        #region Main Methods

        protected override void Initialize()
        {
            ChartAreas.Add(new ChartArea("Biodata"));
            Legends.Add(new Legend
                            {
                                LegendStyle = LegendStyle.Row,
                                Alignment = StringAlignment.Center,
                                Docking = Docking.Top
                            });

            // prepare series
            Series.Add(new Series("Resting Heart Rate")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Int32,
                               ChartType = SeriesChartType.Spline,
                               BorderWidth = 7,
                               Color = Color.RoyalBlue
                           });
            Series.Add(new Series("Average Resting Heart Rate")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.Spline,
                               BorderWidth = 3,
                               Color = Color.Purple,
                               IsValueShownAsLabel = true
                           });
            Series.Add(new Series("OwnIndex")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Int32,
                               ChartType = SeriesChartType.Spline,
                               IsValueShownAsLabel = true,
                               BorderWidth = 7,
                               Color = Color.Green
                           });
            Series.Add(new Series("Weight")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Double,
                               ChartType = SeriesChartType.Spline,
                               BorderWidth = 7,
                               Color = Color.Red,
                               IsValueShownAsLabel = true
                           });
            Series.Add(new Series("Niggles")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Int32,
                               ChartType = SeriesChartType.Point,
                               MarkerSize = 10,
                               MarkerStyle = MarkerStyle.Cross,
                               Color = Color.DarkOrange
                           });
            Series.Add(new Series("Notes")
                           {
                               XValueType = ChartValueType.Date,
                               YValueType = ChartValueType.Int32,
                               ChartType = SeriesChartType.Point,
                               MarkerSize = 10,
                               MarkerStyle = MarkerStyle.Square,
                               Color = Color.Yellow
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
            y.IntervalType = DateTimeIntervalType.Number;
            y.Interval = 5;
        }

        protected override void AddEntries()
        {
            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            var entries = GetEntries();

            var hrAvg = 0.0;

            var lastNoteSpecified = 0;
            var lastNiggleSpecified = 0;

            foreach (var be in entries.Cast<BiodataEntry>())
            {
                if (be.RestingHeartRateSpecified)
                {
                    var rhr = be.RestingHeartRate ?? int.MaxValue;
                    Series["Resting Heart Rate"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), rhr));

                    hrAvg += rhr;
                }
                else
                {
                    Series["Resting Heart Rate"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), 0)
                    {
                        IsEmpty = true
                    });
                }

                if (be.OwnIndexSpecified)
                {
                    var oi = be.OwnIndex ?? int.MaxValue;
                    Series["OwnIndex"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), oi));
                }

                if (be.WeightSpecified)
                {
                    var weight = be.Weight ?? decimal.MaxValue;
                    Series["Weight"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), (double)weight));
                }

                if (be.NigglesSpecified)
                    Series["Niggles"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), lastNiggleSpecified++) { Label = be.Niggles });
                else
                    lastNiggleSpecified = 0;
                lastNiggleSpecified %= 5;

                if (be.NoteSpecified)
                    Series["Notes"].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), lastNoteSpecified++) { Label = be.Note });
                else
                    lastNoteSpecified = 0;
                lastNoteSpecified %= 5;
            }

            foreach (var p in Series["Niggles"].Points)
                p.YValues[0] = -p.YValues[0] * 4 + 40;

            foreach (var p in Series["Notes"].Points)
                p.YValues[0] = p.YValues[0] * 4 + 5;

            // ensure every (line-)series has at least 2 points
            foreach (var s in Series.Where(s => s.ChartType == SeriesChartType.Spline && s.Points.Count == 1))
                s.Points.Add(s.Points[0]);

            // calculate and add hr average
            if (hrAvg.Equals(0))
                return;

            hrAvg = Math.Round(hrAvg / entries.Cast<BiodataEntry>().Count(e => e.RestingHeartRateSpecified), 2);
            Series["Average Resting Heart Rate"].Points.Clear();
            var minAvg = new DataPoint((entries.Cast<BiodataEntry>().First(e => e.RestingHeartRateSpecified).Date ?? DateTime.MinValue).ToOADate(), hrAvg);
            var maxAvg = new DataPoint((entries[entries.Length - 1].Date ?? DateTime.MinValue).ToOADate(), hrAvg);
            Series["Average Resting Heart Rate"].Points.Add(minAvg);
            Series["Average Resting Heart Rate"].Points.Add(maxAvg);
        }

        //protected override void AddNonSportEntries()
        //{
        //    //var entries = GetEntries();
        //    //foreach (var e in NonSportEntries(entries.First().Date ?? DateTime.MaxValue, entries.Last().Date ?? DateTime.MinValue))
        //    //    e.AddEntryToChart(ChartAreas[0], Series["Non-Sport Entries"], Annotations);

        //    var minX = double.MaxValue;
        //    var maxX = double.MinValue;
        //    foreach (var s in Series.Where(s => s.Points.Count > 0))
        //    {
        //        if (s.Points[0].XValue < minX)
        //            minX = s.Points[0].XValue;
        //        if (s.Points[0].XValue > maxX)
        //            maxX = s.Points[0].XValue;
        //    }

        //    foreach (var e in NonSportEntries(DateTime.FromOADate(minX), DateTime.FromOADate(maxX)))
        //        e.AddEntryToChart(ChartAreas[0], Series["Non-Sport Entries"], Annotations);
        //}

        #endregion
    }
}
