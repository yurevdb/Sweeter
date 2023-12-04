using MediatR;

namespace Sweeter.Server.Persistence
{
	public record InsertContactCommand(Contact Contact): IRequest;
}
