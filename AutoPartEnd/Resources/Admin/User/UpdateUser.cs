using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources
{
    [ApiController]
    [Route("api/admin")]
    public class UpdateUser : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateUser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("UpdateUser/{Id}")]
        public async Task<object> UpdateUserRequest([FromBody] UpdatUserReq Request, [FromRoute] int Id)
        {
            var user = await _dbContext.Set<UserProfile>()
                .FindAsync(Id);

            user.UpdateUserAdmin(Request.Name ,Request.Email ,Request.IsAdmin, Request.IsDeactive);

            var UpdatedItems = _dbContext.Set<Item>()
               .Find(Id);

            await _dbContext.SaveChangesAsync();
            return Ok();


        }



    }
}
