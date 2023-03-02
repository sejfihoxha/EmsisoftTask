using EmsisoftTask.Services.Services.Hashes;
using Microsoft.AspNetCore.Mvc;

namespace EmsisoftTaskAPI.Controllers
{
    [Route("api/hashes")]
    [ApiController]
    public class HashesController : ControllerBase
    {
        private readonly IHashService _hashService;

        public HashesController(IHashService hashService)
        {
            _hashService = hashService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hashes = _hashService.GetByDay(10);

            return Ok(hashes);
        }

        [HttpPost]
        public IActionResult Post()
        {
            _hashService.GenerateRandomSHA1Hashes(100);

            return Ok();
        }
    }
}
