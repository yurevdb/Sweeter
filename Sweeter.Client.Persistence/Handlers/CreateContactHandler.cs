using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Sweeter.Client.Persistence
{
	public class CreateContactHandler : IRequestHandler<CreateContactCommand>
	{
		private readonly IConfiguration configuration;

		public CreateContactHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			var _restClient = new RestClient(configuration.GetSection("Server:URL").Value);
			var req = new RestRequest("api/contact", Method.Post);

			req.AddJsonBody(new CreateContactRequest(request.Contact));

			var result = await _restClient.PostAsync(req, cancellationToken);

			if (!result.IsSuccessful)
				throw new Exception(result.ErrorMessage);
		}
	}
}
