using System;
using System.Drawing;
using System.Linq;
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

        #region Protected Fields

        protected readonly Func<GroupingType> GetGrouping;

        protected readonly Func<Entry[]> GetEntries;

        protected readonly Func<DateTime, DateTime, NonSportEntry[]> NonSportEntries;

        protected const string NonSportSeriesString = "Non-Sport Entries";
        
        private double _oldSelStart = -1;
        private double _oldSelEnd = -1;
        
        #endregion

        #region Constructor

        protected AbstractChart(Func<Entry[]> getEntries, Func<DateTime, DateTime, NonSportEntry[]> nonSportEntries, Func<GroupingType> getGrouping, bool allowScrollZoomCursor)
        {
            GetGrouping = getGrouping;
            GetEntries = getEntries;
            NonSportEntries = nonSportEntries;

            Initialize();

            if (allowScrollZoomCursor)
                AllowScrollZoomCursor();
        }

        #endregion

        #region Main Methods

        protected abstract void AddEntries();

        protected void AddNonSportEntries()
        {
            Annotations.Clear();
            Series[NonSportSeriesString].Points.Clear();

            var minX = double.MaxValue;
            var maxX = double.MinValue;
            foreach (var s in Series.Where(s => s.Points.Count > 0 && s.Name != NonSportSeriesString))
            {
                if (s.Points[0].XValue < minX)
                    minX = s.Points[0].XValue;
                if (s.Points[s.Points.Count - 1].XValue > maxX)
                    maxX = s.Points[s.Points.Count - 1].XValue;
            }
            // TODO: ONLY COUNT POINTS TOWARDS MIN/MAX THAT ARE ACTUALLY VISIBLE WITH CURRENT ZOOM

            foreach (var e in NonSportEntries(DateTime.FromOADate(minX), DateTime.FromOADate(maxX)))
                e.AddEntryToChart(ChartAreas[0], Series[NonSportSeriesString], Annotations);
        }
        protected abstract void Initialize();

        public void UpdateStatistics()
        {
            // clear old data
            foreach (var s in Series)
                s.Points.Clear();

            // add new data
            AddEntries();
            AddNonSportEntries();
        }

        private void AllowScrollZoomCursor()
        {
            var x = ChartAreas[0].AxisX;
            var y = ChartAreas[0].AxisY;
            var curX = ChartAreas[0].CursorX;
            var curY = ChartAreas[0].CursorY;
           
            x.ScrollBar.Enabled = false;
            x.ScaleView.Zoomable = true;
            y.ScaleView.Zoomable = true;

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
            DoubleClick += (s, e) =>
                               {
                                   ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                                   AddNonSportEntries();
                               };

            // make cursor always visible
            MouseMove += (s, e) =>
                             {
                                 var p = new Point(e.X, e.Y);
                                 ChartAreas[0].CursorX.SetCursorPixelPosition(p, true);
                                 ChartAreas[0].CursorY.SetCursorPixelPosition(p, true);
                             };

            // update NSE when zoom changes
            AxisViewChanged += (s, e) =>
                                   {
                                       var newSelStart = ChartAreas[0].CursorX.SelectionStart;
                                       var newSelEnd = ChartAreas[0].CursorX.SelectionEnd;

                                       if (!(Math.Abs(_oldSelEnd - newSelEnd) > Tolerance) &&
                                           !(Math.Abs(newSelStart - _oldSelStart) > Tolerance)) return;
                                       
                                       _oldSelStart = newSelStart;
                                       _oldSelEnd = newSelEnd;

                                       AddNonSportEntries();
                                   };
        }
        
        private const double Tolerance = 0.1;

        protected DateTime GetEndOfInterval(DateTime now)
        {
            switch (GetGrouping())
            {
                case GroupingType.OneDay:
                    return now.AddDays(1);
                case GroupingType.OneWeek:
                    return now.AddDays(7 - (int)now.DayOfWeek + 1);
                case GroupingType.TwoWeeks:
                    return now.AddDays(14 - (int)now.DayOfWeek + 1);
                case GroupingType.OneMonth:
                    now = now.AddMonths(1);
                    return now.AddDays(1 - now.Day);
                case GroupingType.ThreeMonths:
                    now = now.AddMonths(3);
                    return now.AddDays(1 - now.Day);
                case GroupingType.SixMonths:
                    now = now.AddMonths(6);
                    return now.AddDays(1 - now.Day);
                case GroupingType.OneYear:
                    now = now.AddYears(1);
                    return now.AddMonths(1 - now.Month).AddDays(1 - now.Day);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected DateTime GetStartOfInterval(DateTime now)
        {
            switch (GetGrouping())
            {
                case GroupingType.OneDay:
                    return now;
                case GroupingType.OneWeek:
                case GroupingType.TwoWeeks:
                    return now.AddDays(1 - (int) now.DayOfWeek);
                case GroupingType.OneMonth:
                case GroupingType.ThreeMonths:
                case GroupingType.SixMonths:
                    return now.AddDays(1 - now.Day);
                case GroupingType.OneYear:
                    return now.AddMonths(1 - now.Month).AddDays(1 - now.Day);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
