using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesAPI.Request;
using ServicesAPI.Responce;
using System.Net;
using System.Net.Http;
using CB_automation_test.TestHelper;
using ServicesAPI.DataModel;



namespace CB_automation_test.API.API_Test
{
    public class Tests : BaseTest
    {
        public HttpStatusCode statusCode;

        

        [Category("Test_GetData")]
        [Test]
        public async Task T01_FetchEntireUsersList()
        {
            int total_Users = Convert.ToInt32(ConfigurationHelper.TestConfigurationData["total_Users"]);
            string User_Firts_Name = ConfigurationHelper.TestConfigurationData["User:FirstName"];
            string User_Last_Name = ConfigurationHelper.TestConfigurationData["User:LastName"];
            

            var response = await api.Get_ListUsers(1);
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.IsTrue(responceobj.Check_totalPages(total_Users, response), "Error Message - Wrong # of total Users");

            bool Userfound = false;
            int total_Pages = responceobj.Get_total_Pages(response);
            for (int i = 1; i <= total_Pages; i++)
            {
                int nextPage = i + 1;
                if (responceobj.IfUserExist(User_Firts_Name, User_Last_Name, response))
                {
                    Userfound = true;
                    break;
                }

                if (nextPage <= total_Pages)
                {
                    response = await api.Get_ListUsers(nextPage);

                }
            }

            Assert.IsTrue(Userfound, "User: " + User_Firts_Name + " " + User_Last_Name + " not found in Users List.");


        }

        [Category("Test_GetData")]
        [Test]
        public async Task T02_FetchSingleUser()
        {
            User user = new User(Convert.ToInt32(ConfigurationHelper.TestConfigurationData["User10:id"]),
                                                   ConfigurationHelper.TestConfigurationData["User10:email"],
                                                   ConfigurationHelper.TestConfigurationData["User10:first_name"],
                                                   ConfigurationHelper.TestConfigurationData["User10:last_name"],
                                                   ConfigurationHelper.TestConfigurationData["User10:avatar"]);
            Support sup = new Support(ConfigurationHelper.TestConfigurationData["support:url"],
                                      ConfigurationHelper.TestConfigurationData["support:text"]);
            SingleUser testedUser = new SingleUser(user, sup);
            
            

            var response = await api.Get_SingleUser(10);
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.IsTrue(responceobj.IfUserDataCorrect(testedUser, response), "Error Message - User Data not correct.");

        }

        [Category("Test_PostData")]
        [Test]
        public async Task T03_CreateUser()
        {
            PostUser newUser = new PostUser()
            {
                name = "dima",
                job = "president"

            };

            var response = await api.Post_CreateUser(newUser);
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, statusCode);
            Assert.IsTrue(responceobj.Check_UserName_CreateUpdateUser(newUser.name, response), "Error Message - Created User Name incorrect.");
            Assert.IsTrue(responceobj.Check_Job_CreateUpdateUser(newUser.job, response), "Error Message - Created User Job title incorrect.");
            Assert.IsTrue(responceobj.Check_CreationDate_CreateUser(response), "Error Message - Created Date incorrect.");
        }

        [Category("Test_UpdateData")]
        [Test]
        public async Task T04_UpdateUser()
        {
            PostUser updateUser = new PostUser()
            {
                name = "dima",
                job = "vice president"

            };

            var response = await api.Put_UpdateUser(updateUser);
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.IsTrue(responceobj.Check_UserName_CreateUpdateUser(updateUser.name, response), "Error Message - Updated User Name incorrect.");
            Assert.IsTrue(responceobj.Check_Job_CreateUpdateUser(updateUser.job, response), "Error Message - Updated User Job title incorrect.");
            Assert.IsTrue(responceobj.Check_CreationDate_UpdateUser(response), "Error Message - Updated Date incorrect.");
        }



    }
}
