using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using M_API.ViewModels.Auth;
using M_API.ViewModels;
using System.Diagnostics;
using M_Core.Services;
using M_Core.Auth;
using M_Core.Data;
using M_Data.models;

namespace M_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;

        readonly DataContext context;

        public AuthController(
            DataContext context,
            UserManager<ApplicationUser> userManager,
            /*IEmailSender emailSender,*/
            SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            _userManager = userManager;
            //_emailSender = emailSender;
            _signInManager = signInManager;
        }


        [HttpPost("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();

            return Ok("successfully logged out");
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginViewModel model)
        {

            var user = context.Users.SingleOrDefault(u => u.Email == model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, lockoutOnFailure: false, isPersistent: false);
                if(result.Succeeded == false)
                {
                    return NotFound("email or password incorrect");
                }
                return Ok(JwtPacket.CreateJwtPacket(user));

            }
            return NotFound("email or password incorrect");

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(JwtPacket.CreateJwtPacket(user));
            }
            else
            {
                var error = new ErrorViewModel() { ErrorCode = result.Errors.First().Code, ErrorDescription = result.Errors.First().Description };

                return BadRequest(error);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            //middleware uses something with (Shift chapter 47) and look into nameidentifier, this
            //also this only works because the first one is the tokenidentifer. This should be changed accordingly

            return Ok(GetCurrentUserAsync());
        }

        [Authorize]
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);



        //Deleting was not supported by core 1.0
        //https://stackoverflow.com/questions/22379297/how-to-delete-user-with-usermanager-in-mvc5#24594440
        //Although could not find other example of this use.
        [Authorize]
        // DELETE: api/auth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);

            return Ok("Deleted user");

        }

        [Authorize]
        [HttpPost]
        // WORK IN PROGRESSSSSSSSSSSSSSSSSSSSS!!!
        public async Task<IActionResult> ResetPassword([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, "halohalo123,.-");

            if(result.Succeeded == false)
            {
                //remember to refactor into a new function
                return StatusCode(500, new ErrorViewModel() { ErrorCode = result.Errors.First().Code, ErrorDescription = result.Errors.First().Description });
            }

            return Ok("reset user");
        }


        //inspired by https://www.codeproject.com/articles/790720/asp-net-identity-customizing-users-and-roles
        // WORK IN PROGRESSSSSSSSSSSSSSSSSSSSS!!!
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //username = email in our case
            ApplicationUser user = await _userManager.FindByEmailAsync(model.username);

            if (user == null)
            {
                return NotFound();
            }

            user.Email = model.newEmail;
            user.PhoneNumber = model.phoneNumber;

            var updatedUser = await _userManager.UpdateAsync(user);
            if(updatedUser.Succeeded == false)
            {
                return StatusCode(500, new ErrorViewModel() { ErrorCode = updatedUser.Errors.First().Code, ErrorDescription = updatedUser.Errors.First().Description });
            }
            return Ok("updated user succeeded");



        }






    }
}