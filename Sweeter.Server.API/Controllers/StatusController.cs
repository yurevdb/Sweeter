using Microsoft.AspNetCore.Mvc;

namespace Sweeter.Server
{
	[ApiController]
	[Route("api/[controller]")]
	public class StatusController : ControllerBase
	{
		[HttpGet]
		public ActionResult<bool> Get()
		{
			return true;
		}
	}
}
