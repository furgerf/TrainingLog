using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
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
        public string DrawColorString { get { return DrawColor == null ? "" : DrawColor.Value.Name; }  set { DrawColor = Color.FromName(value); } }
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

        public void AddEntryToChart(ChartArea area, Series series, AnnotationCollection annotations, double y = 0)
        {
            if (Date == null)
                throw new Exception();

            var p1 = new DataPoint(Date.Value.AddDays(-1).ToOADate(), y);
            var p2 = new DataPoint(GetEndDate.ToOADate(), y);

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
                //BackColor = Color.Transparent,
                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                SmartLabelStyle = { IsMarkerOverlappingAllowed = true, AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes, MaxMovingDistance = 100, IsOverlappedHidden = false, MovingDirection = LabelAlignmentStyles.Bottom | LabelAlignmentStyles.BottomLeft | LabelAlignmentStyles.BottomRight },
                AnchorAlignment = ContentAlignment.TopCenter,
                ToolTip = (Note ?? "ERROR: NOT SET")  + "\n(" + Date.Value.ToShortDateString() + " - " + GetEndDate.ToShortDateString() + ")",
                Alignment = ContentAlignment.MiddleCenter
            };

            annotations.Add(line);
            annotations.Add(callout);
        }

        public NonSportEntry Clone()
        {
            string xmlString;
            NonSportEntry result;

            // serialize
            using (var ms = new MemoryStream())
            {
                new XmlSerializer(typeof(NonSportEntry)).Serialize(ms, this);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    xmlString = sr.ReadToEnd();
                }
            }

            // deserialize
            using (var sr = new StringReader(xmlString))
            {
                using (var tr = new XmlTextReader(sr))
                {
                    var serializer = new XmlSerializer(typeof(NonSportEntry));
                    result = (NonSportEntry)serializer.Deserialize(tr);
                }
            }

            return result;
        }

        #endregion
    }
}
