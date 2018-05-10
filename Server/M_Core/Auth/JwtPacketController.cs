using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using M_Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace M_Core.Auth
{
    public class JwtPacketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public class JwtPacket
        {
            public string Token { get; set; }
            public string UserName { get; set; }

            public static JwtPacket CreateJwtPacket(ApplicationUser user)
            {

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret phrase"));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                };
                var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials, expires: DateTime.Now.AddMinutes(10));

                //gives us the encoded token as a string
                var encodedJwt = new JwtSecurityTokenHandler
                    ().WriteToken(jwt);
                return new JwtPacket() { Token = encodedJwt, UserName = user.Email };

            }
        }
    }
}