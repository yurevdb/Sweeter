using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sweeter
{
	[Table("contact")]
	public class Contact : AuditableEntity
	{
		#region Public Properties

		[Column("first_name")]
		[MaxLength(64)]
		public string FirstName { get; set; }

		[Column("last_name")]
		[MaxLength(64)]
		public string LastName { get; set; }

		[Column("email")]
		[MaxLength(128)]
		public string? Email { get; set; }

		[Column("phone_number")]
		[MaxLength(32)]
		public string? PhoneNumber { get; set; }

		//public Address? Address { get; set; }

		#endregion

		public Contact() { }

		public Contact(string firstname, string lastname)
		{
			FirstName = firstname;
			LastName = lastname;
		}

		#region Overrides

		public override string ToString() => $"{FirstName} {LastName}";

		#endregion
	}
}
