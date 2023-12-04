using MediatR;

namespace Sweeter.Server.Persistence;

public record GetAllContactsQuery: IRequest<IEnumerable<Contact>>;
