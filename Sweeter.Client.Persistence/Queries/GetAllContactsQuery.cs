using MediatR;

namespace Sweeter.Client.Persistence;

public record GetAllContactsQuery : IRequest<IEnumerable<Contact>>;
