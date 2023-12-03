using MediatR;

namespace Sweeter.Server.Persistence;

public class InsertContactHandler : IRequestHandler<InsertContactCommand>
{
	private readonly ContactRepository repository;

	public InsertContactHandler(ContactRepository repository)
	{
		this.repository = repository;
	}

	public async Task Handle(InsertContactCommand request, CancellationToken cancellationToken)
	{
		await repository.Insert(request.Contact);
	}
}
