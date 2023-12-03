using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sweeter.Server.Persistence;

namespace Sweeter.Server.Controllers
{	
	[ApiController]
	[Route("api/[controller]")]
	public class ContactController : ControllerBase
	{
		private readonly IMediator mediator;

		public ContactController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult> CreateContact(CreateContactRequest request)
		{
			await mediator.Send(new InsertContactCommand(request.Contact));

			return Ok();
		}

		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
		{
			var data = await mediator.Send(new GetAllContactsQuery());

			return Ok(data);
		}
	}
}
