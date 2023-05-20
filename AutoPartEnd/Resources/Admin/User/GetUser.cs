using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Admin.User
{
    [ApiController]
    [Route("api/admin")]
    public class GetUser : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetUser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet("GetUser/{id}")]
        public async Task<object> GetUserRequest([FromRoute] int id)
        {
            var user = await _dbContext.Set<UserProfile>()
                .FirstOrDefaultAsync(c => c.Id == id)
                ;
                

            if (user == null)
                return NoContent();


            return Ok(new UpdatUserReq { 
            Email = user.Email,
            Name = user.Name,
            IsAdmin = user.IsAdmin,
            IsDeactive = user.IsDeactive
            
            });

        }
    }

    }
