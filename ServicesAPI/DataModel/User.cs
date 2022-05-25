using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAPI.DataModel
{
    public class User 
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }

        public User(int id, string email, string first_name, string last_name, string avatar)
        {
            this.id = id;
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
            this.avatar = avatar;
        }

        //public override bool Equals(object other)
        //{
        //    if (other == null) return false;
        //    if (ReferenceEquals(this, other)) return true;
        //    if (this.GetType() != other.GetType()) return false;
        //    return this.Equals(other as User);
        //}

        //bool IEquatable<User>.Equals(User other)
        //{
        //    if (other == null) return false;
        //    return (this.id == other.id &&
        //           this.email == other.email &&
        //           this.first_name == other.first_name &&
        //           this.last_name == other.last_name &&
        //           this.avatar == other.avatar);
        //}
    }
}
