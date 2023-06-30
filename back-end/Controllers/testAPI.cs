using Microsoft.AspNetCore.Mvc;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        [HttpPost]
        public IActionResult RespondToClient([FromBody] UserDetails userDetails)
        {
            Console.WriteLine($"Received OS: {userDetails.os}");
            Console.WriteLine($"Received Browser: {userDetails.browser}");
            Console.WriteLine($"Received Version: {userDetails.version}");

            if (userDetails.latitude != null && userDetails.longitude != null)
            {
                Console.WriteLine($"Received Latitude: {userDetails.latitude}");
                Console.WriteLine($"Received Longitude: {userDetails.longitude}");
            }

            return Ok("Received User Details Successfully!");
        }
    }
}
