using System;
using System.Collections.Generic;
using System.Text;

namespace DateSoftware.Models
{
    public class DetailAilment
    {
        public int IdDetailAilment { get; set; }
        public int IdInformation { get; set; }
        public int IdAilment { get; set; }

        public virtual Ailment IdAilmentNavigation { get; set; }
        public virtual GeneralInformation IdInformationNavigation { get; set; }
    }
}
