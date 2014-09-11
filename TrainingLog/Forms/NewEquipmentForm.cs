using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TrainingLog.Forms
{
    public partial class NewEquipmentForm : Form
    {
        private string _imagePath;
        
        public Equipment Equipment { get; private set; }

        public NewEquipmentForm(Equipment equipment) : this()
        {
            txtName.Text = equipment.Name;
            txtImageName.Text = equipment.ImageName;
            picImage.Image = equipment.Image;
            comSport.Text = equipment.Sport.ToString();
        }

        public NewEquipmentForm()
        {
            InitializeComponent();

            foreach (var s in from Common.Sport s in Enum.GetValues(typeof (Common.Sport)) where s != Common.Sport.Count select s)
                comSport.Items.Add(s.ToString());
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name", "No name provided", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (comSport.Text == "")
            {
                MessageBox.Show("Please enter a sport", "No sport provided", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists("images"))
                Directory.CreateDirectory("images");

            if (!File.Exists("images\\" + txtImageName.Text))
                File.Copy(_imagePath, "images\\" + txtImageName.Text);

            Equipment = new Equipment(txtName.Text, txtImageName.Text, (Common.Sport)Enum.Parse(typeof(Common.Sport), comSport.Text));

            Close();
        }

        private void butChooseImage_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Multiselect = false
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            txtImageName.Text = dlg.SafeFileName;
            _imagePath = dlg.FileName;

            picImage.Image = Image.FromFile(dlg.FileName);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
