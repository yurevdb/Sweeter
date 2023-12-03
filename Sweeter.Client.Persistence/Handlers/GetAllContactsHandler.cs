using MediatR;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Sweeter.Client.Persistence;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
{
	private readonly IConfiguration configuration;

	public GetAllContactsHandler(IConfiguration configuration)
	{
		this.configuration = configuration;
	}

	public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
	{
		var _restClient = new RestClient(configuration.GetSection("Server:URL").Value);
		var req = new RestRequest("api/contact/getall", Method.Get);

		var result = await _restClient.GetAsync<IEnumerable<Contact>>(req, cancellationToken);

		if (result == null)
			throw new Exception("Contacts could not be queried");

		return result;
	}
}
