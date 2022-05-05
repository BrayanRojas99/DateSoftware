using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateSoftware.Models
{
    public class Doctor
    {
        #region Attributes
        public RestRequest request { get; set; }

        const string mimeType = "application/json";
        const string contentType = "Content-Type";
        #endregion
        public Doctor()
        {
            request = new RestRequest();
            Dates = new HashSet<Date>();
        }

        public int IdDoctor { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public bool? Status { get; set; }
        public int IdSpecialityDoctor { get; set; }

        public virtual SpecialityDoctor IdSpecialityDoctorNavigation { get; set; }
        public virtual ICollection<Date> Dates { get; set; }



    }
}
