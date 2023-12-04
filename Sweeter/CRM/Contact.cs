using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sweeter
{
	[Table("contact")]
	public class Contact : AuditableEntity
	{
		#region Public Properties

		[DisplayName("First Name")]
		[Column("first_name")]
		[MaxLength(64)]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[Column("last_name")]
		[MaxLength(64)]
		public string LastName { get; set; }

		[DisplayName("Name")]
		public string FullName => $"{FirstName} {LastName}";

		[DisplayName("Email")]
		[Column("email")]
		[MaxLength(128)]
		public string? Email { get; set; }

		[DisplayName("Phone Number")]
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
