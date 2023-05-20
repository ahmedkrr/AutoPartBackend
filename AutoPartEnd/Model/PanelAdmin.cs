using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Model
{
    public class PanelAdmin
    {
    }
    public class GetPanelInfoResponse
    {
        public int Users { get; set; }
        public int Admin { get; set; }

        public int Companies { get; set; }
        public int Items { get; set; }
        public int Car { get; set; }
        public int Type { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
    }


}
