using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    [Authorize]
    public class TestController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public TestController ( UserManager<ApplicationUser> manager )
            {
            _userManager = manager;
            }
        [HttpGet]
        public async Task<IActionResult> Get ()
            {
            var user = await _userManager.GetUserAsync(User);
            return Ok(user.Email);
            }
    }
}