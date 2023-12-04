using MediatR;
using Sweeter.Server.Persistence;

namespace Sweeter.Server.API;

public static class CrmAPI
{
	public static void AddCrmAPI(this WebApplication application)
	{
		application.MapPost("/api/contacts", InsertContact);
		application.MapGet("/api/contacts", GetAllContacts);
	}

	private static async Task<IResult> InsertContact(CreateContactRequest request, IMediator mediator)
	{
		try
		{ 
			await mediator.Send(new InsertContactCommand(request.Contact));
			return Results.Ok();
		}
		catch (Exception exception)
		{
			return Results.Problem(exception.Message);
		}
	}

	private static async Task<IResult> GetAllContacts(IMediator mediator)
	{
		try
		{ 
			return Results.Ok(await mediator.Send(new GetAllContactsQuery()));
		}
		catch (Exception exception)
		{
			return Results.Problem(exception.Message);
		}
	}
}
