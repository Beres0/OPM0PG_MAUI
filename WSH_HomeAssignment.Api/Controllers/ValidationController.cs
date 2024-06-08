using Microsoft.AspNetCore.Mvc;
using WSH_HomeAssignment.Api.Contracts;

namespace WSH_HomeAssignment.Api.Controllers
{
    [Route("api/validation")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        [HttpGet("values")]
        public ValidationDto Get()
        {
            return new ValidationDto();
        }
    }
}