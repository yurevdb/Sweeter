using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sweeter
{
	public abstract class AuditableEntity: Entity
	{
		[Column("created_on")]
		public DateTimeOffset CreatedOn { get; }

		[Column("created_by")]
		[MaxLength(64)]
		public string CreatedBy { get; }

		[Column("updated_on")]
		public DateTimeOffset? UpdatedOn { get; private set; }

		[Column("updated_by")]
		[MaxLength(64)]
		public string? UpdatedBy { get; private set; }

		protected AuditableEntity()
		{
			CreatedOn = DateTimeOffset.UtcNow;
			CreatedBy = Environment.UserName;
		}

		protected void Updated()
		{
			UpdatedOn = DateTimeOffset.UtcNow;
			UpdatedBy = Environment.UserName;
		}
	}
}
