using System;
using System.Collections.Generic;
using DataModels;

namespace BusinessInterfaces
{
    public interface IRoleService : IDisposable
    {
        // get role by id
        Role Get(Guid id);

        // get all roles
        List<Role> Get();

        // insert new role
        void Save(Role role);
    }
}
