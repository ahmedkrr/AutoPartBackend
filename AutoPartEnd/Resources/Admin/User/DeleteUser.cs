using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/admin")]
    public class DeleteUser : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public DeleteUser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    [HttpDelete("deleteuser/{id}")]
    public async Task<object> DeleteUserRequest([FromRoute] int Id)
        {
            var user = await _dbContext.Set<UserProfile>()
                .Include(c => c.CompanyProfile )
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (user != null)
            {
                var items = await _dbContext.Set<Item>()
                    .FirstOrDefaultAsync(c => c.UserProfileId == user.Id);


                if(items != null)
                _dbContext.Remove(items);
                _dbContext.Set<CompanyProfile>().Remove(user.CompanyProfile);
                _dbContext.Remove(user);



                await _dbContext.SaveChangesAsync();

                return Ok("Successfully Deleted the user id number" );
            }

            return BadRequest(); ;

        }


    }
}
