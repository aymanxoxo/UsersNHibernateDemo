using System;
using DataModels;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IRepository<User> UserRepository { get; }
        IRepository<Role> RoleRepository { get; } 
    }
}
