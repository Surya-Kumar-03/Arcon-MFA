using Microsoft.AspNetCore.Mvc;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        [HttpPost]
        public IActionResult respondToClient([FromBody] UserDetails userDetails)
        {
            System.Console.WriteLine($"{userDetails.os}");
            System.Console.WriteLine($"{userDetails.browser}");
            System.Console.WriteLine($"{userDetails.version}");
            return Ok("Received User Details Successfully!");
        }
    }
}
