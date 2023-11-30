namespace Sweeter
{
	public class Customer: AuditableEntity
	{
		#region Public Properties

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public Address? Address { get; set; }

		#endregion

		public Customer(string firstname, string lastname)
		{
			FirstName = firstname;
			LastName = lastname;
		}

		#region Overrides

		public override string ToString() => $"{FirstName} {LastName}";

		#endregion
	}
}
