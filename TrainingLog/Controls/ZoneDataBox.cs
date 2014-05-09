using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public partial class ZoneDataBox : UserControl
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }
        public Color Color4 { get; set; }
        public Color Color5 { get; set; }

        public Brush Brush1 { get; set; }
        public Brush Brush2 { get; set; }
        public Brush Brush3 { get; set; }
        public Brush Brush4 { get; set; }
        public Brush Brush5 { get; set; }

        private Brush[] Brushes
        {
            get { return new[] {Brush1, Brush2, Brush3, Brush4, Brush5}; }
        }

        public ZoneData ZoneData { get; set; }

        public ZoneDataBox()
        {
            Color1 = Color.DarkGray;
            Color2 = Color.LightSkyBlue;
            Color3 = Color.YellowGreen;
            Color4 = Color.Orange;
            Color5 = Color.OrangeRed;
            
            Brush1 = new SolidBrush(Color1);
            Brush2 = new SolidBrush(Color2);
            Brush3 = new SolidBrush(Color3);
            Brush4 = new SolidBrush(Color4);
            Brush5 = new SolidBrush(Color5);

            InitializeComponent();
        }

        private void ZoneDataBoxPaint(object sender, PaintEventArgs e)
        {
            if (ZoneData.IsEmpty)
                return;

            var seconds = ZoneData.Duration.TotalSeconds;

            var pixelPerSecond = Width/seconds;

            var x = 0;

            using (var g = e.Graphics)
            {
                for (var i = 0; i < Brushes.Length; i++)
                {
                    var foo = (int) (ZoneData.GetZone(i + 1).TotalSeconds*pixelPerSecond);
                    if (i == Brushes.Length - 1)
                        foo = Width - x;

                    if (foo == 0)
                        continue;

                    g.FillRectangle(Brushes[i], x, 0, foo, Height);
                    x += foo;
                }
            }
        }
    }
}
