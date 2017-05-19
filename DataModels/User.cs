using System;
using System.Collections.Generic;

namespace DataModels
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
