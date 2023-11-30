namespace Sweeter
{
	public abstract class AuditableEntity: Entity
	{
		public DateTime CreatedOn { get; }

		public string CreatedBy { get; }

		public DateTime? UpdatedOn { get; private set; }

		public string? UpdatedBy { get; private set; }

		protected AuditableEntity()
		{
			CreatedOn = DateTime.Now;
			CreatedBy = Environment.UserName;
		}

		protected void Updated()
		{
			UpdatedOn = DateTime.Now;
			UpdatedBy = Environment.UserName;
		}
	}
}
