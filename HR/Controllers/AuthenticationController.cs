using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.Core;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Models;
using HR.Models.QueryModels;
using HR.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HR.Controllers
{
    [Route("/api/auth")]
    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authService;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public AuthenticationController(
            IOptionsSnapshot<AppSettings> options, 
            IAuthenticationService authService, 
            IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
            this.appSettings = options.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!(await this.authService.IsValidUser(model.UserName, model.Password)))
                return BadRequest(new { Message = "Username or password is invalid"});

            if((await this.authService.IsFirstLogin(model.UserName)))
                return BadRequest(new { Status = ErrorStatus.FirstLogin, UserName = model.UserName, Message = "Please change password at first login."});

            var user = await this.authService.GetByUserNameAsync(model.UserName, true);

            var authUser = mapper.Map<User, AuthenticateUserModel>(user);

             // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.SecretKey);
            var claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Name, authUser.Id.ToString())
            };
            
            foreach (var permission in authUser.UserRolePermissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, permission));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            authUser.Token = tokenHandler.WriteToken(token);

            return Ok(authUser);
        }

        [AllowAnonymous]
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!(await this.authService.IsValidUser(model.UserName, model.Password)))
            {
                return BadRequest(new { Message = "Username or password is invalid"});
            }

            var isSucceed = await this.authService.ChangePasswordByUserNameAsync(model.UserName, model.NewPassword);

            return Ok(isSucceed);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var isSucceed = true;

            return Ok(isSucceed);
        }

        [Authorize(Roles = RolePermission.SuperAdmin)]
        [HttpGet("superadmin")]
        public  async Task<IActionResult> GetSuperAdminData()
        {
            return BadRequest(new { Message = "super admin authorize"});
        }

    }
}