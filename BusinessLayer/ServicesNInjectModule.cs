using BusinessInterfaces;
using Ninject.Modules;

namespace BusinessLayer
{
    public class ServicesNInjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}
