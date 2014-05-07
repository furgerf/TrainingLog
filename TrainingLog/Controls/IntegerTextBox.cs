using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public class IntegerTextBox : TextBox
    {
        #region Public Fields

        public bool IsValueValid { get { return Integer != int.MinValue; } }

        public int Integer
        {
            get
            {
                int i;

                return int.TryParse(Text, out i) ? i : int.MinValue;
            }
        }

        #endregion

        #region Private Fields



        #endregion

        #region Constructor

        public IntegerTextBox()
        {
            KeyPress += ValidateKey;
            TextChanged += ValidateText;
        }

        #endregion

        #region Main Methods



        #endregion

        #region Event Handling

        private void ValidateKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void ValidateText(object sender, EventArgs e)
        {
            BackColor = IsValueValid || Text.Equals(string.Empty) ? Color.White : Color.LightSalmon;
        }

        #endregion
    }
}
