using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public class IntegerTextBox : TextBox
    {
        #region Public Fields

        public bool IsValueValid { get { return Integer != int.MinValue; } }

        public int? Integer
        {
            get
            {
                try
                {
                    return int.Parse(Text);
                }
                catch (FormatException)
                {
                    return null;
                }
            }
        }

        #endregion

        #region Constructor

        public IntegerTextBox()
        {
            KeyPress += ValidateKey;
            TextChanged += ValidateText;
        }

        #endregion

        #region Event Handling

        private static void ValidateKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void ValidateText(object sender, EventArgs e)
        {
            BackColor = IsValueValid || Text.Equals(string.Empty) ? Color.White : Color.Firebrick;
        }

        #endregion
    }
}
