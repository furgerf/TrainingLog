using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrainingLog.Forms;

namespace TrainingLog.Controls
{
    public partial class ControlList : UserControl
    {
        #region Public Fields

        public int ItemHeight
        {
            get { return _itemHeight; }
            set { _itemHeight = value; }
        }

        public ColumnHeader[] Columns { get { return _columns.ToArray(); } }

        public Control[][] Items { get { return _controls.ToArray(); } }

        public delegate void OnItemsChanged();

        public event OnItemsChanged ItemsChanged;

        #endregion

        #region Private Fields

        private readonly List<ColumnHeader> _columns = new List<ColumnHeader>();

        private readonly List<Control[]> _controls = new List<Control[]>();
        
        private int _itemHeight = 20;

        private int _sortedColumnIndex;

        private SortOrder _sortOrder;

        private readonly List<IFilter> _filters = new List<IFilter>(); 

        #endregion

        #region Constructor

        public ControlList()
        {
            InitializeComponent();

            // sort rows on column click
            lisHeader.ColumnClick += SortColumns;

            // so it doesn't overlay the header when scrolling
            panArea.SendToBack();
        }

        #endregion

        #region Main Methods

        public void ClearColumns()
        {
            lisHeader.Columns.Clear();
            _columns.Clear();
        }

        public void AddColumn(string name, int width)
        {
            foreach (var cc in _controls.SelectMany(c => c))
                cc.Parent = null;

            lisHeader.Columns.Add(name, width);
            _columns.Add(lisHeader.Columns[lisHeader.Columns.Count - 1]);
        }

        public void AddColumn(EntryListColumn column)
        {
            AddColumn(column.Header, column.Width);
        }

        public void AddColumns(string[] names, int[] widths)
        {
            if (names.Length != widths.Length)
                throw new ArgumentException();

            for (var i = 0; i < names.Length; i++)
                AddColumn(names[i], widths[i]);
        }

        public void AddColumns(EntryListColumn[] columns)
        {
            foreach (var c in columns)
                AddColumn(c.Header, c.Width);
        }

        public void AddItem(Control[] controls)
        {
            if (controls.Length != _columns.Count)
                throw new ArgumentException();

            var x = 1;
            for (var i = 0; i < controls.Length; i++)
            {
                controls[i].Parent = panArea;
                controls[i].Location = new Point(x, _controls.Count * ItemHeight);
                controls[i].Size = new Size(_columns[i].Width, ItemHeight);

                x += _columns[i].Width;
            }

            _controls.Add(controls);

            panArea.Height = ItemHeight * _controls.Count < vscScroll.Height ? vscScroll.Height : ItemHeight * _controls.Count;
            vscScroll.Maximum = panArea.Height < vscScroll.Height ? 0 : panArea.Height - vscScroll.Height;
            vscScroll.Enabled = vscScroll.Maximum != 0;

            if (ItemsChanged != null)
                ItemsChanged();
        }

        public void ClearItems()
        {
            foreach (Control c in panArea.Controls)
                c.Parent = null;

            _controls.Clear();

            panArea.Height = ItemHeight * _controls.Count < vscScroll.Height ? vscScroll.Height : ItemHeight * _controls.Count;
            vscScroll.Maximum = panArea.Height < vscScroll.Height ? 0 : panArea.Height - vscScroll.Height;
            vscScroll.Enabled = vscScroll.Maximum != 0;

            if (ItemsChanged != null)
                ItemsChanged();
        }

        #endregion

        #region Event Handling

        private void ControlListResize(object sender, EventArgs e)
        {
            // fix control size
            lisHeader.Width = Width - vscScroll.Width;
            panArea.Width = lisHeader.Width;
            panArea.Height = panArea.Height > Height - lisHeader.Height ? panArea.Height : Height - lisHeader.Height;
            vscScroll.Location = new Point(panArea.Width, lisHeader.Height);
            vscScroll.Height = Height - lisHeader.Height;
            
            // update scrollbar
            vscScroll.Maximum = panArea.Height < vscScroll.Height ? 0 : panArea.Height - vscScroll.Height;
            vscScroll.Enabled = vscScroll.Maximum != 0;
        }

        private void LisHeaderColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // forces column width to remain the same
            e.Cancel = true;
            e.NewWidth = _columns[e.ColumnIndex].Width;
        }

        private void VscScrollScroll(object sender, ScrollEventArgs e)
        {
            // move area
            panArea.Location = new Point(panArea.Location.X, panArea.Location.Y - (e.NewValue - e.OldValue));
        }

        private void SortColumns(object sender, ColumnClickEventArgs e)
        {
            SortColumn(e.Column);
        }

        public void SortByDate()
        {
            SortColumn(2);
        }

        private static bool IsBefore(string a, string b, bool numeric, SortOrder order)
        {
            bool res;

            if (numeric)
            {
                double c;
                double d;

                if (!double.TryParse(a, out c))
                    throw new ArgumentException();
                if (!double.TryParse(b, out d))
                    throw new ArgumentException();

                res = c < d;
            }
            else
                res = String.Compare(a, b, StringComparison.Ordinal) > 0;

            return order == SortOrder.Descending ^ res;
        }

        private void SortColumn(int column)
        {
            if (_controls.Count == 0)
                return;

            _sortOrder = _sortedColumnIndex == column ? SortOrder.Ascending : SortOrder.Descending;
            _sortedColumnIndex = column;

            if (_controls[0][_sortedColumnIndex].Tag == null)
                throw new ArgumentException();
            double d;
            var numericSort = double.TryParse(_controls[0][_sortedColumnIndex].Tag.ToString(), out d);
            if (_controls.Any(c => c[_sortedColumnIndex].Tag == null || double.TryParse(c[_sortedColumnIndex].Tag.ToString(), out d) != numericSort))
                throw new ArgumentException();

            // insertion sort
            var newControls = new List<Control[]>();
            
            foreach (var c in _controls)
            {
                var inserted = false;
                for (var i = 0; i < newControls.Count; i++)
                    if (c[_sortedColumnIndex].Tag.Equals(newControls[i][_sortedColumnIndex].Tag) ||
                        IsBefore(c[_sortedColumnIndex].Tag.ToString(), newControls[i][_sortedColumnIndex].Tag.ToString(),
                                 numericSort, _sortOrder))
                    {
                        newControls.Insert(i, c);
                        inserted = true;
                        break;
                    }

                if (!inserted)
                    newControls.Add(c);
            }

            ClearItems();
            foreach (var c in newControls)
                AddItem(c);
        }

        //TODO: Add event that is triggered whenever items change so that ELC can set back colors when that happens

        #endregion
    }
}
