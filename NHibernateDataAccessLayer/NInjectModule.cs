using DataAccessLayer;
using DataModels;
using Ninject.Modules;

namespace NHibernateDataAccessLayer
{
    public class NInjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<NHibernateUnitOfWork>();
            Bind<IRepository<User>>().To<NHibernateRepository<User>>();
            Bind<IRepository<Role>>().To<NHibernateRepository<Role>>();
        }
    }
}
