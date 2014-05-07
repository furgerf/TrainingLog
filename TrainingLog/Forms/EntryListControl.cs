using System;
using System.Drawing;
using System.Windows.Forms;
using GlacialComponents.Controls;

namespace TrainingLog.Forms
{
    public partial class EntryListControl : UserControl
    {
        public string EntryName
        {
            get { return _entryName; }
            set
            {
                _entryName = value;
                grpEntries.Text = value + " - Entries";
                grpFilter.Text = value + " - Filter";
            }
        }

        public string[] Columns
        {
            get { return _columns; }
            set 
            { 
                _columns = value;
                gliEntries.Columns.Clear();

                foreach (var s in value)
                    gliEntries.Columns.Add(new GLColumn(s));
            }
        }


        private string[] _columns;

        private string _entryName;

        public EntryListControl()
        {
            InitializeComponent();
        }

        public void ClearEntries()
        {
            gliEntries.Items.Clear();
        }

        public bool AddEntry(string[] data)
        {
            if (data.Length != gliEntries.Columns.Count)
                return false;

            var gli = gliEntries.Items.Add(data[0]);

            for (var i = 1; i < data.Length; i++)
                gli.SubItems[i].Text = data[i];

            //gliEntries.Items.Add(gli);
            return true;
        }

        private void EntryListControlSizeChanged(object sender, EventArgs e)
        {
            var listHeight = Height - grpEntries.Location.X - grpEntries.Location.X;
            gliEntries.Height = listHeight > 0 ? listHeight : 0;

            grpFilter.Width = Width;
            grpEntries.Size = new Size(Width, Height - grpEntries.Location.Y);
            gliEntries.Size = new Size(Width - 4, grpEntries.Height - 14);
        }

        private void lisEntries_ItemActivate(object sender, EventArgs e)
        {
            //gliEntries.SelectedItems[0].BeginEdit();
        }

        private void lisEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lisEntries.SelectedItems[0].Text);
        }
    }
}
