using Ninject.Modules;

namespace Sweeter.Client.WPF
{
	public class ServiceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<UiService>().To<WpfUiService>().InTransientScope();
		}
	}
}
