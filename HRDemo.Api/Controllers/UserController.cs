namespace HRDemo.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet("getuserdata")]
        public async Task<IActionResult> GetUserData([FromQuery] string url)
        {
            var query = new GetDataQuery { Url = url };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
