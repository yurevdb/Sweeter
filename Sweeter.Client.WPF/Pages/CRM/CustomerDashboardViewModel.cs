using MediatR;
using System.Windows.Input;

namespace Sweeter.Client.WPF
{
	public class CustomerDashboardViewModel : ViewModel
    {
		#region Private Members

		private readonly UiService uiService;
		private readonly IMediator mediator;

		#endregion

		#region Public Commands

		public ICommand CreateContactCommand { get; }

		#endregion

		#region Constructor

		public CustomerDashboardViewModel(IMediator mediator,UiService uiService)
		{
			CreateContactCommand = new RelayCommand(CreateContact);
			this.uiService = uiService;
			this.mediator = mediator;
		}

		#endregion

		#region Private Helpers

		private void CreateContact()
		{
			uiService.ShowWizard(new CreateContactWizard(mediator));
		}

		#endregion
	}
}
