using System;
using System.Collections.Generic;
using System.Text;

namespace DateSoftware.Models
{
    public class Ailment
    {
        public Ailment()
        {
            DetailAilments = new HashSet<DetailAilment>();
        }

        public int IdAilment { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DetailAilment> DetailAilments { get; set; }
    }
}
