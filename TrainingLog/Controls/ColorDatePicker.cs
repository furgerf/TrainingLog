using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TrainingLog.Controls
{
    /// <summary>
    ///     A derivation of DateTimePicker allowing to change background color
    /// </summary>
    class ColorDatePicker : DateTimePicker
    {
        private Color _backColor;

        public ColorDatePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            BackDisabledColor = Color.FromKnownColor(KnownColor.Control);
            BackColorChanged += (s, e) =>
                                    {
                                        if (Enabled)
                                            _backColor = ((ColorDatePicker) s).BackColor;
                                    };
        }

        /// <summary>
        ///     Gets or sets the background color of the control
        /// </summary>
        [Browsable(true)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Gets or sets the background color of the control when disabled
        /// </summary>
        [Category("Appearance"), Description("The background color of the component when disabled"), Browsable(true)]
        public Color BackDisabledColor { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = CreateGraphics();
            //Graphics g = e.Graphics;
            
            //The dropDownRectangle defines position and size of dropdownbutton block, 
            //the width is fixed to 17 and height to 16. The dropdownbutton is aligned to right
            var dropDownRectangle = new Rectangle(ClientRectangle.Width - 17, 0, 17, 16);
            Brush bkgBrush;
            ComboBoxState visualState;
            ButtonState btState;

            //When the control is enabled the brush is set to Backcolor, 
            //otherwise to color stored in _backDisabledColor
            if (Enabled) {
                bkgBrush = new SolidBrush(_backColor);
                 visualState = ComboBoxState.Normal;
                btState = ButtonState.Normal;
            }
            else {
                bkgBrush = new SolidBrush(_backColor);
                visualState = ComboBoxState.Disabled;
                btState = ButtonState.Inactive;
            }

            // Painting...in action

            //Filling the background
            g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            
            //Drawing the datetime text
            g.DrawString(Text, Font, Brushes.Black, 0, 2);

            //Drawing the dropdownbutton using ComboBoxRenderer            
            if (!ComboBoxRenderer.IsSupported)
                ControlPaint.DrawComboButton(g, dropDownRectangle, btState);
            else
                ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, visualState);

            g.Dispose();
            bkgBrush.Dispose();
        }
    }
}
