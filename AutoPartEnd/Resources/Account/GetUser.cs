using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Account
{
    [ApiController]
    [Route("api/Account")]
    public class GetUser : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<object> GetUserInfo([FromBody] GeyUserInfoRequest request)
        {
            var result = await _dbContext.Set<UserProfile>()
                 .Where(s => s.Id == request.Id)
                 .Select(s => new UserRegestrationResponsinfo
                 { 
                     Id = s.Id,
                     Email = s.Email,
                     Name = s.Name,
                     PhoneNumber = s.PhoneNumber
                 })
                 .FirstOrDefaultAsync();

            if (result == null)
            {
                return "User not found";
            }
            return result;
        }
    }
}
