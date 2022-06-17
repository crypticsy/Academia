using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes
{
    public class PriceModel
    {
        public uint groupCount { get; set; }
        public uint duration { get; set; }
        public float childWeekendPrice { get; set; }
        public float adultWeekendPrice { get; set; }
        public float agedWeekendPrice { get; set; }
        public float childWeekdayPrice { get; set; }
        public float adultWeekdayPrice { get; set; }
        public float agedWeekdayPrice { get; set; }
    }
}
