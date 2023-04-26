using AutoPartEnd.Domain;
using AutoPartEnd.Model;
using Microsoft.AspNetCore.Authorization;
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
   
    public class GetAllUser : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllUser(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("GetAllUsers")]
        public async Task<object> GetAllUserRequest()
        {
            var user =  _dbContext.Set<UserProfile>()
                .Include(c => c.CompanyProfile)
                //.Include(c => c.Role)
                .Select(s => new GetUserResponseinfo
                { 
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Role = s.Role.ToString(),
                IsCompanyOwner = s.IsCompanyOwner,
                IsAdmin = s.IsAdmin,
                IsDeactive = s.IsDeactive,
                CreatDate = $"{s.CreatDate.Day}/{s.CreatDate.Month}/{s.CreatDate.Year}" ,
                CompanyProfile = s.CompanyProfile.Name,
                CompanyProfileId =s.CompanyProfileId

                
                }
                    )
                .ToList();

            if (user == null)
                return "There is no User";

            return user;

        }


    }
   



}
