using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
            string jsonString = JsonSerializer.Serialize(userDetails);

            // Print the JSON string to the console.
            Console.WriteLine(jsonString);
            return Ok("Received User Details Successfully!");
        }
    }
}
