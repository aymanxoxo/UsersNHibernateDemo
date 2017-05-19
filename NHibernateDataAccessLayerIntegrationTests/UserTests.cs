using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernateDataAccessLayer;

namespace NHibernateDataAccessLayerIntegrationTests
{
    [TestClass]
    public class UserTests
    {
       
        [TestMethod]
        public void Insert()
        {
            using (IUnitOfWork unitOfWork = new NHibernateUnitOfWork())
            {
                var role = new Role {Name = "Admin"};
                unitOfWork.RoleRepository.Add(role);
                //unitOfWork.Commit();

                var user = new User
                {
                    UserName = "aymanxoxo1",
                    Email = "ayman1@hotmail.com",
                    FirstName = "ayman1",
                    LastName = "mohammed1",
                    Roles = new List<Role> {role}
                };

                unitOfWork.UserRepository.Add(user);
                unitOfWork.Commit();
                Assert.AreNotEqual(user.Id, Guid.Empty);
            }
        }



        [TestMethod]
        public void Select()
        {
            using (IUnitOfWork unitOfWork = new NHibernateUnitOfWork())
            {
                var users = unitOfWork.UserRepository.Get();
                unitOfWork.Commit();
            }
        }
        
    }
}
