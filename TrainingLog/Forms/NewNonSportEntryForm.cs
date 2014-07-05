using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Entries;

namespace TrainingLog.Forms
{
    public partial class NewNonSportEntryForm : Form
    {
        #region Public Fields

        public NonSportEntry Entry { get; private set; }

        #endregion

        #region Constructor

        public NewNonSportEntryForm(NonSportEntry entry) : this()
        {
            txtName.Text = entry.Note;
            dtpFrom.Value = entry.Date.Value;
            dtpTo.Value = entry.GetEndDate;
            comColorNames.SelectedIndex = comColorNames.Items.IndexOf(entry.DrawColor.Value.Name);
        }

        public NewNonSportEntryForm()
        {
            InitializeComponent();

            foreach (KnownColor kc in Enum.GetValues(typeof (KnownColor)))
                comColorNames.Items.Add(Color.FromKnownColor(kc).Name);
            comColorNames.Text = comColorNames.Items[0].ToString();
        }

        #endregion

        #region Methods

        private static int ColorDifference(Color a, Color b)
        {
            return Math.Abs(a.R - b.R) + Math.Abs(a.G - b.G) + Math.Abs(a.B - b.B);
        }

        #endregion

        #region Event Handling

        private void LabColorClick(object sender, EventArgs e)
        {
            // Show the color dialog.
            colPicker.Color = labColor.BackColor;
            var result = colPicker.ShowDialog();
            // See if user pressed ok.
            if (result != DialogResult.OK) return;
            var closest = Color.Empty;
            foreach (var known in from KnownColor kc in Enum.GetValues(typeof (KnownColor)) select Color.FromKnownColor(kc))
            {
                if (colPicker.Color.ToArgb() == known.ToArgb())
                {
                    labColor.BackColor = colPicker.Color;
                    return;
                }

                if (closest == Color.Empty)
                {
                    closest = known;
                    continue;
                }

                if (ColorDifference(colPicker.Color, known) < ColorDifference(colPicker.Color, closest))
                    closest = known;
            }

            //labColor.BackColor = closest;
            comColorNames.SelectedIndex = comColorNames.Items.IndexOf(closest.Name);
            MessageBox.Show(
                "Color was slightly altered (absolute RGB difference: " + ColorDifference(closest, colPicker.Color) + ").",
                "Color altered", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ComColorNamesTextChanged(object sender, EventArgs e)
        {
            labColor.BackColor = Color.FromName(comColorNames.Text);
        }

        private void DtpFromValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
                dtpTo.Value = dtpFrom.Value;
        }

        private void DtpToValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
                dtpFrom.Value = dtpTo.Value;
        }

        private void ButOkClick(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name", "No name entered", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            Entry = new NonSportEntry(dtpFrom.Value.Date, dtpTo.Value.Date, txtName.Text, labColor.BackColor);

            Close();
        }

        private void ButCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
