using Microsoft.AspNetCore.Mvc;
using servicetwo.Data;

namespace servicetwo.Controllers
{
    [Route("owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IAutoDatabase db;

        public OwnersController(IAutoDatabase db)
        {
            this.db = db;
        }

        [HttpGet("/list")]
        public IActionResult Get()
        {
            return Ok(db.ListOwners());
        }
    }
}
