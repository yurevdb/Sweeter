using MediatR;
using Sweeter.Client.Persistence;
using System.Windows.Controls;

namespace Sweeter.Client.WPF
{
	public class CreateContactWizard : Wizard
	{
		private readonly IMediator mediator;

		private readonly Contact contact = new Contact();
		
		public override Page[] Pages => [ 
			new RequiredContactInformationPage() { DataContext = contact}
		];

		protected async override void Finish()
		{
			await mediator.Send(new CreateContactCommand(contact));
		}

		public CreateContactWizard(IMediator mediator)
		{
			this.mediator = mediator;
		}
	}
}
