using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using TrainingLog.Entries;

namespace TrainingLog.Charts
{
    public abstract class AbstractChart : Chart
    {
        #region Public Fields

        public enum GroupingType
        {
            OneDay, OneWeek, TwoWeeks, OneMonth, ThreeMonths, SixMonths, OneYear, Count
        }

        #endregion

        #region Private Fields

        protected readonly Func<GroupingType> GetGrouping;

        protected readonly Func<Entry[]> GetEntries;

        protected readonly Func<DateTime, DateTime, NonSportEntry[]> NonSportEntries;


        #endregion

        #region Constructor

        protected AbstractChart(Func<Entry[]> getEntries, Func<DateTime, DateTime, NonSportEntry[]> nonSportEntries, Func<GroupingType> getGrouping)
        {
            GetGrouping = getGrouping;
            GetEntries = getEntries;
            NonSportEntries = nonSportEntries;
        }

        #endregion

        #region Main Methods

        protected abstract void AddEntries();

        protected abstract void AddNonSportEntries();

        public void UpdateStatistics()
        {
            // clear old data
            foreach (var s in Series)
                s.Points.Clear();
            Annotations.Clear();

            // add new data
            AddEntries();
            AddNonSportEntries();
        }

        protected void AllowScrollZoomCursor()
        {
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;
            var curX = ChartAreas[0].CursorX;
            var curY = ChartAreas[0].CursorY;
           
            x.ScrollBar.Enabled = false;
            x.ScaleView.Zoomable = true;
            y.ScaleView.Zoomable = false;

            // cursor
            curX.IsUserEnabled = true;
            curY.IsUserEnabled = true;
            curX.IsUserSelectionEnabled = true;

            curX.AutoScroll = true;
            curY.AutoScroll = false;

            curX.LineWidth = 3;
            curY.LineWidth = 3;

            curX.LineColor = Color.DarkRed;
            curY.LineColor = Color.DarkRed;

            curX.SelectionColor = Color.LightGray;

            curX.Interval = x.Interval;
            curY.Interval = y.Interval;

            // reset zoom
            DoubleClick += (s, e) => ChartAreas[0].AxisX.ScaleView.ZoomReset(0);

            // make cursor always visible
            MouseMove += (s, e) =>
                             {
                                 var p = new Point(e.X, e.Y);
                                 ChartAreas[0].CursorX.SetCursorPixelPosition(p, true);
                                 ChartAreas[0].CursorY.SetCursorPixelPosition(p, true);
                             };
        }

        #endregion
    }
}
