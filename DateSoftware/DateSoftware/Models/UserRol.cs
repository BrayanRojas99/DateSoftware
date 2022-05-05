using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.Net;
using Newtonsoft.Json;

namespace DateSoftware.Models
{
    public class UserRol
    {
        public RestRequest request { get; set; }

        const string mimeType = "application/json";
        const string contentType = "Content-Type";
        public UserRol()
        {
            request = new RestRequest();
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

        #region LoadRoles
        public async Task<List<UserRol>> LoadRoles()
        {
            try
            {
                string RouteSuFix = string.Format("/UserRols");

                string FinalRoute = CnnToAPI.ProductionRoute + RouteSuFix;

                RestClient client = new RestClient(FinalRoute);

                this.request = new RestRequest(FinalRoute,Method.Get);

                this.request.AddHeader(CnnToAPI.ApikeyName,CnnToAPI.ApiKeyValue);
                this.request.AddHeader(contentType,mimeType);

                RestResponse response = await client.ExecuteAsync(request);

                var RolesList = JsonConvert.DeserializeObject<List<UserRol>>(response.Content);

                HttpStatusCode status = response.StatusCode;

                if (status == HttpStatusCode.OK)
                {
                    return RolesList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

        }
        #endregion
    }
}
