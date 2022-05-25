using Newtonsoft.Json;
using System.Net.Http;
using System;
using ServicesAPI.DataModel;

namespace ServicesAPI.Responce
{
    public class Response
    {
        
        public bool Check_totalPages(int total_users, HttpResponseMessage responseMessage)
        {
            UsersList usersList;
            var responseString = responseMessage.Content.ReadAsStringAsync();

            usersList = JsonConvert.DeserializeObject<UsersList>(responseString.Result);

            //jsonHelper.ConvertToJson(responseString.ToString())

            if (usersList.total == total_users)
            { return true; }
            return false;
        }

        public int Get_total_Pages (HttpResponseMessage responseMessage)
        {
            UsersList usersList;
            var responseString = responseMessage.Content.ReadAsStringAsync();

            usersList = JsonConvert.DeserializeObject<UsersList>(responseString.Result);

            return usersList.total_pages;
        }

        public bool IfUserExist (string firstName, string lastName , HttpResponseMessage responseMessage)
        {
            UsersList usersList;
            var responseString = responseMessage.Content.ReadAsStringAsync();

            usersList = JsonConvert.DeserializeObject<UsersList>(responseString.Result);

            foreach (User userdata in usersList.data)
            {
                if ( userdata.first_name.Equals(firstName.ToLower(), StringComparison.OrdinalIgnoreCase) &&
                     userdata.last_name.Equals(lastName.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;

        }

        public bool IfUserDataCorrect (SingleUser testuser, HttpResponseMessage responseMessage)
        {
            SingleUser receiveduser;
            var responseString = responseMessage.Content.ReadAsStringAsync();
            receiveduser = JsonConvert.DeserializeObject<SingleUser>(responseString.Result);

            return testuser.data.id.Equals(receiveduser.data.id) &&
                   testuser.data.email.Equals(receiveduser.data.email) &&
                   testuser.data.first_name.Equals(receiveduser.data.first_name) &&
                   testuser.data.last_name.Equals(receiveduser.data.last_name) &&
                   testuser.data.avatar.Equals(receiveduser.data.avatar);
                
        }

        public bool Check_UserName_CreateUpdateUser (string username, HttpResponseMessage responseMessage)
        {
            NewUser newUser = new NewUser();
            var responseString = responseMessage.Content.ReadAsStringAsync();
            newUser = JsonConvert.DeserializeObject<NewUser>(responseString.Result);

            return newUser.name.Equals(username);
        }

        public bool Check_Job_CreateUpdateUser(string job, HttpResponseMessage responseMessage)
        {
            NewUser newUser = new NewUser();
            var responseString = responseMessage.Content.ReadAsStringAsync();
            newUser = JsonConvert.DeserializeObject<NewUser>(responseString.Result);

            return newUser.job.Equals(job);
        }

        public bool Check_CreationDate_CreateUser(HttpResponseMessage responseMessage)
        {
            NewUser newUser = new NewUser();
            var responseString = responseMessage.Content.ReadAsStringAsync();
            newUser = JsonConvert.DeserializeObject<NewUser>(responseString.Result);

            DateTime today = DateTime.Now;

            return newUser.createdAt.Date.Equals(today.Date);
        }

        public bool Check_CreationDate_UpdateUser(HttpResponseMessage responseMessage)
        {
            NewUser newUser = new NewUser();
            var responseString = responseMessage.Content.ReadAsStringAsync();
            newUser = JsonConvert.DeserializeObject<NewUser>(responseString.Result);

            DateTime today = DateTime.Now;

            return newUser.updatedAt.Date.Equals(today.Date);
        }


    }
}
