using System;
using System.Drawing;
using System.Windows.Forms;

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
                lisEntries.Columns.Clear();
                foreach (var s in value)
                    lisEntries.Columns.Add(s, s);
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
            lisEntries.Items.Clear();
        }

        public bool AddEntry(string[] data)
        {
            if (data.Length != lisEntries.Columns.Count)
                return false;

            lisEntries.Items.Add(new ListViewItem(data));

            return true;
        }

        private void EntryListControlSizeChanged(object sender, EventArgs e)
        {
            var listHeight = Height - grpEntries.Location.X - grpEntries.Location.X;
            lisEntries.Height = listHeight > 0 ? listHeight : 0;

            grpFilter.Width = Width;
            grpEntries.Size = new Size(Width, Height - grpEntries.Location.Y);
            lisEntries.Size = new Size(Width - 4, grpEntries.Height - 14);
        }
    }
}
