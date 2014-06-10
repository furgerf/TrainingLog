using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public partial class ZoneDataBox : UserControl
    {
        #region Public Fields

        public static readonly Color Zone1Color = Color.DarkGray;
        public static readonly Color Zone2Color = Color.LightSkyBlue;
        public static readonly Color Zone3Color = Color.YellowGreen;
        public static readonly Color Zone4Color = Color.Orange;
        public static readonly Color Zone5Color = Color.OrangeRed;

        public static Color[] ZoneColors { get { return new[] { Zone1Color, Zone2Color, Zone3Color, Zone4Color, Zone5Color }; } }

        public Brush Brush1 { get; set; }
        public Brush Brush2 { get; set; }
        public Brush Brush3 { get; set; }
        public Brush Brush4 { get; set; }
        public Brush Brush5 { get; set; }

        public ZoneData ZoneData { get; set; }

        public string OverlayText { get { return labText.Text; } set { labText.Text = value; } }

        #endregion

        #region Private Fields

        private Brush[] Brushes
        {
            get { return new[] {Brush1, Brush2, Brush3, Brush4, Brush5}; }
        }

        #endregion

        #region Constructor

        public ZoneDataBox()
        {
            Brush1 = new SolidBrush(Zone1Color);
            Brush2 = new SolidBrush(Zone2Color);
            Brush3 = new SolidBrush(Zone3Color);
            Brush4 = new SolidBrush(Zone4Color);
            Brush5 = new SolidBrush(Zone5Color);

            InitializeComponent();
        }

        #endregion

        #region Event Handling

        private void ZoneDataBoxPaint(object sender, PaintEventArgs e)
        {
            if (ZoneData.IsEmpty)
                return;

            var x = 0;

            using (var g = e.Graphics)
            {
                for (var i = 0; i < Brushes.Length; i++)
                {
                    var curWidth = (int) (ZoneData.GetZonePercentage(i + 1) * Width);
                    if (i == Brushes.Length - 1)
                        curWidth = Width - x;

                    if (curWidth == 0)
                        continue;

                    g.FillRectangle(Brushes[i], x, 0, curWidth, Height);
                    x += curWidth;
                }
            }
        }

        private void ZoneDataBoxSizeChanged(object sender, System.EventArgs e)
        {
            labText.Location = new Point((Width - labText.Width) / 2, (Height - labText.Height) / 2);
        }

        #endregion
    }
}
