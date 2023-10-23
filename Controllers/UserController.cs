using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AuthServer.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using AuthServer.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get()
        {
            AppUser currentUser =  await _context.Users.FirstOrDefaultAsync(u=> u.UserName == UserId);
            if (currentUser == null)
                return BadRequest();
            return Ok(new
            {
                username = currentUser.UserName,
                firstname = currentUser.FirstName,
                lastname = currentUser.LastName,
                birthDate = currentUser.BirthDate,
                address = currentUser.Address
            });
        }
    }
}
