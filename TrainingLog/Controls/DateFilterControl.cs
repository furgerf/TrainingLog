﻿using System;
using System.Windows.Forms;
using GlacialComponents.Controls;

namespace TrainingLog.Controls
{
    public partial class DateFilterControl : UserControl, IFilter
    {
        #region Public Fields

        public bool IsMinDate
        {
            get { return _isMinDate; }
            set
            {
                _isMinDate = value;
                label1.Text = IsMinDate ? "From:" : "To:";
            }
        }

        public bool IsMaxDate
        {
            get { return !_isMinDate; }
            set
            {
                _isMinDate = !value;
                label1.Text = IsMinDate ? "From:" : "To:";
            }
        }

        public int DateColumnIndex { get; set; }

        #endregion

        #region Private Fields

        private Action _onFilterChanged;
        
        private bool _isMinDate;

        private bool _initialized;

        #endregion

        #region Constructor

        public DateFilterControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Main Methods

        public void Initialize(GLItemCollection list, Common.MarkItem markItem, Common.ApplyItemVisibility applyItemVisibility, int dateColumnIndex, object date = null)
        {
            if (date != null)
                cdpDate.Value = (DateTime)date;

            _onFilterChanged = () =>
            {
                if (!_initialized)
                    return;

                foreach (GLItem o in list)
                    markItem(o, IsItemVisible(o));
                
                applyItemVisibility();
            };

            DateColumnIndex = dateColumnIndex;
            _initialized = true;
        }

        public bool IsItemVisible(GLItem item)
        {
            DateTime? date = null;

            if (item.SubItems[DateColumnIndex].Control is DateTimePicker)
                date = (item.SubItems[DateColumnIndex].Control as DateTimePicker).Value;

            if (item.SubItems[DateColumnIndex].Control is ColorDatePicker)
                date = (item.SubItems[DateColumnIndex].Control as ColorDatePicker).Value;

            if (date == null)
                throw new Exception("Don\'t know where the date control is!");

            return cdpDate.Value.CompareTo(date) == 1 || (cdpDate.Value.CompareTo(date) < 0 && !IsMinDate);
        }

        public void ApplyFilter()
        {
            if (_onFilterChanged != null)
                _onFilterChanged();
        }

        #endregion

        #region Event Handling

        private void CdpDateValueChanged(object sender, EventArgs e)
        {
            if (_onFilterChanged != null)
                _onFilterChanged();
        }

        #endregion
    }
}
