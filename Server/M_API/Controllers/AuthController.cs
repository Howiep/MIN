using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using M_Data;
using Microsoft.AspNetCore.Authorization;
using static M_Core.Auth.JwtPacketController;
using M_Core.Data;
using M_API.ViewModels.Auth;

namespace M_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        readonly DataContext context;

        public AuthController(
            DataContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginViewModel model)
        {

            var user = context.Users.SingleOrDefault(u => u.Email == model.Email);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, lockoutOnFailure: false, isPersistent: false);

            if (user == null)
            {
                return NotFound("email or password incorrect");
            }
            return Ok(JwtPacket.CreateJwtPacket(user));
        }

        [HttpPost("register")]
        public async Task<JwtPacket> RegisterAsync([FromBody] RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return JwtPacket.CreateJwtPacket(user);
            }
            else
            {
                return new JwtPacket() { UserName = result.Errors.First().Description };
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            //middleware uses something with (watch chapter 47) and look into nameidentifier, this
            //also this only works because the first one is the tokenidentifer. This should be changed accordingly

            return Ok(GetCurrentUserAsync());
        }

        [Authorize]
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}