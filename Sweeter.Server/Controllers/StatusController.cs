using Microsoft.AspNetCore.Mvc;

namespace Sweeter.Server
{
	[ApiController]
	[Route("api/[controller]")]
	public class StatusController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<bool>> Get()
		{
			await Task.Delay(0);
			return true;
		}
	}
}
