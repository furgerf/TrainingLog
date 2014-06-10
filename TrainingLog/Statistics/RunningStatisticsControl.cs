using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Controls;
using TrainingLog.Entries;

namespace TrainingLog.Statistics
{
    public partial class RunningStatisticsControl : UserControl, IStatisticsPage
    {
        #region Fields

        private new const int Padding = 3;

        public Func<TrainingEntry[]> GetEntries;

        private const int SeriesTotalsDistance = 0;

        private const int SeriesTotalsTime = 1;

        private const int SeriesTrainingTypes = 0;

        private const int SeriesHeartZones = 0;

        #endregion

        #region Constructor

        public RunningStatisticsControl()
        {
            InitializeComponent();

            Name = "Running Overview";

            // totals
            chaTotals.Series.Add(new Series("Distance")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Double,
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                YAxisType = AxisType.Primary,
                Color = Color.Red
            });
            chaTotals.Series.Add(new Series("Time")
            {
                XValueType = ChartValueType.Date,
                YValueType = ChartValueType.Double,
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3,
                YAxisType = AxisType.Secondary,
                Color = Color.Blue
            });
            chaTotals.Legends.Add(new Legend());
            chaTotals.ChartAreas[0].AxisX = new Axis(chaTotals.ChartAreas[0], AxisName.X)
                                                {
                                                    Title = "Date",
                                                    IntervalAutoMode = IntervalAutoMode.FixedCount,
                                                    IntervalType = DateTimeIntervalType.Weeks,
                                                    Interval = 1
                                                };
            chaTotals.ChartAreas[0].AxisY = new Axis(chaTotals.ChartAreas[0], AxisName.Y)
                                                {
                                                    Title = "Distance",
                                                    TitleForeColor = Color.Red,
                                                    IntervalAutoMode = IntervalAutoMode.FixedCount,
                                                    Interval = 100,
                                                    MajorGrid = { LineColor = Color.Red },
                                                    LabelStyle = { Format = "{0} km" }
                                                };
            chaTotals.ChartAreas[0].AxisY2 = new Axis(chaTotals.ChartAreas[0], AxisName.Y2)
                                                 {
                                                     Title = "Time",
                                                     IntervalType = DateTimeIntervalType.Number,
                                                     TitleForeColor = Color.Blue,
                                                     MajorGrid = { LineColor = Color.Blue },
                                                     IntervalAutoMode = IntervalAutoMode.FixedCount,
                                                     Interval = 12,
                                                     LabelStyle = { Format = "{0} h" }
                                                 };

            // training types
            chaTrainingTypes.Series.Add(new Series("Training Types") { ChartType = SeriesChartType.Pie });
            chaTrainingTypes.Series[SeriesTrainingTypes]["PieLabelStyle"] = "Inside";
            
            // hr zones
            chaHeartZones.Series.Add(new Series("Heart Rate Zones") { ChartType = SeriesChartType.Pie });
            chaHeartZones.Series[SeriesHeartZones]["PieLabelStyle"] = "Inside";
        }

        #endregion

        #region Main Methods

        public void UpdateStatistics()
        {
            if (GetEntries == null)
                throw new Exception();

            var entries = GetEntries();

            // totals
            foreach (var s in chaTotals.Series)
                s.Points.Clear();
            var sum = 0.0;
            foreach (var e in entries)
            {
                sum += e.DistanceKm;
                chaTotals.Series[SeriesTotalsDistance].Points.Add(new DataPoint((e.Date ?? DateTime.MinValue).ToOADate(), sum));
            }
            sum = 0;
            foreach (var e in entries)
            {
                if (e.Duration == null)
                    throw new Exception();
                sum += e.Duration.Value.TotalHours;
                chaTotals.Series[SeriesTotalsTime].Points.Add(new DataPoint((e.Date ?? DateTime.MinValue).ToOADate(), sum));
            }

            // training types
            var types = Common.GetTrainingTypes(Common.Sport.Running);
            var count = new int[types.Length];
            foreach (var e in entries)
                count[Array.IndexOf(types, e.TrainingType)]++;

            for (var i = 0; i < types.Length; i++)
                chaTrainingTypes.Series[SeriesTrainingTypes].Points.Add(new DataPoint(0, count[i]) {Label = Enum.GetName(typeof (Common.TrainingType), types[i]) + ": " + count[i]});

            // heart rate zones
            var zd = ZoneData.Empty();
            foreach (var e in entries.Where(e => e.HrZones != null))
                for (var i = 0; i < 5; i++)
                    zd.Zones[i] = zd.Zones[i].Add(e.HrZones.Value.Zones[i]);

            for (var i = 0; i < 5; i++)
                chaHeartZones.Series[SeriesHeartZones].Points.Add(new DataPoint(0, zd.Zones[i].TotalHours) { Color = ZoneDataBox.ZoneColors[i], Label = "Zone " + (i+1) + ":\n" + (zd.Zones[i].Days * 24 + zd.Zones[i].Hours) + "h " + zd.Zones[i].Minutes + "m " + zd.Zones[i].Seconds + "s"});
        }

        #endregion

        #region Event Handling

        private void RunningStatisticsControlResize(object sender, EventArgs e)
        {
            grpTotals.Location = new Point(Padding, Padding);
            grpTotals.Size = new Size(Size.Width/2 - grpTotals.Location.X - Padding,
                                      Size.Height - grpTotals.Location.Y - Padding);

            grpTrainingTypes.Location = new Point(grpTotals.Location.X + grpTotals.Width + 2*Padding, Padding);
            grpTrainingTypes.Size = new Size((Size.Width - grpTrainingTypes.Location.X)/2 - Padding,
                                             Size.Height - grpTrainingTypes.Location.Y - Padding);

            grpHeartZones.Location = new Point(grpTrainingTypes.Location.X + grpTrainingTypes.Width + 2*Padding, Padding);
            grpHeartZones.Size = new Size(Size.Width - grpHeartZones.Location.X - Padding,
                                          Size.Height - grpHeartZones.Location.Y - Padding);
        }

        private void GroupBoxResize(object sender, EventArgs e)
        {
            var grp = sender as GroupBox;
            if (grp == null || grp.Controls.Count != 1 || !(grp.Controls[0] is Chart))
                throw new Exception("not sure that I should have \"other\" groupboxes (yet)...");

            if (grp.Width < 2*grp.Controls[0].Location.X || grp.Height < grp.Controls[0].Location.Y)
                return;

            // resize chart
            grp.Controls[0].Size = new Size(grp.Width - 2 * grp.Controls[0].Location.X, grp.Height - 2 * grp.Controls[0].Location.Y);
        }

        #endregion
    }
}
