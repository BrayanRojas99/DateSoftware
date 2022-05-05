using System;
using System.Collections.Generic;
using System.Text;

namespace DateSoftware.Models
{
    public class ExtraValue
    {
        public ExtraValue()
        {
            DetailExtraValues = new HashSet<DetailExtraValue>();
        }

        public int IdExtraValue { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DetailExtraValue> DetailExtraValues { get; set; }
    }
}
