using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using testAPI.Models;
using testAPI.Helpers; // Import the DataContext namespace

namespace testAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        private readonly DataContext _dataContext; // Add a private field for DataContext

        public TestAPIController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public IActionResult RespondToClient([FromBody] UserDetails userDetails)
        {
            // If the received data is valid
            if (ModelState.IsValid)
            {
                // Save userDetails to the database 
                // _dataContext.Users.Add(userDetails);
                // _dataContext.SaveChanges();

                // Prints to Console
                var userIp = HttpContext.Connection.RemoteIpAddress;
                Console.WriteLine(userIp);

                string jsonString = JsonSerializer.Serialize(userDetails);
                Console.WriteLine(jsonString);

                return Ok("Received User Details Successfully!");
            }
            else
            {
                return BadRequest("Invalid data received.");
            }
        }
    }
}
