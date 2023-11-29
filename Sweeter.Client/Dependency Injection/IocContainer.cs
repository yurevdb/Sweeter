using Ninject;

namespace Sweeter.Client.WPF
{
	public class IocContainer
    {
        private readonly IKernel kernel;

        public HubViewModel HubViewModel => kernel.Get<HubViewModel>();

        public StatusBarViewModel StatusBarViewModel => kernel.Get<StatusBarViewModel>();

        public IocContainer()
        {
            kernel = new StandardKernel(new ViewModelModule(), new Persistence.PersistenceModule());
        }
    }
}
