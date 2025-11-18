using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class GridBatchListModel
    {
        public string ColumnName { get; set; }
        public int? Order { get; set; }
        public bool IsExclude { get; set; }
    }
}
