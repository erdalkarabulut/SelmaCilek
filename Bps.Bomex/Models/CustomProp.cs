using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.Bomex.Models
{
    public class CustomProp
    {
        public string PropName { get; set; }

        public string PropType { get; set; }

        public dynamic DefaultVal { get; set; }

        public dynamic Val { get; set; }
    }
}
