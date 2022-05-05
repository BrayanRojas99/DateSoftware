using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace DateSoftware.Models
{
    public class User
    {
        #region Attributes
        public RestRequest request { get; set; }

        const string mimeType = "application/json";
        const string contentType = "Content-Type";
        #endregion
        public User()
        {
            Dates = new HashSet<Date>();
            GeneralInformations = new HashSet<GeneralInformation>();
        }

        public int UserId { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RecuperationCode { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRol UserRole { get; set; }
        public virtual ICollection<Date> Dates { get; set; }
        public virtual ICollection<GeneralInformation> GeneralInformations { get; set; }
        
        #region ValidateUserLogin
        public async Task<bool> ValidateUserLogin() 
        {
            bool R = false;
            try
            {
                //fisrt create the route
                string RouteSuFix = string.Format("/users/ValidateUserLogin?pEmail={0}&pPassword={1}",this.Email,this.Password);

                //second create the final route
                string FinalRoute = CnnToAPI.ProductionRoute + RouteSuFix;

                //create the client to consume the route
                RestClient client = new RestClient(FinalRoute);

                //create the structure of the request
                this.request = new RestRequest(FinalRoute,Method.Get);

                //add the header to you can have access with the API
                this.request.AddHeader(CnnToAPI.ApikeyName,CnnToAPI.ApiKeyValue);
                this.request.AddHeader(contentType, mimeType);

                //now it executes the instruction and catch
                RestResponse response = await client.ExecuteAsync(request);


                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    R = true;
                    CnnToAPI.GlobalUser = JsonConvert.DeserializeObject<User>(response.Content);
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

        #region AddUser
        public async Task<bool> AddUser()
        {
            bool R = false;
            try
            {
                //create the sufix
                string RouteSuFix = String.Format("/Users");

                string FinalRoute = CnnToAPI.ProductionRoute + RouteSuFix;

                //create the client
                RestClient client = new RestClient(FinalRoute);

                //configuration of the request
                request = new RestRequest(FinalRoute,Method.Post);
                request.AddHeader(CnnToAPI.ApikeyName,CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType,mimeType);

                //I have to serialize the class
                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass,mimeType);

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

        public async Task<bool> UpdateUser()
        {
            bool R = false;
            try
            {
                //create route
                string SufixRoute = string.Format("/Users/{0}",this.UserId);
                string FinalRoute = CnnToAPI.ProductionRoute + SufixRoute;

                //create the client
                RestClient client = new RestClient(FinalRoute);

                //configurate the request
                this.request = new RestRequest(FinalRoute,Method.Put);
                request.AddHeader(CnnToAPI.ApikeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentType,mimeType);

                //have to serialized the class
                string SerielizedClass = JsonConvert.SerializeObject(this);

                request.AddBody(mimeType,SerielizedClass);

                //answer
                RestResponse response = await client.ExecuteAsync(request);// DEPUREMOS voy

                //validate the information
                HttpStatusCode Status = response.StatusCode;

                if (Status == HttpStatusCode.OK)
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

    }
}
