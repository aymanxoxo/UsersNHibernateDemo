using System;
using System.Collections.Generic;
using DataModels;

namespace BusinessInterfaces
{
    public interface IUserService : IDisposable
    {
        // get user by id
        User Get(Guid id);

        // get all users
        List<User> Get();

        // search users by user name
        List<User> Search(string userName);

        // save user either insert or update
        void Save(User user);

        // delete user
        void Delete(User user);
    }
}
