using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        [HttpGet]
        public IActionResult Jwt()
        {
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
