namespace Sweeter
{
	public class ServerDiagnostics(bool isup, long ping)
	{
		#region Public Properties

		public long Ping { get; } = ping;

		public bool IsUp { get; } = isup;

		#endregion
	}
}
