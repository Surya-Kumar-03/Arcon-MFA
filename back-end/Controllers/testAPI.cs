using Microsoft.AspNetCore.Mvc;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class testAPIController : ControllerBase
    {
        [HttpGet]
        public string SayHi()
        {
            return "Hello SK";
        }
    }
}