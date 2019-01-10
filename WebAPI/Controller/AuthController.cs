using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebAPI.Settings;

namespace WebAPI.Controller
{
    [Authorize]
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly AppSettings appSettings;
        public AuthController(IAuthService _authService, IOptions<AppSettings> _appSettings)
        {
            this.authService = _authService;
            appSettings = _appSettings.Value;
        }

       
        [HttpGet]
        [Route("UserRoleMenuFunction")]
        public IActionResult GetUserRoleMenuFunctions(int  roleId)
        {
           var userRole= authService.GetUserRoleMenuFunctionList(roleId);
            return Ok(userRole);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(LoginDetails userLogin)
        {
            var user = this.authService.Authenticate(userLogin);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            // remove password before returning
            user.UserCredential.FirstOrDefault().Password = null;
            return Ok(user);
        }
    }
}