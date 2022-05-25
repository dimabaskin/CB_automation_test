using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAPI.DataModel
{
    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }

        public Support(string url, string text)
        {
            this.url = url;
            this.text = text;
        }
    }
}
