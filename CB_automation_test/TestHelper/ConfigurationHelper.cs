using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;



namespace CB_automation_test.TestHelper
{
    public static class ConfigurationHelper
    {
        public static readonly IConfigurationRoot TestConfigurationData = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(path: "CB_automation_test\\TestConfiguration\\TestData.json")
           .Build();
    }
}
