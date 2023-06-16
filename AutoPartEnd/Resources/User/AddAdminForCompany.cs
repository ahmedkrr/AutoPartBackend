using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.User
{
    [ApiController]
    [Route("api/Account")]
    [Authorize]
    public class AddAdminForCompany : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AddAdminForCompany(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("AddManager")]
        public async Task<object> AddManagerRequest([FromBody]AddmanagerReq model)
        {
            var CompanyId = User.FindFirst("CompanyId")?.Value;
            var newuser = await _dbContext.Set<UserProfile>().FirstOrDefaultAsync(c => c.Email == model.Email);

            if(newuser == null)
            {
                return BadRequest("The Email Not Found");
            }

            if (newuser.IsCompanyOwner)
            {
                return BadRequest("The user already Company Owner");
            }

            newuser.setAsAcompanyOwner(int.Parse(CompanyId));
            _dbContext.Update(newuser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
   


    }
}
