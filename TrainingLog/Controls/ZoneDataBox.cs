using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public partial class ZoneDataBox : UserControl
    {
        #region Public Fields

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
            Brush1 = new SolidBrush(Color.DarkGray);
            Brush2 = new SolidBrush(Color.LightSkyBlue);
            Brush3 = new SolidBrush(Color.YellowGreen);
            Brush4 = new SolidBrush(Color.Orange);
            Brush5 = new SolidBrush(Color.OrangeRed);

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
