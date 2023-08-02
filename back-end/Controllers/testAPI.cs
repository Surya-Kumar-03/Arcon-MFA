using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using testAPI.Models;
using testAPI.Helpers; // Import the DataContext namespace
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> RespondToClient([FromBody] UserDetails userDetails)
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

                double? latitude = userDetails.latitude;
                double? longitude = userDetails.longitude;

                if (latitude.HasValue && longitude.HasValue)
                {
                    var result = await FindNearestLocation(latitude.Value, longitude.Value);

                    if (result != null)
                    {
                        Console.WriteLine($"City: {result.city}, State: {result.state}, " +
                            $"Latitude: {result.latitude}, Longitude: {result.longitude}");
                    }
                }
                else
                {
                    return BadRequest("Invalid latitude or longitude.");
                }

                return Ok("Received User Details Successfully!");
            }
            else
            {
                return BadRequest("Invalid data received.");
            }
        }
        
        // Haversine Formula
        private async Task<LocationDetails?> FindNearestLocation(double latitude, double longitude)
        {
            var queryResult = await _dataContext.Locations
                .Where(location => location.latitude != null && location.longitude != null)
                .OrderBy(location => Math.Sqrt(Math.Pow(latitude - location.latitude.Value, 2) +
                                                Math.Pow(longitude - location.longitude.Value, 2)))
                .Select(location => new LocationDetails
                {
                    city = location.city,
                    state = location.state,
                    latitude = location.latitude,
                    longitude = location.longitude
                })
                .FirstOrDefaultAsync();

            return queryResult;
        }
    }
}
