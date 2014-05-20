﻿using GlacialComponents.Controls;

namespace TrainingLog.Controls
{
    public interface IFilter
    {
        void Initialize(GLItemCollection list, Common.MarkItem markItem, Common.ApplyItemVisibility applyItemVisibility, int controlColumnIndex, object defaultValue = null);

        bool IsItemVisible(GLItem item);

        bool IsEntryVisible(Entry entry);

        void ApplyFilter();
    }
}
