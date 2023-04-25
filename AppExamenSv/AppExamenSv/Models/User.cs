using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppExamenSv.Models
{
   public  class User
    {
        public RestRequest Request { get; set; }
        const string minetype = "application/json";
        const string contentType = "Content-Type";

       
        public User()
        {
            
        }
        public int UserId { get; set; }
        public string UserName { get; set; }  
        public string FirstName { get; set; }  
        public string LastName { get; set; }  
        public string  PhoneNumber { get; set; }
        public string UserPassword { get; set; }  
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; }  
        public string  JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; }  
        public virtual UserRole UserRole { get; set; } 
        public virtual UserStatus UserStatus { get; set; }  

       public async Task<bool>ValidateLogin()
        {
            try
            {
                string RouteSufix = string.Format("Users/ValidateUserLogin?pUserName={0}&pPassword={1}", this.UserName, this.UserPassword);

                string URL=Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL,Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName,Services.APIConnection.ApiKeyValue);
                Request.AddHeader(contentType, minetype);

                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else {
                return false;
                }

            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                throw;
            }

        }
        



    }
}
