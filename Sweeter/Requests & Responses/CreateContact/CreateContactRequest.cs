namespace Sweeter
{
	public class CreateContactRequest
	{
		public Contact Contact { get; }

		public CreateContactRequest(Contact contact)
		{
			this.Contact = contact;
		}
	}
}
