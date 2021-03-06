using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingLog.Controls
{
    public class TimeSpanTextBox : TextBox
    {
        #region Public Fields

        public bool IsValueValid { get { return !TimeSpan.Equals(null); } }

        public TimeSpan? TimeSpan
        {
            get
            {
                var txt = Text;
                var split = txt.Split(':');
                while (split.Length < 3)
                {
                    txt = "00:" + txt;
                    split = txt.Split(':');
                }

                try
                {
                    return System.TimeSpan.Parse(txt);
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        return null;
                    }

                    throw;
                }
            }
        }

        #endregion

        #region Constructor

        public TimeSpanTextBox()
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
                && e.KeyChar != ':')
            {
                e.Handled = true;
            }

            // only allow two decimal points
            if (e.KeyChar == ':'
                && ((TextBox)sender).Text.Split(':').Length > 2)
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
