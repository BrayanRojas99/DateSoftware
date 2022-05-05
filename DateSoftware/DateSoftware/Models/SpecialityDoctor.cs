using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;

namespace DateSoftware.Models
{
    public class SpecialityDoctor
    {
        RestRequest request { get; set; }

        const string mimeType = "application/json";
        const string contentType = "Content-Type";

        public SpecialityDoctor()
        {
            Doctors = new HashSet<Doctor>();
            request = new RestRequest();
        }

        public int IdSpecialityDoctor { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        #region Add Speciality
        public async Task<bool> AddSpeciality()
        {
            bool R = false;
            try
            {
                //final route and sufix
                string RouteSuFix = string.Format("/SpecialityDoctors");
                string FinalRoute = CnnToAPI.ProductionRoute + RouteSuFix;

                //client
                RestClient client = new RestClient(FinalRoute);

                //request
                this.request = new RestRequest(FinalRoute,Method.Post);
                this.request.AddHeader(CnnToAPI.ApikeyName,CnnToAPI.ApiKeyValue);

                string SerializedClass = JsonConvert.SerializeObject(this);

                this.request.AddBody(SerializedClass,mimeType);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode Status = response.StatusCode;

                if (Status == HttpStatusCode.Created)
                {
                    R = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
            return R;
        }
        #endregion

    }
}
