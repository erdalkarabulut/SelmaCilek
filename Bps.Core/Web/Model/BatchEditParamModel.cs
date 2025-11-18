using System.Collections.Generic;

namespace Bps.Core.Web.Model
{
    public class BatchEditParamModel
    {
        public string BaseGridName { get; set; }
        public int FocusedCellColumnIndex { get; set; }
        public int FocusedCellRowIndex { get; set; }
        public int FocusedRowKey { get; set; }
        public int SelectedIndex { get; set; }
        public List<GridBatchEditFileds> EditFileds { get; set; }
    }
}