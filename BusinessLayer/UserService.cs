using System;
using System.Collections.Generic;
using System.Linq;
using BusinessInterfaces;
using DataAccessLayer;
using DataModels;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Get(Guid id)
        {
            return _unitOfWork.UserRepository.Find(id);
        }

        public List<User> Get()
        {
            return _unitOfWork.UserRepository.Get().ToList();
        }

        public List<User> Search(string userName)
        {
            return _unitOfWork.UserRepository.Get(x => x.UserName == userName).ToList();
        }

        public void Save(User user)
        {
            if (user.Id == Guid.Empty)
                _unitOfWork.UserRepository.Add(user);
            else
                _unitOfWork.UserRepository.Update(user);

            SaveRoles(user.Roles);
        }

        private void SaveRoles(ICollection<Role> roles)
        {
            var roleService = new RoleService(_unitOfWork);
            foreach (var role in roles)
            {
                roleService.Save(role);
            }
        }

        public void Delete(User user)
        {
            _unitOfWork.UserRepository.Delete(user);
        }

        public void Dispose()
        {
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
        }

    }
}
