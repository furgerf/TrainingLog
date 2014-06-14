using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace TrainingLog.Entries
{
    [XmlType("NonSportEntry")]
    public class NonSportEntry : Entry
    {
        #region Public Fields

        [XmlElement("EndDate")]
        public DateTime? EndDate { get; set; }
        public bool EndDateSpecified { get { return EndDate != null; } }

        [XmlIgnore]
        public DateTime GetEndDate { get { return EndDate != null ? EndDate.Value : Date ?? DateTime.MaxValue; } }

        [XmlIgnore]
        public Color? DrawColor { get; set; }

        [XmlElement("Color")]
        public string DrawColorString { get { return DrawColor == null ? "" : DrawColor.Value.ToString(); }  set { DrawColor = Color.FromName(value); } }
        public bool DrawColorStringSpecified { get { return !string.IsNullOrEmpty(DrawColorString); } }

        #endregion

        #region Constructor

        public NonSportEntry()
            : base(Common.EntryType.NonSport)
        {
            // constructor for serializer
        }

        public NonSportEntry(DateTime startDate, DateTime endDate, string description, Color? color = null)
            : base(Common.EntryType.NonSport)
        {
            Date = startDate;
            EndDate = endDate;
            Note = description;
            DrawColor = color;
        }

        public NonSportEntry(DateTime startDate, string description, Color? color = null)
            : base(Common.EntryType.NonSport)
        {
            Date = startDate;
            Note = description;
            DrawColor = color;
        }

        #endregion

        #region Main Methods

        public void AddEntryToChart(ChartArea area, Series series, AnnotationCollection annotations)
        {
            if (Date == null)
                throw new Exception();

            var p1 = new DataPoint(Date.Value.ToOADate(), 0);
            var p2 = new DataPoint(GetEndDate.ToOADate(), 0);

            series.Points.Add(p1);
            series.Points.Add(p2);
            
            var line = new LineAnnotation
            {
                LineWidth = 10,
                Height = 0,
                LineColor = DrawColor ?? Color.Red,
                ClipToChartArea = area.Name,
            };
            line.SetAnchor(p1, p2);

            var callout = new CalloutAnnotation
            {
                Text = Note ?? "ERROR: NOT SET",
                AnchorDataPoint = p1,
                CalloutStyle = CalloutStyle.RoundedRectangle,
                ForeColor = DrawColor ?? Color.Red,
                LineColor = DrawColor ?? Color.Red,
                LineWidth = 2
            };

            annotations.Add(line);
            annotations.Add(callout);
        }

        #endregion
    }
}
