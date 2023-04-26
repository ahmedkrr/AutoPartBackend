using AutoPartEnd.Domain;
using Microsoft.AspNetCore.Mvc;
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
            //here should add function if user have acompany should deleted 
            var user = await _dbContext.Set<UserProfile>().FindAsync(Id);

            if (user != null)
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();

                return "Successfully Deleted the user id number" + Id;
            }
            return null;

        }


    }
}
