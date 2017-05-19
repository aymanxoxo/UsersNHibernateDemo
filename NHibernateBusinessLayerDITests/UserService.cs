using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessInterfaces;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace NHibernateBusinessLayerDITests
{
    [TestClass]
    public class UserService
    {
        [TestMethod]
        public void TestInjectionWithGetMethod()
        {
            var kernel = new StandardKernel(new ServicesNInjectModule());
            var service = kernel.Get<IUserService>();
            var users = service.Get();
        }
    }
}
