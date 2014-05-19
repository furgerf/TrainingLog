using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public class DecimalTextBox : TextBox
    {
        #region Public Fields

        public bool IsValueValid { get { return Decimal != decimal.MinValue; } }

        public decimal Decimal
        {
            get
            {
                decimal dec;

                return decimal.TryParse(Text, out dec) ? dec : decimal.MinValue;
            }
        }

        #endregion

        #region Constructor

        public DecimalTextBox()
        {
            KeyPress += ValidateKey;
            TextChanged += ValidateText;
        }

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
            BackColor = IsValueValid || Text.Equals(string.Empty) ? Color.White : Color.Firebrick;
        }

        #endregion
    }
}
