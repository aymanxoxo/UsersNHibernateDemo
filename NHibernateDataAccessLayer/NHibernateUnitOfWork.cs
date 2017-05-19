using System.Runtime.CompilerServices;
using DataAccessLayer;
using DataModels;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Proxy;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateDataAccessLayer
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {

        private readonly ISessionFactory _sessionFactory;
        private readonly ISession _session;
        private readonly ITransaction _transaction;

        public NHibernateUnitOfWork()
        {
            // Initializaing NHibernate
            var config = new Configuration();

            // Load NHibernate configuration from the configuration file
            config.Configure();


            new SchemaUpdate(config).Execute(false, true);


            // Create a session factory from the loaded configuration
            _sessionFactory = config.BuildSessionFactory();

            //config.AddAssembly(this.GetType().Assembly);


            // Create new session from the session factory
            _session = _sessionFactory.OpenSession();

            // Begin new transaction
            _transaction = _session.BeginTransaction();


            
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _session?.Dispose();
            _sessionFactory?.Dispose();
        }

        #region Repositories

        // User Repository
        private IRepository<User> _userRepository;
        public IRepository<User> UserRepository
            => _userRepository ?? (_userRepository = new NHibernateRepository<User>(_session));


        // Role Repository
        private IRepository<Role> _roleRepository;
        public IRepository<Role> RoleRepository
            => _roleRepository ?? (_roleRepository = new NHibernateRepository<Role>(_session));


        #endregion
    }
}
