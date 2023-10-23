using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AuthServer.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuthServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private string UserId => 
            User.Claims.Single(c => c.Type == ClaimTypes.Name).Value;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (UserId == null)
                return BadRequest();
            return Ok(UserId.ToString());
        }
    }
}
