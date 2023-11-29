using MediatR;

namespace Sweeter.Client.Persistence
{
    public record GetServerStatusQuery() : IRequest<ServerDiagnostics>;
}
