using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sweeter.Client.WPF
{
	public class StatusBarViewModel : INotifyPropertyChanged
	{
		private readonly RestClient _restClient;

		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public bool IsServerUp { get; private set; }

		public StatusBarViewModel()
		{
			_restClient = new RestClient("http://localhost:6654");

			GetServerStatus();
		}

		private async void GetServerStatus()
		{
			var request = new RestRequest("api/status");

			var result = await _restClient.GetAsync(request);

			if (!result.IsSuccessful)
				throw new Exception(result.ErrorMessage);

			IsServerUp = JsonConvert.DeserializeObject<bool>(result.Content);

			NotifyPropertyChanged(nameof(IsServerUp));
		}
	}
}
