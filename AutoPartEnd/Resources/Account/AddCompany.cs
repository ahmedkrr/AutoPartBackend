using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Resources.Account
{
    [ApiController]
    [Route("api/Account")]
    [Authorize]
    public class AddCompany : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public AddCompany(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpPost("addcompany")]
        public async Task<object> Addcompany([FromBody] AddCompanyModel request)
        {
            int x = 0;
            int y = 0;
            try
            {
                if (string.IsNullOrEmpty(request.Address) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.CompanyPhoneNumber))
                {
                    throw new Exception("Field is Empty");
                }
                var company = new CompanyProfile(request.Name, request.CompanyPhoneNumber, request.Address);
                _dbContext.Add(company);
                await _dbContext.SaveChangesAsync();

                x = company.Id;
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                var user = await _dbContext.Set<UserProfile>().FindAsync(int.Parse(userId));
                
                user.setAsAcompanyOwner(company.Id);

                await _dbContext.SaveChangesAsync();
                y = user.Id;
                return Ok(company.Id);

            }
            catch (Exception e)
            {
                if (x != 0) 
                { 
                    var x1 = await _dbContext.Set<CompanyProfile>().FindAsync(x);
                    _dbContext.Remove(x1);
                    await  _dbContext.SaveChangesAsync();

                }
                if (y != 0)
                {
                    var x1 = await _dbContext.Set<UserProfile>().FindAsync(y);
                    if (x1.CompanyProfileId != null)
                    {
                        x1.UnDosetAsAcompanyOwner();
                        await _dbContext.SaveChangesAsync();
                    }

                }


                throw new Exception($"{e.Message}");
            }


        }
    }
}
