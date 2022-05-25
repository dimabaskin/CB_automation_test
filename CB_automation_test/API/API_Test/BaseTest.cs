using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServicesAPI.Request;
using ServicesAPI.Responce;

namespace CB_automation_test.API.API_Test
{
    public class BaseTest
    {
        public reqresAPI api;
        public Response responceobj;

        [SetUp]
        public void Setup()
        {
            api = new reqresAPI();
            responceobj = new Response();
        }
        

    }
}
