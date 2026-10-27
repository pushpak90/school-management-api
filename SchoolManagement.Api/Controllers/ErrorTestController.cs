using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => throw new InvalidOperationException("Test error for logging");
    }
}
