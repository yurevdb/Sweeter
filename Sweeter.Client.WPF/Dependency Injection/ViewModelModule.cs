using Ninject.Modules;

namespace Sweeter.Client.WPF
{
	public class ViewModelModule : NinjectModule
	{
		public override void Load()
		{
			Bind<HubViewModel>().ToSelf().InTransientScope();
			Bind<StatusBarViewModel>().ToSelf().InTransientScope();
			Bind<CustomerDashboardViewModel>().ToSelf().InTransientScope();
		}
	}
}
