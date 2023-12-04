using MediatR;
using Sweeter.Client.Persistence;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sweeter.Client.WPF;

public class StatusBarViewModel : INotifyPropertyChanged
{
	#region Private Members

	private readonly IMediator mediator;

	#endregion

	#region Implementations

	public event PropertyChangedEventHandler? PropertyChanged;

	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	#endregion

	#region Public Properties

	public ServerDiagnostics Diagnostics { get; private set; } = new ServerDiagnostics(false, 0);

	#endregion

	#region Constructor

	public StatusBarViewModel(IMediator mediator)
	{
		this.mediator = mediator;

		Task.Run(GetServerStatus);
	}

	#endregion

	#region Private Helpers

	private async Task GetServerStatus()
	{
		while (true)
		{
			try
			{
				Diagnostics = mediator.Send(new GetServerStatusQuery()).Result;
			}
			catch 
			{
				Diagnostics = new ServerDiagnostics(false, 0);
			}
			finally
			{
				NotifyPropertyChanged(nameof(Diagnostics));

				await Task.Delay(10 * 1000);
			}
		}
	}

	#endregion
}
