using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using Microsoft.VisualBasic;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public class BiodataFiguresAbstractSeriesCollection : AbstractSeriesCollection
    {   
        #region Public Fields

        public override Series[] Series
        {
            get { return _series.ToArray(); }
        }

        public override double MinimumY
        {
            // -4 because /5 rounds down
            get { var m = (_minY - 4) / 5 * 5; return m; }
        }

        public override double MaximumY
        {
            // +9 to have at least 5 difference from max to top
            get { var m = (_maxY + 9) / 5 * 5; return m; }
        }

        #endregion

        #region Private Fields

        private readonly List<Series> _series = new List<Series>();

        private int _minY = int.MaxValue;

        private int _maxY = int.MinValue;

        private const int RestingHrSeries = 0;

        private const int AverageRestingHrSeries = 1;

        private const int OwnIndexSeries = 2;

        private const int WeightSeries = 3;

        private const int NiggleSeries = 4;

        private const int NoteSeries = 5;

        #endregion

        #region Constructor

        public BiodataFiguresAbstractSeriesCollection()
        {
            _series.AddRange(new[]
                                 {
                                     new Series("Resting Heart Rate")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Int32,
                                             ChartType = SeriesChartType.Spline,
                                             BorderWidth = 10,
                                             //IsValueShownAsLabel = true,
                                             Color = Color.RoyalBlue
                                         },
                                     new Series("Average Resting Heart Rate")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.Spline,
                                             BorderWidth = 3,
                                             Color = Color.Purple,
                                             IsValueShownAsLabel = true
                                         },
                                     new Series("OwnIndex")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Int32,
                                             ChartType = SeriesChartType.Spline,
                                             IsValueShownAsLabel = true,
                                             BorderWidth = 10,
                                             Color = Color.Green
                                         },
                                     new Series("Weight")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Double,
                                             ChartType = SeriesChartType.Spline,
                                             BorderWidth = 10,
                                             Color = Color.Red,
                                             IsValueShownAsLabel = true
                                         },
                                     new Series("Niggles")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Int32,
                                             ChartType = SeriesChartType.Point,
                                             MarkerSize = 10,
                                             MarkerStyle = MarkerStyle.Cross,
                                             Color = Color.DarkOrange
                                         },
                                     new Series("Notes")
                                         {
                                             XValueType = ChartValueType.Date,
                                             YValueType = ChartValueType.Int32,
                                             ChartType = SeriesChartType.Point,
                                             MarkerSize = 10,
                                             MarkerStyle = MarkerStyle.Square,
                                             Color = Color.Yellow
                                         }
                                 });
        }

        #endregion

        #region Main Methods

        public override void AddPoints(Entry[] entries, Tuple<DateInterval, int> grouping)
        {
            var hrAvg = 0.0;

            var lastNoteSpecified = 0;
            var lastNiggleSpecified = 0;
            
            foreach (var be in entries.Cast<BiodataEntry>())
            {
                if (be.RestingHeartRateSpecified)
                {
                    var rhr = be.RestingHeartRate ?? int.MaxValue;
                    if (rhr < _minY)
                        _minY = rhr;
                    if (rhr > _maxY)
                        _maxY = rhr;
                    _series[RestingHrSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), rhr));

                    hrAvg += rhr;
                }

                if (be.OwnIndexSpecified)
                {
                    var oi = be.OwnIndex ?? int.MaxValue;
                    if (oi < _minY)
                        _minY = oi;
                    if (oi > _maxY)
                        _maxY = oi;
                    _series[OwnIndexSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), oi));
                }

                if (be.WeightSpecified)
                {
                    var weight = be.Weight ?? decimal.MaxValue;
                    if (weight < _minY)
                        _maxY = (int)weight;
                    if (weight > _maxY)
                        _minY = (int)Math.Ceiling(weight);
                    _series[WeightSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), (double)weight));
                }

                if (be.NigglesSpecified)
                    _series[NiggleSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), lastNiggleSpecified--) { Label = be.Niggles });
                else
                    lastNiggleSpecified = 0;


                if (be.NoteSpecified)
                    _series[NoteSeries].Points.Add(new DataPoint((be.Date ?? DateTime.MaxValue).ToOADate(), lastNoteSpecified--) { Label = be.Note });
                else
                    lastNoteSpecified = 0;
            }

            foreach (var p in _series[NiggleSeries].Points)
                p.YValues[0] += MinimumY + 10;

            foreach (var p in _series[NoteSeries].Points)
                p.YValues[0] += MinimumY + 5;

            // ensure every (line-)series has at least 2 points
            foreach (var s in _series.Where(s => s.ChartType == SeriesChartType.Spline && s.Points.Count == 1))
                s.Points.Add(s.Points[0]);

            // calculate and add hr average
            if (hrAvg.Equals(0))
                return;

            hrAvg = Math.Round(hrAvg/entries.Count(e => ((BiodataEntry) e).RestingHeartRateSpecified), 2);
            _series[AverageRestingHrSeries].Points.Clear();
            var minAvg = new DataPoint((entries.First(e => ((BiodataEntry)e).RestingHeartRateSpecified).Date ?? DateTime.MinValue).ToOADate(), hrAvg);
            var maxAvg= new DataPoint((entries[entries.Length - 1].Date ?? DateTime.MinValue).ToOADate(), hrAvg);
            _series[AverageRestingHrSeries].Points.Add(minAvg);
            _series[AverageRestingHrSeries].Points.Add(maxAvg);
        }

        #endregion
    }
}
