using MediatR;

namespace Sweeter.Server.Persistence;

public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
{
	private readonly ContactRepository repository;

	public GetAllContactsHandler(ContactRepository repository)
	{
		this.repository = repository;
	}

	public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
	{
		return await repository.GetAll();
	}
}
