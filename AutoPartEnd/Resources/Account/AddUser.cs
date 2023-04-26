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
     
    public class AddUser : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public AddUser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("register")]
        public async Task<object> Register([FromBody]UserRegestrationRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Password) ||string.IsNullOrEmpty(request.PhoneNumber))
            {
               throw new Exception("Field is Empty");
            }

            var result = await _dbContext.Set<UserProfile>()
                 .Where(s => request.Email.ToLower().Contains(s.Email.ToLower()))
                 .FirstOrDefaultAsync();

            if (result != null)
                throw new Exception($"The Email :{request.Email} is alerdy in use, please use another email");


            var User = new UserProfile(request.Name, request.Email, request.Password, request.PhoneNumber);
            _dbContext.Add(User);
            await _dbContext.SaveChangesAsync();

            return User.Id;
        }

    }
}
