using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GlacialComponents.Controls;
using TrainingLog.Forms;

namespace TrainingLog.Controls
{
    public partial class EntryListControl : UserControl
    {
        #region Public Fields

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

                gliEntries.Columns.Clear();

                for (var i = 0; i < _columns.Length; i++)
                {
                    gliEntries.Columns.Add(_columns[i].Header, _columns[i].Width);
                    gliEntries.Columns[i].TextAlignment = ContentAlignment.MiddleCenter;
                }
            }
        }

        public bool FilterVisible
        {
            get { return _filterVisible; }
            set
        {
            if (_filterVisible == value) return; _filterVisible = value;
            grpFilter.Visible = _filterVisible; EntryListControlSizeChanged(null, null);
        } }

        #endregion

        #region Private Fields

        private const int IntMaxDigits = 10;

        private int RowHeight { get { return gliEntries.ItemHeight; } }
        
        private bool _filterVisible = true;

        private EntryListColumn[] _columns;

        private string _entryName;

        private delegate string GetComparableString(Control c);

        private readonly Dictionary<Type, GetComparableString> _comparableStrings = new Dictionary<Type, GetComparableString>();

        #endregion

        #region Constructor

        public EntryListControl()
        {
            InitializeComponent();

            gliEntries.SortType = SortTypes.QuickSort;

            _comparableStrings.Add(typeof(TextBox), GetComparableStringTextBox);            // string:      compare directly
            _comparableStrings.Add(typeof(TimeSpanTextBox), GetComparableStringTextBox);    // TimeSpan:    compare directly
            _comparableStrings.Add(typeof(ComboBox), GetComparableStringTextBox);           // ComboBox:    compare directly
            _comparableStrings.Add(typeof(ColorDatePicker), GetComparableStringDateTime);   // DateTime:    compare YYYYMMDD
            _comparableStrings.Add(typeof(IntegerTextBox), GetComparableStringInteger);     // Integer:     fill with 0s and compare
            _comparableStrings.Add(typeof(DecimalTextBox), GetComparableStringDecimal);     // Decimal:     compare like integer
            _comparableStrings.Add(typeof(ZoneDataBox), GetComparableStringZoneData);       // ZoneData:    compare by weighted percentages
        }

        #endregion

        #region Comparing Methods

        private static string GetComparableStringTextBox(Control c)
        {
            return c.Text;
        }

        private static string GetComparableStringZoneData(Control c)
        {
            var zd = ((ZoneDataBox) c).ZoneData;

            var s = zd.IsEmpty ? "0" : (zd.GetZonePercentage(5)*5 + zd.GetZonePercentage(4)*4 + zd.GetZonePercentage(3)*3 +
                       zd.GetZonePercentage(2)*2 + zd.GetZonePercentage(1)).ToString();

            if (s.IndexOf('.') == -1)
                while (s.Length < IntMaxDigits)
                    s = "0" + s;
            else
                while (s.IndexOf('.') < IntMaxDigits)
                    s = "0" + s;

            return s;
        }

        private string GetComparableStringDecimal(Control c)
        {
            var s = c.Text;

            if (s.IndexOf('.') == -1)
                while (s.Length < IntMaxDigits)
                    s = "0" + s;
            else
                while (s.IndexOf('.') < IntMaxDigits)
                    s = "0" + s;

            return s;
        }

        private static string GetComparableStringInteger(Control c)
        {
            var s = c.Text;

            while (s.Length < IntMaxDigits)
                s = "0" + s;

            return s;
        }

        private static string GetComparableStringDateTime(Control c)
        {
            return ((DateTimePicker)c).Value.ToString("yyyyMMdd");
        }

        #endregion

        #region Main Methods

        public void SortByDate()
        {
            gliEntries.SortColumn(0);
            SetBackColor();
        }


        public void ClearEntries()
        {
            gliEntries.Items.Clear();
        }

        public bool AddEntry(Control[] data)
        {
            if (data.Length != gliEntries.Columns.Count)
                return false;

            var gli = gliEntries.Items.Add(data[0].Text);
            
            gli.BackColor = gliEntries.Count % 2 == 1 ? Color.White : Color.LightGray;

            for (var i = 0; i < data.Length; i++)
            {
                gli.SubItems[i].Text = _comparableStrings[data[i].GetType()](data[i]);
                gli.SubItems[i].Control = data[i];
                gli.SubItems[i].Control.Height = RowHeight;
                //gli.SubItems[i].Control.BackColor = gliEntries.Count % 2 == 1 ? Color.White : Color.LightGray;
                gli.SubItems[i].Control.TextChanged += ItemTextChanged;
            }

            return true;
        }

        private void SetBackColor()
        {
            for (var i = 0; i < gliEntries.Items.Count; i++)
            {
                gliEntries.Items[i].BackColor = i%2 == 0 ? Color.White : Color.LightGray;
                for (var j = 0; j < gliEntries.Items[i].SubItems.Count; j++)
                {
                    var txt = gliEntries.Items[i].SubItems[j].Text;
                    var index = txt.Contains('(') && txt.Contains(')') ? txt.Substring(txt.IndexOf('(') + 1,
                        txt.IndexOf(')') - txt.IndexOf('(') - 1) : "";

                    if ((gliEntries.Items[i].SubItems[j].Control is ComboBox) &&
                        Enum.GetNames(typeof (Common.Index)).Contains(gliEntries.Items[i].SubItems[j].Text))
                    {
                        //comfeeling
                    }
                    else if ((gliEntries.Items[i].SubItems[j].Control is TextBox) && txt.Contains('(') && txt.Contains(')') &&
                        Enum.GetNames(typeof(Common.Index)).Contains(index))
                    {
                        //txtsleep
                    }
                    else
                    {
                        gliEntries.Items[i].SubItems[j].Control.BackColor = i%2 == 0 ? Color.White : Color.LightGray;
                    }
                }
            }
        }

        #endregion

        #region Event Handling

        private void ItemTextChanged(object sender, EventArgs args)
        {
            // irgendwie so:
            //gli.SubItems[i].Text = _comparableStrings[data[i].GetType()](data[i]);
             
        }

        private void EntryListControlSizeChanged(object sender, EventArgs e)
        {
            grpEntries.Location = new Point(grpEntries.Location.X, FilterVisible ? grpFilter.Height : 0);

            var listHeight = Height - grpEntries.Location.X - grpEntries.Location.X;
            gliEntries.Height = listHeight > 0 ? listHeight : 0;

            grpFilter.Width = Width;
            grpEntries.Size = new Size(Width, Height - grpEntries.Location.Y);
            gliEntries.Size = new Size(Width - 4, grpEntries.Height - 14);

            // adjust size to available width 
            var factor = Math.Floor(100 * gliEntries.Width / (double)_columns.Sum(w => w.Width)) / 100;
            for (var i = 0; i < _columns.Length; i++)
                _columns[i].Width = (int)(factor * _columns[i].Width);

            for (var i = 0; i < gliEntries.Columns.Count - 1; i++)
                gliEntries.Columns[i].Width = _columns[i].Width;

            gliEntries.Columns[gliEntries.Columns.Count - 1].Width = Width - _columns.Sum(w => w.Width) + _columns[_columns.Length - 1].Width - 24;
        }

        private void LisEntriesItemActivate(object sender, EventArgs e)
        {
            //gliEntries.SelectedItems[0].BeginEdit();
        }

        private void LisEntriesSelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lisEntries.SelectedItems[0].Text);
        }

        private void GliEntriesColumnClickedEvent(object source, ClickEventArgs e)
        {
            SetBackColor();
        }

        #endregion
    }
}
