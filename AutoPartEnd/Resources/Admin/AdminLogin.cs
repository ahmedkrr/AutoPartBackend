using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin
{
    [ApiController]
    [Route("api/admin")]
    public class AdminLogin : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;
        public AdminLogin(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [HttpPost("adminlogin")]
        public async Task<object> CheckLogin([FromBody] UserLogin request)
        {
            var result = await _dbContext.Set<UserProfile>()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower() && u.Password == request.Password && u.IsAdmin==true);
            if (result == null) { return new AdminLoginResponseFailed {success =false}; }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Id",result.Id.ToString() ,ClaimValueTypes.Integer),
                new Claim("Name" ,result.Name),
                new Claim("Role" ,result.Role.ToString()),
                new Claim("isAdmin" ,result.IsAdmin.ToString()),
                new Claim("IsCompanyOwner" ,result.IsCompanyOwner.ToString())


            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            if (result.IsAdmin) 
            {
                var TokenGenrated = new JwtSecurityTokenHandler().WriteToken(token);
                var response = new AdminLoginResponse
                {
                    message = TokenGenrated,
                    success = true
                };
                return response;
            }
            else
            {
                return "Not Authorize User";
            }

        }
    }
}
