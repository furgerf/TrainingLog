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

        private int _sortedColumnIndex = -1;

        private SortOrder _sortOrder;

        #endregion

        #region Constructor

        public ControlList()
        {
            InitializeComponent();

            // sort rows on column click
            lisHeader.ColumnClick += SortColumns;

            // update scrollbar
            panArea.SizeChanged += (s, e) => UpdateScrollbar();
            ItemsChanged += UpdateScrollbar;

            // add mouse scroll wheel capability
            panArea.MouseWheel += (s, e) =>
                                      {
                                          var oldValue = vscScroll.Value;
                                          vscScroll.Value -= e.Delta;
                                          if (vscScroll.Value < 0)
                                              vscScroll.Value = 0;
                                          if (vscScroll.Value > vscScroll.Maximum)
                                              vscScroll.Value = vscScroll.Maximum;
                                          var newValue = vscScroll.Value;
                                          VscScrollScroll(s, new ScrollEventArgs(ScrollEventType.EndScroll, oldValue, newValue));
                                      };
        }

        #endregion

        #region Main Methods

        public void AddColumns(EntryListColumn[] columns)
        {
            foreach (var c in columns)
                AddColumn(c);
        }

        public void AddColumn(EntryListColumn column)
        {
            foreach (var cc in _controls.SelectMany(c => c))
                cc.Parent = null;

            lisHeader.Columns.Add(column.Header, column.Width);
            _columns.Add(lisHeader.Columns[lisHeader.Columns.Count - 1]);
        }

        public void ClearColumns()
        {
            lisHeader.Columns.Clear();
            _columns.Clear();
        }

        private void ArrangeRows()
        {
            for (var j = 0; j < _controls.Count; j++)
            {
                var x = 1;
                for (var i = 0; i < _controls[j].Length; i++)
                {
                    _controls[j][i].Location = new Point(x, j*ItemHeight);
                    x += _columns[i].Width;
                }
            }

            panArea.Height = ItemHeight * _controls.Count < vscScroll.Height ? vscScroll.Height : ItemHeight * _controls.Count;
            UpdateScrollbar();
        }

        public void AddItem(Control[] controls, bool updateControls = true)
        {
            if (controls.Length != _columns.Count)
                throw new ArgumentException();

            var index = 0;
            if (_sortedColumnIndex >= 0)
            {
                double d;
                var numeric = double.TryParse(controls[_sortedColumnIndex].Tag.ToString(), out d);
                while (index < _controls.Count && !IsBefore(controls[_sortedColumnIndex].Tag.ToString(),
                                _controls[index][_sortedColumnIndex].Tag.ToString(), numeric, _sortOrder))
                    index++;
            }

            for (var i = 0; i < controls.Length; i++)
            {
                controls[i].Parent = panArea;
                controls[i].Size = new Size(_columns[i].Width, ItemHeight);
            }

            _controls.Insert(index, controls);

            if (!updateControls)
                return;

            ArrangeRows();

            if (ItemsChanged != null)
                ItemsChanged();
        }

        public void RemoveItem(Control[] item)
        {
            // remove old item
            foreach (var c in item)
                c.Parent = null;
            _controls.Remove(item);
            
            ArrangeRows();

            if (ItemsChanged != null)
                ItemsChanged();
        }

        public void ClearItems()
        {
            foreach (Control c in panArea.Controls)
                c.Parent = null;

            _controls.Clear();

            ArrangeRows();

            if (ItemsChanged != null)
                ItemsChanged();
        }

        private void UpdateScrollbar()
        {
            vscScroll.Maximum = panArea.Height < panBack.Height ? 0 : panArea.Height - panBack.Height;
            vscScroll.Enabled = vscScroll.Maximum != 0;
            vscScroll.SmallChange = vscScroll.Maximum / 50;
            vscScroll.LargeChange = vscScroll.Maximum / 10;
        }

        #endregion

        #region Event Handling

        private void ControlListResize(object sender, EventArgs e)
        {
            // fix control size
            lisHeader.Width = Width - vscScroll.Width;
            panBack.Size = new Size(lisHeader.Width, vscScroll.Height);
            panArea.Size = new Size(panBack.Width, panArea.Height > panBack.Height ? panArea.Height : panBack.Height);
            vscScroll.Location = new Point(panBack.Width, lisHeader.Height);
            vscScroll.Height = Height - lisHeader.Height;
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
            panArea.Location = new Point(panArea.Location.X, -vscScroll.Value);
        }

        private void SortColumns(object sender, ColumnClickEventArgs e)
        {
            SortColumn(e.Column);
        }

        public void SortByDate()
        {
            DateTime d;
            if (DateTime.TryParse(_controls[0][2].Text, out d))
            {
                SortColumn(2);
                return;
            }

            for (var i = 0; i < _controls[0].Length; i++)
                if (DateTime.TryParse(_controls[0][i].Text, out d))
                {
                    SortColumn(i);
                    return;
                }
        }

        private static bool IsBefore(string a, string b, bool numeric, SortOrder order)
        {
            if (!numeric)
                return (order == SortOrder.Descending) ^ (String.Compare(a, b, StringComparison.Ordinal) < 0);

            double c;
            double d;

            if (!double.TryParse(a, out c))
                throw new ArgumentException();
            if (!double.TryParse(b, out d))
                throw new ArgumentException();

            return (order == SortOrder.Descending) ^ (c < d);
        }

        private void SortColumn(int column)
        {
            if (_controls.Count == 0)
                return;

            _sortOrder = _sortedColumnIndex == column
                             ? _sortOrder == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending
                             : SortOrder.Descending;
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

            _controls.Clear();
            foreach (var c in newControls)
                _controls.Add(c);

            for (var j = 0; j < _controls.Count; j++){
                var x = 1;
                for (var i = 0; i < _controls[j].Length; i++)
                {
                    _controls[j][i].Location = new Point(x, j * ItemHeight);
                    x += _columns[i].Width;
                }
            }

            if (ItemsChanged != null)
                ItemsChanged();
        }

        #endregion
    }
}
