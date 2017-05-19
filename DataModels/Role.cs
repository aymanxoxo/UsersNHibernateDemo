using System;
using System.Collections.Generic;

namespace DataModels
{
    public class Role
    {
        public Role()
        {
            //Users = new HashSet<User>();    
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual ICollection<User> Users { get; set; } 
    }
}
