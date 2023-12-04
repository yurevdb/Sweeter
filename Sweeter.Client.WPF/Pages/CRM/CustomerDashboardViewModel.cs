using MediatR;
using Sweeter.Client.Persistence;
using System.Windows.Input;

namespace Sweeter.Client.WPF;

public class CustomerDashboardViewModel : ViewModel
{
	#region Private Members

	private readonly UiService uiService;
	private readonly IMediator mediator;

	private IEnumerable<Contact> contacts = new List<Contact>();

	#endregion

	#region Public Properties

	public IEnumerable<Contact> Contacts => contacts.ToList();

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

		Task.Run(GetAllContacts);
	}

	#endregion

	#region Private Helpers

	private async void CreateContact()
	{
		try
		{
			uiService.ShowWizard(new CreateContactWizard(mediator));

			await Task.Delay(100);

			GetAllContacts();
		}
		catch(Exception ex)
		{
			var x = ex;
		}
	}

	private async void GetAllContacts()
	{
		try
		{
			var contacts = await mediator.Send(new GetAllContactsQuery());

			this.contacts = contacts;

			NotifyPropertyChanged(nameof(Contacts));
		}
		catch (Exception ex)
		{
			var x = ex;
		}
	}

	#endregion
}
