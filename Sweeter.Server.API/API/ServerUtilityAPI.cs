using MediatR;

namespace Sweeter.Server.API;

public static class ServerUtilityAPI
{
	public static void AddServerUtilityAPI(this WebApplication application)
	{
		application.MapGet("/api/status", GetServerStatus);
	}

	private static async Task<IResult> GetServerStatus()
	{
		return await Task.FromResult(Results.Ok());
	}
}
