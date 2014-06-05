using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Entries;
using TrainingLog.Forms;

namespace TrainingLog.Controls
{
    public partial class EntryListControl : UserControl
    {
        #region Public Fields

        public Color FirstColor
        {
            get { return _colors[0]; }
            set { _colors[0] = value; }
        }

        public Color SecondColor
        {
            get { return _colors[1]; }
            set { _colors[1] = value; }
        }

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

        public EntryListColumn[] Columns
        {
            get { return _columns; }
            set
            {
                _columns = value;

                cliEntries.ClearColumns();

                // edit/delete
                cliEntries.AddColumn("", ButtonColumnWidth);
                cliEntries.AddColumn("", ButtonColumnWidth);

                // "normal" columns
                cliEntries.AddColumns(_columns);
            }
        }

        #endregion

        #region Private Fields

        private const int ButtonColumnWidth = 23;

        private EntryListColumn[] _columns;

        private string _entryName;

        private readonly Dictionary<int, Entry> _entryMap = new Dictionary<int, Entry>();

        private readonly Color[] _colors = new[] {Color.White, Color.LightGray};

        #endregion

        #region Constructor

        public EntryListControl()
        {
            InitializeComponent();

            cliEntries.ItemHeight = ButtonColumnWidth;

            cliEntries.ItemsChanged += SetBackColor;
        }

        #endregion

        #region Main Methods

        public void SortByDate()
        {
            cliEntries.SortByDate();
        }

        public void ClearEntries()
        {
            _entryMap.Clear();
            cliEntries.ClearItems();
        }

        public bool AddEntry(Control[] data, Entry entry)
        {
            if (data.Length != cliEntries.Columns.Length - 2)
                return false;

            var id = _entryMap.Keys.Count;
            if (_entryMap.ContainsKey(id))
            {
                id = -1;

                // there must be an unused key
                for (var i = 0; i < id; i++)
                    if (!_entryMap.ContainsKey(i))
                    {
                        id = i;
                        break;
                    }

                if (id == -1)
                    throw new Exception();
            }

            _entryMap.Add(id, entry);


            var butDelete = new Button
                                {
                                    Image = Common.IconEdit.ToBitmap(),
                                    ImageAlign = ContentAlignment.MiddleCenter,
                                    FlatStyle = FlatStyle.Flat,
                                    Name = id.ToString(CultureInfo.InvariantCulture)
                                };

            var butEdit = new Button
                              {
                                  Image = Common.IconDelete.ToBitmap(),
                                  ImageAlign = ContentAlignment.MiddleCenter,
                                  FlatStyle = FlatStyle.Flat,
                                  Name = id.ToString(CultureInfo.InvariantCulture)
                              };

            cliEntries.AddItem(new[] {butDelete, butEdit}.Concat(data).ToArray());

            return true;
        }

        private void SetBackColor()
        {
            var controls = cliEntries.Items;
            for (var i = 0; i < controls.Length; i++)
                foreach (var c in controls[i].Where(c => _colors.Contains(c.BackColor)))
                    c.BackColor = _colors[i%2];
        }

        #endregion

        #region Event Handling

        private void EntryListControlSizeChanged(object sender, EventArgs e)
        {
            grpEntries.Location = new Point(grpEntries.Location.X, false ? grpFilter.Height : 0);

            var listHeight = Height - grpEntries.Location.X - grpEntries.Location.X;
            cliEntries.Height = listHeight > 0 ? listHeight : 0;

            grpFilter.Width = Width;
            grpEntries.Size = new Size(Width, Height - grpEntries.Location.Y);
            cliEntries.Size = new Size(Width - 4, grpEntries.Height - 14);

            // adjust size to available width 
            var factor = Math.Floor(100 * cliEntries.Width / (double)_columns.Sum(w => w.Width)) / 100;
            for (var i = 0; i < _columns.Length; i++)
                _columns[i].Width = (int)(factor * _columns[i].Width);

            for (var i = 2; i < cliEntries.Columns.Length - 1; i++)
                cliEntries.Columns[i].Width = _columns[i - 2].Width;

            cliEntries.Columns[cliEntries.Columns.Length - 1].Width = Width - _columns.Sum(w => w.Width) + _columns[_columns.Length - 1].Width - ButtonColumnWidth - ButtonColumnWidth - 24;
        }

        #endregion
    }
}
