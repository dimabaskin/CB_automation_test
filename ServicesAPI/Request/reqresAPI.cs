using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServicesAPI.DataModel;


namespace ServicesAPI.Request
{
    public class reqresAPI
    {
        private HttpClient restClient = new HttpClient();
        private string URI
        {
            get { return ConfigurationManager.AppSettings["ResetAPI"]; }
        }

        public async Task<HttpResponseMessage> Get_ListUsers(int Page_Number)
        {
            var Builder = new System.UriBuilder($"{URI}/api/users?page=" + Page_Number.ToString());

            var request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, Builder.Uri);

            var responce = await restClient.SendAsync(request);

            //var responseString = await responce.Content.ReadAsStringAsync();

            return responce;

        }

        public async Task<HttpResponseMessage> Get_SingleUser(int UserID)
        {
            var Builder = new System.UriBuilder($"{URI}/api/users/" + UserID.ToString());

            var request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, Builder.Uri);

            var responce = await restClient.SendAsync(request);

            //var responseString = await responce.Content.ReadAsStringAsync();

            return responce;

        }

        public async Task<HttpResponseMessage> Post_CreateUser(PostUser postUser)
        {
            
            var newPostJson = JsonConvert.SerializeObject(postUser);

            var content = new StringContent(newPostJson, Encoding.UTF8, "application/json");

            var Builder = new System.UriBuilder($"{URI}/api/users/create");

            var response = await restClient.PostAsync(Builder.Uri, content);

//            var responseString = await response.Content.ReadAsStringAsync();

            return response;

        }

        public async Task<HttpResponseMessage> Put_UpdateUser(PostUser postUser)
        {

            var newPostJson = JsonConvert.SerializeObject(postUser);

            var content = new StringContent(newPostJson, Encoding.UTF8, "application/json");

            var Builder = new System.UriBuilder($"{URI}/api/users/update");

            var response = await restClient.PutAsync(Builder.Uri, content);

  //          var responseString = await response.Content.ReadAsStringAsync();

            return response;

        }


    }
}
