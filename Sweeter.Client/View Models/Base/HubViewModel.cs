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

		public IEnumerable<DomainButton> Domains => new List<DomainButton>()
		{
			new DomainButton(Application.Current.Resources["FaHome"], new RelayCommand(() => ShowPage(new Home()))),
			new DomainButton(Application.Current.Resources["FaUsers"], new RelayCommand(() => ShowPage(new CustomerDashboard()))),
			new DomainButton(Application.Current.Resources["FaFileContract"], new RelayCommand(() => ShowPage(new QuoteDashboard()))),
			new DomainButton(Application.Current.Resources["FaFileInvoice"], new RelayCommand(() => ShowPage(new InvoicingDashboard()))),
			new DomainButton(Application.Current.Resources["FaIndustry"], new RelayCommand(() => ShowPage(new ProductionDashboard())))
		};

		#endregion

		#region Constructor

		public HubViewModel(UiService uiService, IConfiguration configuration)
		{
			this.uiService = uiService;
			this.configuration = configuration;
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

public record DomainButton(object Resource, ICommand Command);
