using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAPI.DataModel
{
    public class NewUser
    {
        public int id { get; set; }
        public string name { get; set; }

        public string job { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        
    }
}
