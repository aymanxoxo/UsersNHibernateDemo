using System;
using System.Collections.Generic;
using System.Linq;
using BusinessInterfaces;
using DataAccessLayer;
using DataModels;

namespace BusinessLayer
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Role Get(Guid id)
        {
            return _unitOfWork.RoleRepository.Find(id);
        }

        public List<Role> Get()
        {
            return _unitOfWork.RoleRepository.Get().ToList();
        }

        public void Save(Role role)
        {
            if (role.Id == Guid.Empty)
                _unitOfWork.RoleRepository.Add(role);
            else
                _unitOfWork.RoleRepository.Update(role);
        }

        public void Dispose()
        {
            _unitOfWork.Commit();
            _unitOfWork.Dispose();
        }
    }
}
