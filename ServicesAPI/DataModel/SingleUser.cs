using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAPI.DataModel
{
    public class SingleUser 
    {
        public User data { get; set; }
        public Support support { get; set; }

        public SingleUser(User data, Support support)
        {
            this.data = data;
            this.support = support;
        }
        //public override bool Equals(object other)
        //{
        //    if (other == null) return false;
        //    if (ReferenceEquals(this, other)) return true;
        //    if (this.GetType() != other.GetType()) return false;
        //    return this.Equals(other as SingleUser);
        //}
        //bool IEquatable<SingleUser>.Equals(SingleUser other)
        //{
        //    if (other == null) return false;
            
        //    return this.data.Equals(other.data);
        //}

       
    }
}
