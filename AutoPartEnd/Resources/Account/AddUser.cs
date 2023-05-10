using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.PhoneNumber))
                {
                    BadRequest("Field is Empty");
                }

                var result = await _dbContext.Set<UserProfile>()
                     .Where(s => request.Email.ToLower().Contains(s.Email.ToLower()))
                     .FirstOrDefaultAsync();

              

                var User = new UserProfile(request.Name, request.Email, request.Password, request.PhoneNumber);
                _dbContext.Add(User);
                await _dbContext.SaveChangesAsync();

                return Ok(User.Id);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                {
                    return BadRequest("The email you provided is already in use!");
                   
                }
                else
                {
                    // Handle other database-related exceptions here
                    return StatusCode(500, "Internal server error");
                }

            }



        }

    }
}
