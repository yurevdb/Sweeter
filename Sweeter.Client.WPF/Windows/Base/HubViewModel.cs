using Microsoft.Extensions.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sweeter.Client.WPF
{
	public class HubViewModel : ViewModel
	{
		#region Private Members

		private readonly UiService uiService;
		private readonly IConfiguration configuration;

		#endregion

		#region Public Properties

		public Page Page { get; private set; } = new Home();

		public IEnumerable<Domain> Domains => new List<Domain>()
		{
			new Domain(Application.Current.Resources["FaHome"], new RelayCommand(() => ShowPage(new Home()))),
			new Domain(Application.Current.Resources["FaUsers"], new RelayCommand(() => ShowPage(new CustomerDashboard()))),
			new Domain(Application.Current.Resources["FaFileContract"], new RelayCommand(() => ShowPage(new QuoteDashboard()))),
			new Domain(Application.Current.Resources["FaFileInvoice"], new RelayCommand(() => ShowPage(new InvoicingDashboard()))),
			new Domain(Application.Current.Resources["FaIndustry"], new RelayCommand(() => ShowPage(new ProductionDashboard())))
		};

		#endregion

		#region Constructor

		public HubViewModel(UiService uiService, IConfiguration configuration)
		{
			this.uiService = uiService;
			this.configuration = configuration;
		}

		#endregion

		#region Public Functions

		public void ChangeDomain(Domain domain)
		{
			domain?.Command.Execute(null);
		}

		#endregion

		#region Private Helpers

		private void ShowPage(Page page)
		{
			Page = page;
			NotifyPropertyChanged(nameof(Page));
		}

		#endregion
	}
}

public record Domain(object Resource, ICommand Command);
