using MediatR;

namespace Sweeter.Client.Persistence
{
	public class CreateContactCommand: IRequest
	{
		public Contact Contact { get; }

		public CreateContactCommand(Contact contact)
		{
			Contact = contact;
		}
	}
}
