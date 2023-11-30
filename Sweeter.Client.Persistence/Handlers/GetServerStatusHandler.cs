using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace Sweeter.Client.Persistence
{
	public class GetServerStatusHandler : IRequestHandler<GetServerStatusQuery, ServerDiagnostics>
	{
		private readonly IConfiguration configuration;

		public GetServerStatusHandler(IConfiguration config)
		{
			configuration = config;
		}

		public async Task<ServerDiagnostics> Handle(GetServerStatusQuery request, CancellationToken cancellationToken)
		{
			var _restClient = new RestClient(configuration.GetSection("Server:URL").Value);
			var req = new RestRequest("api/status");

			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var result = await _restClient.GetAsync(req, cancellationToken: cancellationToken);
			stopwatch.Stop();

			if (!result.IsSuccessful)
				throw new Exception(result.ErrorMessage);

			if(result.Content  == null)
				throw new Exception("No content received");

			var isup = JsonConvert.DeserializeObject<bool>(result.Content);

			return new ServerDiagnostics(isup, stopwatch.ElapsedMilliseconds);
		}
	}
}
